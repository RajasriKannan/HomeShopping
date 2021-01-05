using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HomeShopping.DAL.RoomsByCategory
{
    public class ListItemsByCategory
    {
        public const string StoredProcedure = "sp_ListItemsByCategory";

        public const string GetListItemsByCategory = "a";
        public const string GetInStock = "b";
        public const string GetAddToCart = "c";
        public const string GetRoomsCategory = "d";
    }
    public class ListItemsByCategoryDAL
    {
        public static DataSet GetListItemsByCategoryDAL(string ConnectionString)
        {
            return GetLookUpItems(ConnectionString, ListItemsByCategory.StoredProcedure, ListItemsByCategory.GetListItemsByCategory);
        }

        public static DataSet GetInStockDAL(string ConnectionString)
        {
            return GetLookUpItems(ConnectionString, ListItemsByCategory.StoredProcedure, ListItemsByCategory.GetInStock);
        }

        public static DataSet GetAddToCartDAL(string ConnectionString)
        {
            return GetLookUpItems(ConnectionString, ListItemsByCategory.StoredProcedure, ListItemsByCategory.GetAddToCart);
        }

        public static DataSet GetRoomsCategoryDAL(string ConnectionString)
        {
            return GetLookUpItems(ConnectionString, ListItemsByCategory.StoredProcedure, ListItemsByCategory.GetRoomsCategory);
        }

        private static DataSet GetLookUpItems(string ConnectionString, string storedProcedure,string mode)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = new SqlCommand();

                    sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                    sqlDataAdapter.SelectCommand.CommandText = storedProcedure;
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@mode", mode);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
            catch(Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return null;
            }
        }
    }
}