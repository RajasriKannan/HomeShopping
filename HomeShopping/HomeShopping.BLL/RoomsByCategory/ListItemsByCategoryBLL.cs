using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShopping.DAL.RoomsByCategory;
using System.Data;
using HomeShopping.DAL;

namespace HomeShopping.BLL.RoomsByCategory
{
    public class ListItemsByCategoryBLL
    {
        private static string connectionString = LogicBase.GetConnectionString();

        public static DataSet GetListItemsByCategoryBLL()
        {
            try
            {
                return ListItemsByCategoryDAL.GetListItemsByCategoryDAL(connectionString);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }

        public static DataSet GetInStockBLL()
        {
            try
            {
                return ListItemsByCategoryDAL.GetInStockDAL(connectionString);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }

        public static DataSet GetAddToCartBLL()
        {
            try
            {
                return ListItemsByCategoryDAL.GetAddToCartDAL(connectionString);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }

        public static DataSet GetRoomsCategoryDAL()
        {
            try
            {
                return ListItemsByCategoryDAL.GetRoomsCategoryDAL(connectionString);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }
    }
}