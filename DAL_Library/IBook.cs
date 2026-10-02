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

        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public String ISBN {  get; set; }
        public string Category { get; set; }
        public string PublishYear { get; set; }
        public int Id {  get; set; }
        
    }
}
