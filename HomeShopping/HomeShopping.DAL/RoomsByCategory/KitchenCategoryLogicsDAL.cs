using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HomeShopping.DAL.RoomsByCategory
{
    public class KitchenCategory
    {
        public const string StoredProcedure = "sp_KitchenCategory";

        public const string GetKitchenCategoryMode = "a";
        public const string GetProductsByCategory = "b";
        public const string AddKitchenProductsInList = "c";
        public const string AddKitchenProductsNotInList = "d";
        public const string GetKitchenProductsToEdit = "e";
        public const string UpdateKitchenProducts = "f";
        public const string DeleteKitchenProducts = "g";
    }
    public class KitchenCategoryLogicsDAL
    {
        public static DataSet GetKitchenCategoryDAL(string ConnectionString)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = new SqlCommand();

                    sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                    sqlDataAdapter.SelectCommand.CommandText = KitchenCategory.StoredProcedure;
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@mode", KitchenCategory.GetKitchenCategoryMode);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
            catch (Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return null;
            }
        }

        public static DataSet GetKitchenProductsByCategoryDAL(string ConnectionString, int KitchenCategoryID, int ListItemsByCategoryID, string userName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = new SqlCommand();

                    sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                    sqlDataAdapter.SelectCommand.CommandText = KitchenCategory.StoredProcedure;
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@mode", KitchenCategory.GetProductsByCategory);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@KitchenCategoryID", KitchenCategoryID);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ListItemsByCategoryID", ListItemsByCategoryID);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", userName);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
            catch (Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return null;
            }
        }

        public static DataSet GetKitchenProductsByCategoryToEditDAL(string ConnectionString, int KitchenCategoryID, int ListItemsByCategoryID, string userName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = new SqlCommand();

                    sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                    sqlDataAdapter.SelectCommand.CommandText = KitchenCategory.StoredProcedure;
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@mode", KitchenCategory.GetKitchenProductsToEdit);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@KitchenCategoryID", KitchenCategoryID);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ListItemsByCategoryID", ListItemsByCategoryID);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", userName);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
            catch (Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return null;
            }
        }

        public static int InsertKitchenProductsInListDAL(string ConnectionString, string UserName,int KitchenCategoryID, string Products, int Quantity, int InStockID, int AddInCart,string Comments)
        {
            return InsertKitchenProductsDAL(ConnectionString, UserName, KitchenCategoryID, Products, Quantity, InStockID, AddInCart, KitchenCategory.StoredProcedure,KitchenCategory.AddKitchenProductsInList, Comments);
        }

        public static int InsertKitchenProductsNotInListDAL(string ConnectionString, string UserName, int KitchenCategoryID, string Products, int Quantity, int InStockID, int AddInCart, string Comments)
        {
            return InsertKitchenProductsDAL(ConnectionString, UserName, KitchenCategoryID, Products, Quantity, InStockID, AddInCart, KitchenCategory.StoredProcedure, KitchenCategory.AddKitchenProductsNotInList, Comments);
        }
        private static int InsertKitchenProductsDAL(string ConnectionString, string UserName,int KitchenCategoryID, string Products, int Quantity, int InStockID, int AddInCart, string StoredProcedue, string Mode, string Comments)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = StoredProcedue;

                    sqlCommand.Parameters.AddWithValue("@userName", UserName);
                    sqlCommand.Parameters.AddWithValue("@Products", Products);
                    sqlCommand.Parameters.AddWithValue("@quantity", Quantity);
                    sqlCommand.Parameters.AddWithValue("@LKInStockID", InStockID);
                    sqlCommand.Parameters.AddWithValue("@LKAddToCartID", AddInCart);
                    sqlCommand.Parameters.AddWithValue("@mode", Mode);
                    sqlCommand.Parameters.AddWithValue("@Comments", Comments);
                    sqlCommand.Parameters.AddWithValue("@KitchenCategoryID", KitchenCategoryID);

                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return 0;
            }
        }

        public static int UpdateKitchenProductsDAL(string ConnectionString, string UserName, int KitchenCategoryID, string EditProduct, int EditQuantity, int EditInStockID, int EditAddToCart, string EditComments)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = KitchenCategory.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@userName", UserName);
                    sqlCommand.Parameters.AddWithValue("@KitchenCategoryID", KitchenCategoryID);
                    sqlCommand.Parameters.AddWithValue("@Products", EditProduct);
                    sqlCommand.Parameters.AddWithValue("@quantity", EditQuantity);
                    sqlCommand.Parameters.AddWithValue("@LKInStockID", EditInStockID);
                    sqlCommand.Parameters.AddWithValue("@LKAddToCartID", EditAddToCart);
                    sqlCommand.Parameters.AddWithValue("@comments", EditComments);
                    sqlCommand.Parameters.AddWithValue("@mode", KitchenCategory.UpdateKitchenProducts);

                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return 0;
            }
        }

        public static int DeleteKitchenProductsDAL(string ConnectionString, string UserName, int KitchenCategoryID, string Products)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = KitchenCategory.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@userName", UserName);
                    sqlCommand.Parameters.AddWithValue("@KitchenCategoryID", KitchenCategoryID);
                    sqlCommand.Parameters.AddWithValue("@Products", Products);
                    sqlCommand.Parameters.AddWithValue("@mode", KitchenCategory.DeleteKitchenProducts);

                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return 0;
            }
        }
    }
}