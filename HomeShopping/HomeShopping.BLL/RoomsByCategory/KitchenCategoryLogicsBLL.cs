using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShopping.DAL;
using HomeShopping.DAL.RoomsByCategory;
using System.Data;

namespace HomeShopping.BLL.RoomsByCategory
{
    public class KitchenCategoryLogicsBLL
    {
        private static string connectionString = LogicBase.GetConnectionString();

        public static DataSet GetKitchenCategoryBLL()
        {
            try
            {
                return KitchenCategoryLogicsDAL.GetKitchenCategoryDAL(connectionString);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }

        public static DataSet GetKitchenProductsByCategoryBLL(int KitchenCategoryID, int ListItemsByCategoryID, string userName)
        {
            try
            {
                return KitchenCategoryLogicsDAL.GetKitchenProductsByCategoryDAL(connectionString,KitchenCategoryID,ListItemsByCategoryID,userName);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }

        public static DataSet GetKitchenProductsByCategoryToEditBLL(int KitchenCategoryID, int ListItemsByCategoryID, string userName)
        {
            try
            {
                return KitchenCategoryLogicsDAL.GetKitchenProductsByCategoryToEditDAL(connectionString, KitchenCategoryID, ListItemsByCategoryID, userName);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return null;
            }
        }

        public static int InsertKitchenProductsBLL(string UserName,int KitchenCategoryID, string Products, int Quantity, int InStockID, int AddInCart, string Comments)
        {
            try
            {
                return KitchenCategoryLogicsDAL.InsertKitchenProductsInListDAL(connectionString, UserName, KitchenCategoryID, Products, Quantity, InStockID, AddInCart, Comments);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return 0;
            }
        }

        public static int InsertKitchenProductsNotInListBLL(string UserName, int KitchenCategoryID, string Products, int Quantity, int InStockID, int AddInCart, string Comments)
        {
            try
            {
                return KitchenCategoryLogicsDAL.InsertKitchenProductsNotInListDAL(connectionString, UserName, KitchenCategoryID, Products, Quantity, InStockID, AddInCart, Comments);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return 0;
            }
        }

        public static int UpdateKitchenProductsBLL(string UserName, int KitchenCategoryID, string Products, int Quantity, int InStockID, int AddInCart, string Comments)
        {
            try
            {
                return KitchenCategoryLogicsDAL.UpdateKitchenProductsDAL(connectionString, UserName, KitchenCategoryID, Products, Quantity, InStockID, AddInCart, Comments);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return 0;
            }
        }

        public static int DeleteKitchenProductsBLL(string UserName, int KitchenCategoryID, string Products)
        {
            try
            {
                return KitchenCategoryLogicsDAL.DeleteKitchenProductsDAL(connectionString, UserName, KitchenCategoryID, Products);
            }
            catch (Exception exception)
            {
                Log.Error(Layers.BLL, exception);
                return 0;
            }
        }
    }
}