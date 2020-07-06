using SummerPractice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.DAL
{
    public class SkillBase : ISkillBase
    {
        string connectionString = "Data Source=DESKTOP-LJEFIBE\\SQLEXPRESS;Initial Catalog=UserSkills;Integrated Security=True";

        public string AddSkill(Skill skill)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddSkill";
                    command.Parameters.Add("@skillName", SqlDbType.VarChar).Value = skill.SkillName;
                    command.Parameters.Add("@description", SqlDbType.VarChar).Value = skill.Description;
                    var rowCount = command.ExecuteNonQuery();
                    return "Навык успешно добавлен. Строк добавлено = " + rowCount;
                }
                catch (Exception exception)
                {
                    return exception.StackTrace;
                }
            }
        }

        public string RemoveSkill(string skillName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "RemoveSkill";
                    command.Parameters.Add("@skillName", SqlDbType.VarChar).Value = skillName;
                    var rowCount = command.ExecuteNonQuery();
                    return "Навык успешно удален. Строк удалено = " + rowCount;
                }
                catch (Exception exception)
                {
                    return exception.StackTrace;
                }
            }
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            List<Skill> listSkills = new List<Skill>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllSkills";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listSkills.Add(new Skill() { SkillName = (string)dataReader["skillName"], Description = (string)dataReader["description"] });
                    }
                }

            }
            return listSkills;
        }

        public IEnumerable<Skill> GetSkill(string skillName)
        {
            List<Skill> listSkills = new List<Skill>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSkill";
                command.Parameters.Add("@skillName", SqlDbType.VarChar).Value = skillName;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listSkills.Add(new Skill() { SkillName = (string)dataReader["skillName"], Description = (string)dataReader["description"] });
                    }
                }

            }
            return listSkills;
        }

        public string UpdateSkillDescription(string skillName, string newDiscription)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateSkillDescription";
                    command.Parameters.Add("@skillName", SqlDbType.VarChar).Value = skillName;
                    command.Parameters.Add("@newDescription", SqlDbType.VarChar).Value = newDiscription;
                    var rowCount = command.ExecuteNonQuery();
                    return "Описание навыка успешно изменено. Строк изменено = " + rowCount;
                }
                catch (Exception exception)
                {
                    return exception.StackTrace;
                }
            }
        }

        public string UpdateSkillName(string oldName, string newName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateSkillName";
                    command.Parameters.Add("@oldName", SqlDbType.VarChar).Value = oldName;
                    command.Parameters.Add("@newName", SqlDbType.VarChar).Value = newName;
                    var rowCount = command.ExecuteNonQuery();
                    return "Название навыка успешно изменено. Строк изменено = " + rowCount;
                }
                catch (Exception exception)
                {
                    return exception.StackTrace;
                }
            }
        }
        public IEnumerable<Skill> SortByName()
        {
            List<Skill> listSkills = new List<Skill>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SortByName";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listSkills.Add(new Skill() { SkillName = (string)dataReader["skillName"], Description = (string)dataReader["description"] });
                    }
                }

            }
            return listSkills;
        }
    }
}
