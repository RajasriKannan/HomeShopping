using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShopping.DAL.LoginPages
{
    public class UserRegistation
    {
        public int RegistrationID { get; set; }
        public string RegisterName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}