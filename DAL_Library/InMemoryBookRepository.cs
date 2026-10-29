using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    public class InMemoryBookRepository : IBookRepository
    {
        private static readonly List<Book> _books = new List<Book>();
        private static int _nextId = 1;

        public List<Book> GetAllBooks()
        {
            return new List<Book>(_books);
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            if (book == null)
                return;

            if (book.Id <= 0)
                book.Id = _nextId++;

            book.Language = string.IsNullOrWhiteSpace(book.Language) ? "خالی" : book.Language.Trim();
            book.Category = string.IsNullOrWhiteSpace(book.Category) ? "خالی" : book.Category.Trim();
            book.PublishYear = string.IsNullOrWhiteSpace(book.PublishYear) ? "خالی" : book.PublishYear.Trim();

            _books.Add(book);
        }

        public bool DeleteBook(int id)
        {
            Book bookToDelete = _books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete != null)
            {
                return _books.Remove(bookToDelete);
            }

            return false;
        }

        public bool UpdateBook(Book updatedBook)
        {
            if (updatedBook == null || updatedBook.Id <= 0)
                return false;

            var existingBook = _books.FirstOrDefault(b => b.Id == updatedBook.Id);

            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title?.Trim() ?? string.Empty;
                existingBook.Author = updatedBook.Author?.Trim() ?? string.Empty;
                existingBook.ISBN = updatedBook.ISBN?.Trim() ?? string.Empty;
                existingBook.Language = string.IsNullOrWhiteSpace(updatedBook.Language) ? "خالی" : updatedBook.Language.Trim();
                existingBook.Category = string.IsNullOrWhiteSpace(updatedBook.Category) ? "خالی" : updatedBook.Category.Trim();
                existingBook.PublishYear = string.IsNullOrWhiteSpace(updatedBook.PublishYear) ? "خالی" : updatedBook.PublishYear.Trim();

                return true;
            }

            return false;
        }
        public bool Validation(string isbn, int id = 0)
        {
            return _books.Any(b => b.ISBN == isbn && (id == 0 || b.Id != id));
        }


        
    }
}
