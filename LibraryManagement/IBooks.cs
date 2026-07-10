using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    internal class IBooks
    {
        public IBooks(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string ISBN
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        public string Category { get; set; }
        public int PublishYear { get; set; }
        public int Id {  get; set; }
        public Result Validate()
        {
            if (ISBN.Length != 13)
            {
                return Result.Failed("کدISBN نامعتبر");
            }

            return Result.Ok();
        }
    }
}
