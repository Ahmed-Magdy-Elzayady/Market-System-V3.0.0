using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.DTOs.Account
{
    public class RegisterDTO
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastNAme { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

    }
}
