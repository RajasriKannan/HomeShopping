using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShopping.DAL;
using HomeShopping.DAL.LoginPages;

namespace HomeShopping.BLL.LoginPages
{
    public class UserRegistrationLogicsBLL
    {
        static string connectionString = LogicBase.GetConnectionString();
        public static int AddUserRegistationDetails(UserRegistation userRegistation)
        {
            try
            {
                if (userRegistation != null)
                {
                    int result = UserRegistrationLogicsDAL.AddUserRegistrationtoDB(connectionString, userRegistation);
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return 0;
            }
        }

        public static int ValidateLoginDetails(string UserName, string Password)
        {
            try
            {
                int result = UserRegistrationLogicsDAL.ValidateLoginDetailsInDB(connectionString, UserName, Password);
                return result;
            }
            catch(Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return 0;
            }
        }
    }
}