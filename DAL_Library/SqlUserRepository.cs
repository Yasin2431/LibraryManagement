using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL_Library
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public SqlUserRepository(string connectionString =
            "Data Source=.;Initial Catalog=Library;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;Connect Timeout=3;")
        {
            _connectionString = connectionString;
        }

        public List<user> GetAllUsers()
        {
            var users = new List<user>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.GetAllUsers", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(MapReaderToUser(reader));
                    }
                }
            }

            return users;
        }

        public void AddUser(user user)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.AddUser", connection))
            {
                AddUserParameters(command, user);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool UpdateUser(user user)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.UpdateUser", connection))
            {
                command.Parameters.AddWithValue("@Id", user.Id);
                AddUserParameters(command, user);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                return rows > 0 || rows == -1;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.DeleteUser", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public user? GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.GetUserById", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapReaderToUser(reader);
                    }
                }
            }

            return null;
        }

        public user? GetUserByMembershipCode(string membershipCode)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.GetUserByMembershipCode", connection))
            {
                command.Parameters.AddWithValue("@MembershipCode", membershipCode);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapReaderToUser(reader);
                    }
                }
            }

            return null;
        }

        public bool IsNationalCodeUnique(string nationalCode, int id = 0)
        {
            string query = "SELECT COUNT(1) FROM Users WHERE NationalCode = @NationalCode AND (@Id = 0 OR Id != @Id)";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NationalCode", nationalCode);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count == 0; // اگر صفر باشد یعنی تکراری نیست و مجاز است
            }
        }

        public bool IsMembershipCodeUnique(string membershipCode, int id = 0)
        {
            string query = "SELECT COUNT(1) FROM Users WHERE MembershipCode = @MembershipCode AND (@Id = 0 OR Id != @Id)";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MembershipCode", membershipCode);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count == 0; // اگر صفر باشد یعنی تکراری نیست و مجاز است
            }
        }

        #region Helper Methods

        private static SqlCommand CreateSpCommand(string procedureName, SqlConnection connection)
        {
            return new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        private static void AddUserParameters(SqlCommand command, user user)
        {
            command.Parameters.AddWithValue("@MembershipCode", user.MembershipCode?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@FirstName", user.FirstName?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@LastName", user.LastName?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@NationalCode", user.NationalCode?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@MembershipDate", user.MembershipDate);

            // مدیریت ذخیره عکس به صورت باینری (در صورت خالی بودن DBNull قرار می‌گیرد)
            command.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = (object?)user.Photo ?? DBNull.Value;
        }

        private static user MapReaderToUser(IDataRecord reader)
        {
            return new user
            {
                Id = reader["Id"] is DBNull ? 0 : Convert.ToInt32(reader["Id"]),
                MembershipCode = reader["MembershipCode"] is DBNull ? string.Empty : reader["MembershipCode"].ToString()!,
                FirstName = reader["FirstName"] is DBNull ? string.Empty : reader["FirstName"].ToString()!,
                LastName = reader["LastName"] is DBNull ? string.Empty : reader["LastName"].ToString()!,
                NationalCode = reader["NationalCode"] is DBNull ? string.Empty : reader["NationalCode"].ToString()!,
                PhoneNumber = reader["PhoneNumber"] is DBNull ? string.Empty : reader["PhoneNumber"].ToString()!,
                MembershipDate = reader["MembershipDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["MembershipDate"]),
                Photo = reader["Photo"] is DBNull ? null : (byte[])reader["Photo"]
            };
        }

        #endregion
    }
}
