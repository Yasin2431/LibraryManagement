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

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.GetAllBooks", connection))
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

        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.AddBook", connection))
            {
                AddBookParameters(command, book);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool UpdateBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateSpCommand("dbo.UpdateBook", connection))
            {
                command.Parameters.AddWithValue("@Id", book.Id);
                AddBookParameters(command, book);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0 || rowsAffected == -1;
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

        public Book? GetBookById(int id)
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
            const string query = "SELECT COUNT(1) FROM Books WHERE ISBN = @ISBN AND (@Id = 0 OR Id != @Id)";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ISBN", isbn?.Trim() ?? string.Empty);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;  
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

        private static void AddBookParameters(SqlCommand command, Book book)
        {
            command.Parameters.AddWithValue("@Title", book.Title?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@Author", book.Author?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@ISBN", book.ISBN?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@Language", string.IsNullOrWhiteSpace(book.Language) ? "خالی" : book.Language.Trim());
            command.Parameters.AddWithValue("@Category", string.IsNullOrWhiteSpace(book.Category) ? "خالی" : book.Category.Trim());
            command.Parameters.AddWithValue("@PublishYear", string.IsNullOrWhiteSpace(book.PublishYear) ? "خالی" : book.PublishYear.Trim());
        }

        private static Book MapReaderToBook(IDataRecord reader)
        {
            string title = reader["Title"] is DBNull ? string.Empty : reader["Title"].ToString()!;
            string author = reader["Author"] is DBNull ? string.Empty : reader["Author"].ToString()!;
            string isbn = reader["ISBN"] is DBNull ? string.Empty : reader["ISBN"].ToString()!;

            return new Book(title, author, isbn)
            {
                Id = reader["Id"] is DBNull ? 0 : Convert.ToInt32(reader["Id"]),
                Language = reader["Language"] is DBNull ? "خالی" : reader["Language"].ToString()!,
                Category = reader["Category"] is DBNull ? "خالی" : reader["Category"].ToString()!,
                PublishYear = reader["PublishYear"] is DBNull ? "خالی" : reader["PublishYear"].ToString()!
            };
        }

        #endregion
    }
}
