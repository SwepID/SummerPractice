using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.DAL
{
    public class UserBase : IUserBase
    {
        string connectionString = "Data Source=DESKTOP-LJEFIBE\\SQLEXPRESS;Initial Catalog=UserSkills;Integrated Security=True";

        public string CreateUser(Models.User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "CreateUser";
                    command.Parameters.Add("@login", SqlDbType.VarChar).Value = user.Login;
                    command.Parameters.Add("@fname", SqlDbType.VarChar).Value = user.Fname;
                    command.Parameters.Add("@sname", SqlDbType.VarChar).Value = user.Sname;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;
                    var rowCount = command.ExecuteNonQuery();
                    return "Пользователь успешно зарегистрирован. Строк добавлено = " + rowCount;
                }
                catch (Exception exception)
                {
                    return exception.StackTrace;
                }
            }
        }
        public bool Authorization(string login, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string hashPass = null;
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UserAuthorization";
                    command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            hashPass = (string)dataReader["password"];
                        }
                    }
                    if (hashPass != null)
                    {
                        if (Encryption.GetHash(password).Equals(hashPass))
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                    
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }

    }
}
