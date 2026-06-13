using AutoMapper;
using MarketSystem.BLL.DTOs.Account;
using MarketSystem.DAL.Data.Models;
using MArketSystem.API.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MArketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _aotomapper;
        private readonly IConfiguration _configration;

        public AuthController(UserManager<ApplicationUser> usermanager,RoleManager<IdentityRole> rolemanager,IMapper automapper,IConfiguration configration)
        {
            _usermanager = usermanager;
            _aotomapper = automapper;
            _rolemanager = rolemanager;
            _configration = configration;
        }

        [HttpPost]
        [Route("Sign-Up")]
        public async Task<ActionResult> Registeration(RegisterDTO user)
        {
            var Roles = new ApplicatioRoles();
            var MappedUser = _aotomapper.Map<ApplicationUser>(user);
            var ResultOFCreatingUser= await _usermanager.CreateAsync(MappedUser, user.Password);
            if (!ResultOFCreatingUser.Succeeded)
                return BadRequest(ResultOFCreatingUser.Errors);
            var IsUserRoleExist=await _rolemanager.RoleExistsAsync(Roles.User);
            if (!IsUserRoleExist)
                 await _rolemanager.CreateAsync(new IdentityRole { Name = Roles.User });
            var ResultOFAddingRoleToUSer=await _usermanager.AddToRoleAsync(MappedUser, Roles.User);
            if (!ResultOFAddingRoleToUSer.Succeeded)
                 return BadRequest(ResultOFAddingRoleToUSer.Errors);
            return Ok("User Created Successfully");
            
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> LogIn(LoginDTO user)
        {
            var Roles = new ApplicatioRoles();
            var ISUSerExist = await _usermanager.FindByNameAsync(user.UserName);
            if (ISUSerExist == null || !await _usermanager.CheckPasswordAsync(ISUSerExist, user.Password))
                return BadRequest("User Name Or Password Is Incorrect");

            List<Claim> MyClaim = new List<Claim>();
            MyClaim.Add(new Claim(ClaimTypes.NameIdentifier, ISUSerExist.Id));
            MyClaim.Add(new Claim(ClaimTypes.Name , ISUSerExist.UserName!));
            var roles = await _usermanager.GetRolesAsync(ISUSerExist);
            foreach (var role in roles)
                MyClaim.Add(new Claim(ClaimTypes.Role, role));

            var Token =  TokenGenerator(MyClaim);
            return Ok(Token);
        }

        private string TokenGenerator(List<Claim > Myclaim) {
            var KeyFromSecret = _configration["SecretKey"];
            var keyInBytes = Encoding.ASCII.GetBytes(KeyFromSecret!);
            var MySK = new SymmetricSecurityKey(keyInBytes);

            var MySigningCredential = new SigningCredentials(MySK, SecurityAlgorithms.HmacSha256);
            var JWT = new JwtSecurityToken(
                claims: Myclaim,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: MySigningCredential,
                issuer: "MyCpmpany",
                audience: "MobileApp"
                );

            var TokenInString = new JwtSecurityTokenHandler().WriteToken(JWT);
            return TokenInString;
        }
    }
}
