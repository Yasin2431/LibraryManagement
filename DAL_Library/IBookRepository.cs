using System.Collections.Generic;

namespace LibraryManagement
{
    public interface IBookRepository
    {
        List<IBook> GetAllBooks();
        void AddBook(IBook book);
        bool UpdateBook(IBook book);
        bool DeleteBook(int id);
        IBook GetBookById(int id);

        // اضافه شده برای پشتیبانی از اعتبارسنجی شابک در BLL
        bool Validation(string isbn, int id = 0);
    }
}
