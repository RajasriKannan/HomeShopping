using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HomeShopping.DAL.RoomsByCategory
{
    public class HomeLogics
    {
        public const string StoredProcedure = "sp_Home";

        public const string GetProductsByRoomCategory = "a";
    }
    public class HomeLogicsDAL
    {
        public static DataSet GetProductsByRoomCategoryDAL(string ConnectionString, string UserName, int RoomCategoryID )
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = new SqlCommand();

                    sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                    sqlDataAdapter.SelectCommand.CommandText = HomeLogics.StoredProcedure;
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@mode", HomeLogics.GetProductsByRoomCategory);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@RoomsCategoryID", RoomCategoryID);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", UserName);

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
    }
}