using LibraryManagement;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Library
{
    
        public class BLL_Service
        {
            private readonly IBookRepository _repository;

            // سازنده ۱: دریافت ریپوزیتوری آماده (برای تست و انعطاف)
            public BLL_Service(IBookRepository repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            // سازنده ۲: دریافت نام دیتابیس از UI ("SQL" یا "Memory")
            public BLL_Service(string databaseType)
            {
                if (databaseType == "SQL")
                    _repository = new SqlBookRepository();
                else
                    _repository = new InMemoryBookRepository();
            }

            // ۱. اعتبارسنجی — خروجی string[] تا با فرم هماهنگ باشد
            public string[] Validation(string title, string author, string isbn, int id = 0)
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(title))
                    errors.Add("Title");

                if (string.IsNullOrWhiteSpace(author))
                    errors.Add("Author");

                if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13 || !isbn.All(char.IsDigit))
                    errors.Add("ISBN");
                else if (_repository.Validation(isbn, id))
                    errors.Add("IsbnAgain");

                return errors.ToArray();
            }

            // ۲. همه کتاب‌ها
            public List<IBook> GetAllBooks()
            {
                return _repository.GetAllBooks();
            }

            // ۳. یک کتاب با آیدی
            public IBook GetBookById(int id)
            {
                if (id <= 0) return null;
                return _repository.GetBookById(id);
            }

            // ۴. افزودن
            public void AddBook(IBook book)
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book));

                _repository.AddBook(book);
            }

            // ۵. ویرایش
            public bool UpdateBook(IBook book)
            {
                if (book == null || book.Id <= 0)
                    return false;

                return _repository.UpdateBook(book);
            }

            // ۶. حذف
            public bool DeleteBook(int id)
            {
                if (id <= 0) return false;
                return _repository.DeleteBook(id);
            }
        

    }
}
