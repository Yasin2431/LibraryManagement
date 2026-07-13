using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace LibraryManagement
{
    public partial class AddForm : Form
    {
        private int _id;
        public AddForm()
        {
          
            InitializeComponent();
            string[] languages = { "English", "Chinese", "Spanish", "Arabic", "French", "German"
            , "Russian", "Japanese", "Portuguese", "Hindi", "Italian", "Korean", "Turkish", "Persian", "Dutch" };
            cmb_language.Items.Clear();
            cmb_language.Items.AddRange(languages);

            string[] category = { "علمی و آموزشی", "داستانی و رمان", "تاریخی", "ادبی", "آموزش مهارت", "خودشناسی و روانشناسی"
                    , "مذهبی", "کودک و نوجوان", "هنری", "جغرافیایی", "بیوگرافی", "فلسفی", "جنایی و معمایی", "علمی تخیلی" };

                
            cmb_category.Items.Clear();
            cmb_category .Items.AddRange(category);
            cmb_pulisheryear.Items.Clear();
            for (int year = 1370; year <= 1405; year++)

                cmb_pulisheryear.Items.Add(year.ToString());
            }
        public AddForm(int id)
        {

            InitializeComponent();
        }
        List<IBook> Book = new List<IBook>();
        LibraryManager libraryManager = new LibraryManager();
        private void AddForm_Load(object sender, EventArgs e)
        {
            if (Book == null || Book.Count == 0)
            {
                Book = new List<IBook>();
            }
            if (_id > 0)
            {
                IBook book = libraryManager.EditBook(_id);

                txt_title.Text = book.Title;
                txt_author.Text = book.Author;
                txt_isbn.Text = book.ISBN;

                cmb_language.Text = book.Language;
                cmb_category.Text = book.Category;
                cmb_pulisheryear.Text = book.PublishYear;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string[] errors = libraryManager.Validation(
                                txt_title.Text,
                                txt_author.Text,
                                txt_isbn.Text);

            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;

            if (errors.Length > 0)
            {
                MessageBox.Show("لطفاً اطلاعات را کامل وارد کنید.");

                foreach (string error in errors)
                {
                    switch (error)
                    {
                        case "Title":
                            MessageBox.Show("نام اثر را وارد کنید .");
                            panel3.BackColor = Color.Firebrick;
                            break;

                        case "Author":
                            MessageBox.Show("نام نویسنده را وارد کنید .");
                            panel2.BackColor = Color.Firebrick;
                            break;

                        case "ISBN":
                            MessageBox.Show("کد 13 رقمی بین المللی کتاب را وارد کنید .");
                            panel1.BackColor = Color.Firebrick;
                            break;
                        case "IsbnAgain":
                            MessageBox.Show("کد بین المللی کتاب نباید تکراری باشد .");
                            panel1.BackColor = Color.Firebrick;
                            break;

                    }
                }

                return;
            }

            IBook book = new IBook(txt_title.Text, txt_author.Text, txt_isbn.Text);
            book.Language = cmb_language.SelectedItem?.ToString() ?? "خالی";
            book.Category = cmb_category.SelectedItem?.ToString() ?? "خالی";
            book.PublishYear = cmb_pulisheryear.SelectedItem?.ToString() ?? "خالی";

            List<IBook> books = libraryManager.GetBooK();

            int id = 1;

            if (books != null && books.Count > 0)
            {
                id = books[books.Count - 1].Id + 1;
            }

            book.Id = id;
            libraryManager.AddBook(book);
            MessageBox.Show("اطلاعات ذخیره شد");


            
        }

    }
}
