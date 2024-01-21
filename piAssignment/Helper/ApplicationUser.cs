using System;
using Microsoft.AspNetCore.Identity;

namespace piAssignment.Helper
{
	public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

