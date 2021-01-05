using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using HomeShopping.DAL;
using HomeShopping.DAL.RoomsByCategory;

namespace HomeShopping.BLL.RoomsByCategory
{
    public class HomeLogicsBLL
    {
        private static string connectionString = LogicBase.GetConnectionString();
        public static DataSet GetProductsByRoomCategoryBLL(string UserName, int RoomsCategory)
        {
            try
            {
                return HomeLogicsDAL.GetProductsByRoomCategoryDAL(connectionString, UserName, RoomsCategory);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }
    }
}