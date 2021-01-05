using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HomeShopping.DAL.LoginPages
{
    public class UserRegistrationLogicsDAL
    {
        public static int AddUserRegistrationtoDB(string ConnectionString, UserRegistation userRegistation)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_UserDetails";
                    sqlCommand.Parameters.AddWithValue("@RegisterName", userRegistation.RegisterName);
                    sqlCommand.Parameters.AddWithValue("@UserName", userRegistation.UserName);
                    sqlCommand.Parameters.AddWithValue("@UserPassword", userRegistation.Password);
                    sqlCommand.Parameters.AddWithValue("@ContactNumber", userRegistation.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", userRegistation.Email);
                    sqlCommand.Parameters.AddWithValue("@mode", "a");

                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    return result;
                }
            }
            catch(Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return 0;
            }
        }

        public static int ValidateLoginDetailsInDB(string ConnectionString, string UserName, string Password)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = ConnectionString;

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_validateLogin";

                    sqlCommand.Parameters.AddWithValue("@LoginName", UserName);
                    sqlCommand.Parameters.AddWithValue("@LoginPassword", Password);

                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
            catch(Exception exception)
            {
                Log.Error(Layers.DAL, exception);
                return 0;
            }
        }
    }
}