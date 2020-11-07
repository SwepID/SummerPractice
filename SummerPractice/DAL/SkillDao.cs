using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SkillDao : ISkillDAL
    { 

        public int AddSkill(Skill skill)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddSkill";
                    command.Parameters.Add("@skillName", SqlDbType.VarChar).Value = skill.SkillName;
                    command.Parameters.Add("@description", SqlDbType.VarChar).Value = skill.Description;
                    int skillId = (int)command.ExecuteScalar();
                    return skillId;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    throw;
                }
            }
        }
        public string AddSkillToUser(Skill skill, User user)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                try
                {
                    int skillId = AddSkill(skill);
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddSkillToUser";
                    command.Parameters.Add("@SkillId", SqlDbType.Int).Value = skillId;
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = user.Id;
                    var rowCount = command.ExecuteNonQuery();
                    return "Навык успешно добавлен пользователю. Строк добавлено = " + rowCount;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return null;
                }
            }
        }

        public string RemoveSkill(int skillId)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "RemoveSkill";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = skillId;
                    var rowCount = command.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine(rowCount);
                    return "Навык успешно удален. Строк удалено = " + rowCount;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return null;
                }
            }
        }
        public string RemoveSkillFromUser(int skillId, int userId)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "RemoveSkillFromUser";
                    command.Parameters.Add("@idUser", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@idSkill", SqlDbType.Int).Value = skillId;
                    var rowCount = command.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine(rowCount);
                    return "Навык успешно удален. Строк удалено = " + rowCount;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return null;
                }
            }
        }

        public IEnumerable<Skill> GetUserSkills(User user)
        {
            List<Skill> listSkills = new List<Skill>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserSkills";
                command.Parameters.Add("@idUser", SqlDbType.Int).Value = user.Id;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listSkills.Add(new Skill() { Id = (int)dataReader["Id"], SkillName = (string)dataReader["skillName"], Description = (string)dataReader["description"] });
                    }
                }

            }
            return listSkills;
        }
        public IEnumerable<Skill> GetAllSkills()
        {
            List<Skill> listSkills = new List<Skill>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllSkills";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listSkills.Add(new Skill() { Id = (int)dataReader["Id"], SkillName = (string)dataReader["skillName"], Description = (string)dataReader["description"] });
                    }
                }

            }
            return listSkills;
        }

        public Skill GetSkill(int skillId)
        {
            Skill skill = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSkill";
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = skillId;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    
                    while (dataReader.Read())
                    {
                        skill = new Skill() { Id = (int)dataReader["Id"], SkillName = (string)dataReader["skillName"], Description = (string)dataReader["description"] };
                    }
                }

            }
            return skill;
        }
        public IEnumerable<Skill> GetSkill(string skillName)
        {
            List<Skill> listSkills = new List<Skill>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSkillByName";
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
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return null;
                }
            }
        }

        public string UpdateSkillName(string oldName, string newName)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return null;
                }
            }
        }
        public string UpdateSkill(int skillId, string skillName, string description)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateSkill";
                    command.Parameters.Add("@SkillName", SqlDbType.VarChar).Value = skillName;
                    command.Parameters.Add("@SkillId", SqlDbType.Int).Value = skillId;
                    command.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;
                    var rowCount = command.ExecuteNonQuery();
                    return "Описание навыка успешно изменено. Строк изменено = " + rowCount;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    return null;
                }
            }
        }
        public IEnumerable<Skill> SortByName()
        {
            List<Skill> listSkills = new List<Skill>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
