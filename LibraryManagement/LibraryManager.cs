using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;
using System.Text;

namespace LibraryManagement
{
    internal class LibraryManager
    {
        private static List<Book> Book = new List<Book>();

        public void AddBook(Book book)
        {
            if (Book == null)
                Book = new List<Book>();

            Book.Add(book);
        }
        
        public List<Book> GetBooK()
        {
            return Book;
        }
        public string[] Validation(string title, string author, string isbn)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(title))
                errors.Add("Title");

            if (string.IsNullOrWhiteSpace(author))
                errors.Add("Author");

            if (isbn.Length!=13 )
                errors.Add("ISBN");

            if (Book.Exists(x => x.ISBN == isbn))
              errors.Add("IsbnAgain");
            
            return errors.ToArray();
        }
        public void RemoveBook(int id)
        {
            Book book = Book.Find(x => x.Id == id);

            if (book != null)
            {
                Book.Remove(book);
            }
        }
        public Book EditBook(int id)
        {
            return Book.Find(x => x.Id == id);
        }


    }
}
