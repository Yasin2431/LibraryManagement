using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace LibraryManagement
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public SqlBookRepository(string connectionString =
            "Data Source=.;Initial Catalog=Library;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;Connect Timeout=3;")
        {
            _connectionString = connectionString;
        }

        public List<IBook> GetAllBooks()
        {
            var books = new List<IBook>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.SelectVisit", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(MapReaderToBook(reader));
                    }
                }
            }

            return books;
        }

        public void AddBook(IBook book)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.AddBook", connection))
            {
                AddBookParameters(command, book);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool UpdateBook(IBook book)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = CreateSpCommand("dbo.UpdateBook", connection))
                {
                    command.Parameters.AddWithValue("@Id", book.Id);
                    command.Parameters.AddWithValue("@Title", (object)book.Title ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Author", (object)book.Author ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ISBN", (object)book.ISBN ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Language", (object)book.Language ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Category", (object)book.Category ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PublishYear", (object)book.PublishYear ?? DBNull.Value);

                    connection.Open();
                    int row = command.ExecuteNonQuery();

                    // row == -1 وقتی SP دارای SET NOCOUNT ON است
                    return row > 0 || row == -1;
                }
            }
            catch (Exception)
            {
                // خطا به لایه UI (فرم) منتقل نمی‌شود؛ فرم خودش پیام نمایش می‌دهد
                throw;
            }
        }

        public bool DeleteBook(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.DeleteBook", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public IBook GetBookById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.GetBookById", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapReaderToBook(reader);
                    }
                }
            }

            return null;
        }
        public bool Validation(string isbn, int id = 0)
        {
            string query = "SELECT COUNT(1) FROM Books WHERE ISBN = @ISBN AND (@Id = 0 OR Id != @Id)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; // اگر بزرگتر از صفر باشد یعنی تکراری است (true)
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

        private static void AddBookParameters(SqlCommand command, IBook book)
        {
            command.Parameters.AddWithValue("@Title", book.Title?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@Author", book.Author?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@Language", string.IsNullOrWhiteSpace(book.Language) ? "خالی" : book.Language.Trim());
            command.Parameters.AddWithValue("@ISBN", book.ISBN?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@Category", string.IsNullOrWhiteSpace(book.Category) ? "خالی" : book.Category.Trim());
            command.Parameters.AddWithValue("@PublishYear", string.IsNullOrWhiteSpace(book.PublishYear) ? "خالی" : book.PublishYear.Trim());
        }

        private static IBook MapReaderToBook(IDataRecord reader)
        {
            string title = reader["Title"] is DBNull ? string.Empty : reader["Title"].ToString();
            string author = reader["Author"] is DBNull ? string.Empty : reader["Author"].ToString();
            string isbn = reader["ISBN"] is DBNull ? string.Empty : reader["ISBN"].ToString();

            var book = new IBook(title, author, isbn)
            {
                Id = reader["Id"] is DBNull ? 0 : Convert.ToInt32(reader["Id"]),
                Language = reader["Language"] is DBNull ? "خالی" : reader["Language"].ToString(),
                Category = reader["Category"] is DBNull ? "خالی" : reader["Category"].ToString(),
                PublishYear = reader["PublishYear"] is DBNull ? "خالی" : reader["PublishYear"].ToString()
            };

            return book;
        }

        #endregion
    }
}
