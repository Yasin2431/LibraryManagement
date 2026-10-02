using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;
using System.Text;

namespace LibraryManagement
{
    internal class LibraryManager
    {
        private static List<IBook> Book = new List<IBook>();

        public void AddBook(IBook book)
        {
            if (Book == null)
                Book = new List<IBook>();

            Book.Add(book);
        }
        
        public List<IBook> GetBooK()
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
            IBook book = Book.Find(x => x.Id == id);

            if (book != null)
            {
                Book.Remove(book);
            }
        }
        public IBook EditBook(int id)
        {
            return Book.Find(x => x.Id == id);
        }


    }
}
