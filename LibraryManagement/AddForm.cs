using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace LibraryManagement
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
           
            InitializeComponent();
            string[] languages = { "English", "Chinese", "Spanish", "Arabic", "French", "German"
            , "Russian", "Japanese", "Portuguese", "Hindi", "Italian", "Korean", "Turkish", "Persian", "Dutch" };
            cmb_language.Items.Clear();
            cmb_language.Items.AddRange(languages);

            string[] category = {
                    "علمی و آموزشی",
                    "داستانی و رمان",
                    "تاریخی",
                    "ادبی",
                    "آموزش مهارت",
                    "خودشناسی و روانشناسی",
                    "مذهبی",
                    "کودک و نوجوان",
                    "هنری",
                    "جغرافیایی",
                    "بیوگرافی",
                    "فلسفی",
                    "جنایی و معمایی",
                    "علمی تخیلی"
                };
            cmb_category.Items.Clear();
            cmb_category .Items.AddRange(category);
            cmb_pulisheryear.Items.Clear();
            for (int year = 1370; year <= 1405; year++)

                cmb_pulisheryear.Items.Add(year.ToString());
            }
        public static List<IBook> Book = new List<IBook>();
        private void AddForm_Load(object sender, EventArgs e)
        {
            if (Book == null || Book.Count == 0)
            {
                Book = new List<IBook>();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_title.Text.Length == 0 && txt_author.Text.Length == 0 && txt_isbn.Text.Length == 0)
            {
                MessageBox.Show("لطفا پر کنید ");
                panel1.BackColor = Color.Firebrick;
                panel2.BackColor = Color.Firebrick;
                panel3.BackColor = Color.Firebrick;
                label1.BackColor = Color.LightGray;
                label2.BackColor = Color.LightGray;
                label4.BackColor = Color.LightGray;
            }

            IBook book = new IBook(txt_title.Text, txt_author.Text, txt_isbn.Text);
            book.Language = cmb_language.SelectedItem?.ToString() ?? "خالی";
            book.Category = cmb_category.SelectedItem?.ToString() ?? "خالی";
            book.PublishYear = cmb_pulisheryear.SelectedItem?.ToString() ?? "خالی";

            int Countbook = Book.Count;
            int id;
            if (Book.Count > 0)
                id = Book[Countbook - 1].Id;
            else
                id = 0;

            id++;

            book.Id = id;
            Book.Add(book);
            MessageBox.Show("اطلاعات ذخیره شد");

        }
    }
}
