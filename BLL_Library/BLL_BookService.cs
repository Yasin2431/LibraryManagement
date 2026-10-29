using DAL_Library;
using LibraryManagement;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL_Library
{

    public class BLL_BookService
    {
        user user = new user();
        private readonly IBookRepository _bookrepository;
        

        // سازنده ۱: دریافت ریپوزیتوری آماده (برای تست و انعطاف)
        public BLL_BookService(IBookRepository repository)
        {
            _bookrepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // سازنده ۲: دریافت نام دیتابیس از UI ("SQL" یا "Memory")
        public BLL_BookService(string databaseType, string type)
        {
            if (databaseType == "SQL" && type == "کتاب جدید")
                _bookrepository = new SqlBookRepository();
            else
                _bookrepository = new InMemoryBookRepository();

        }

       
        public string[] Validation(string title, string author, string isbn, int id = 0)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(title))
                errors.Add("Title");

            if (string.IsNullOrWhiteSpace(author))
                errors.Add("Author");

            if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13 || !isbn.All(char.IsDigit))
                errors.Add("ISBN");
            else if (_bookrepository.Validation(isbn, id))
                errors.Add("IsbnAgain");

            return errors.ToArray();
        }
        

        // ۲. همه کتاب‌ها
        public List<Book> GetAllBooks()
        {
            return _bookrepository.GetAllBooks();
        }

        // ۳. یک کتاب با آیدی
        public Book GetBookById(int id)
        {
            if (id <= 0) return null;
            return _bookrepository.GetBookById(id);
        }

        // ۴. افزودن
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _bookrepository.AddBook(book);
        }

        // ۵. ویرایش
        public bool UpdateBook(Book book)
        {
            if (book == null || book.Id <= 0)
                return false;

            return _bookrepository.UpdateBook(book);
        }

        // ۶. حذف
        public bool DeleteBook(int id)
        {
            if (id <= 0) return false;
            return _bookrepository.DeleteBook(id);
        }


    }
}
