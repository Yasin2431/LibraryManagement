using System.Collections.Generic;

namespace LibraryManagement
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        void AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
        Book GetBookById(int id);

        
        bool Validation(string isbn, int id = 0);
    }
}
