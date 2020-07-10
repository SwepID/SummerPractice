using SummerPractice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SummerPractice.DAL
{
    public class UserBase
    {
        string connectionString = "Data Source=DESKTOP-LJEFIBE\\SQLEXPRESS;Initial Catalog=FormsAuth1;Integrated Security=True";

        public User GetUserByLogin(string login)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserByLogin";
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    User user = null;
                    while (dataReader.Read())
                    {
                        user = new User() { Id = (int)dataReader["Id"], Login = (string)dataReader["Login"], Fname = (string)dataReader["Fname"], Sname = (string)dataReader["Sname"], Password = (string)dataReader["Password"], SkillList = null };
                    }
                    return user;
                }

            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<User> users = new List<User>();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllUsers";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        users.Add(new User() { Id = (int)dataReader["Id"], Login = (string)dataReader["Login"], Fname = (string)dataReader["Fname"], Sname = (string)dataReader["Sname"], Password = (string)dataReader["Password"], SkillList = null });
                    }
                    return users;
                }

            }
        }
        public User GetUserById(int idUser)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                User user = null;
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserById";
                command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        user = new User() { Id = (int)dataReader["Id"], Login = (string)dataReader["Login"], Fname = (string)dataReader["Fname"], Sname = (string)dataReader["Sname"], Password = (string)dataReader["Password"], SkillList = null };
                    }
                    return user;
                }

            }
        }
        public string EditUserInfo(int idUser, string fname, string sname)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "EditUserInfo";
                    command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
                    command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                    command.Parameters.Add("@sname", SqlDbType.VarChar).Value = sname;
                    var rowCount = command.ExecuteNonQuery();
                    return "Информация о пользователе успешно изменена. Строк изменено = " + rowCount;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return exception.StackTrace;
                }
            }
        }
        public string ChangePassword(int idUser, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ChangePassword";
                    command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
                    command.Parameters.Add("@newPass", SqlDbType.VarChar).Value = password;
                    var rowCount = command.ExecuteNonQuery();
                    return "Пароль успешно изменен. Строк изменено = " + rowCount;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return exception.StackTrace;
                }
            }
        }
    }
}