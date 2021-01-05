using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace HomeShopping.BLL
{
    public class LogicBase
    {
        //public static string ConnectionString { get; set; }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBCS"].ToString();
        }
    }
}