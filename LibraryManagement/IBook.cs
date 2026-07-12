using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    public class IBook
    {
        public IBook(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
        }

        private string Title { get; set; }
        private string Author { get; set; }
        public string Language { get; set; }
        private string ISBN
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        public string Category { get; set; }
        public string PublishYear { get; set; }
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
