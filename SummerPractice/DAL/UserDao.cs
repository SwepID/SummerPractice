using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class UserDao : IUserDAL
    {
        public int AddUser(User user)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddUser";
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = user.Login;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;
                command.Parameters.Add("@fname", SqlDbType.VarChar).Value = user.Fname;
                command.Parameters.Add("@sname", SqlDbType.VarChar).Value = user.Sname;
                int userId = (int)command.ExecuteScalar();
                return userId;

            }
        }
        public User GetUserByLogin(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
                    return null;
                }
            }
        }
        public string ChangePassword(int idUser, string password)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
                    return null;
                }
            }
        }
    }
}