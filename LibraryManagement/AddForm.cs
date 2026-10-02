using BLL_Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class AddForm : Form
    {
        private readonly int _id;
        private readonly bool _isEdit;
        private readonly string _database;
        private BLL_Service _bookService; // استفاده از سرویس لایه BLL

        private static readonly object[] Languages = new object[] {
            "Persian", "English", "Arabic", "French", "German",
            "Russian", "Chinese", "Spanish", "Turkish", "Italian",
            "Japanese", "Korean", "Portuguese", "Hindi", "Dutch"
        };

        private static readonly object[] Categories = new object[] {
            "علمی و آموزشی", "داستانی و رمان", "تاریخی", "ادبی", "آموزش مهارت",
            "خودشناسی و روانشناسی", "مذهبی", "کودک و نوجوان", "هنری", "جغرافیایی",
            "بیوگرافی", "فلسفی", "جنایی و معمایی", "علمی تخیلی"
        };

        public AddForm(string database, int id = 0, bool edit = false)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            _database = database;
            _id = id;
            _isEdit = edit || (id > 0);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            // مقداردهی سرویس BLL بر اساس نوع دیتابیس
            _bookService = new BLL_Service(_database);

            // پر کردن کامبوباکس‌ها
            cmb_language.BeginUpdate();
            cmb_category.BeginUpdate();
            cmb_pulisheryear.BeginUpdate();

            cmb_language.Items.AddRange(Languages);
            cmb_category.Items.AddRange(Categories);

            object[] years = new object[36];
            for (int i = 0, y = 1370; y <= 1405; i++, y++)
                years[i] = y.ToString();
            cmb_pulisheryear.Items.AddRange(years);

            cmb_language.EndUpdate();
            cmb_category.EndUpdate();
            cmb_pulisheryear.EndUpdate();

            cmb_language.SelectedIndex = 0;
            cmb_category.SelectedIndex = 0;
            cmb_pulisheryear.SelectedIndex = 0;

            if (_isEdit && _id > 0)
            {
                this.Text = "ویرایش کتاب";
                btn_add.Text = "ویرایش";

                try
                {
                    IBook book = _bookService.GetBookById(_id);
                    if (book != null)
                    {
                        txt_title.Text = book.Title ?? string.Empty;
                        txt_author.Text = book.Author ?? string.Empty;
                        txt_isbn.Text = book.ISBN ?? string.Empty;

                        if (!string.IsNullOrEmpty(book.Language))
                            cmb_language.Text = book.Language;

                        if (!string.IsNullOrEmpty(book.Category))
                            cmb_category.Text = book.Category;

                        if (!string.IsNullOrEmpty(book.PublishYear))
                            cmb_pulisheryear.Text = book.PublishYear;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا در دریافت اطلاعات: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.Text = "افزودن کتاب جدید";
                btn_add.Text = "افزودن";
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string title = txt_title.Text.Trim();
            string author = txt_author.Text.Trim();
            string isbn = txt_isbn.Text.Trim();

            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;

            try
            {
                // اعتبارسنجی از طریق BLL
                string[] errors = _bookService.Validation(title, author, isbn, _id);

                if (errors != null && errors.Length > 0)
                {
                    foreach (string error in errors)
                    {
                        switch (error)
                        {
                            case "Title":
                                MessageBox.Show("نام اثر را وارد کنید.", "اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                panel3.BackColor = Color.Firebrick;
                                return;
                            case "Author":
                                MessageBox.Show("نام نویسنده را وارد کنید.", "اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                panel2.BackColor = Color.Firebrick;
                                return;
                            case "ISBN":
                                MessageBox.Show("کد 13 رقمی شابک را وارد کنید.", "اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                panel1.BackColor = Color.Firebrick;
                                return;
                            case "IsbnAgain":
                                MessageBox.Show("این شابک قبلاً ثبت شده است.", "اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                panel1.BackColor = Color.Firebrick;
                                return;
                        }
                    }
                    return;
                }

                IBook bookData = new IBook(title, author, isbn)
                {
                    Id = _id,
                    Language = string.IsNullOrWhiteSpace(cmb_language.Text) ? "خالی" : cmb_language.Text.Trim(),
                    Category = string.IsNullOrWhiteSpace(cmb_category.Text) ? "خالی" : cmb_category.Text.Trim(),
                    PublishYear = string.IsNullOrWhiteSpace(cmb_pulisheryear.Text) ? "خالی" : cmb_pulisheryear.Text.Trim()
                };

                if (_isEdit)
                {
                    bool success = _bookService.UpdateBook(bookData);
                    if (success)
                    {
                        MessageBox.Show("کتاب با موفقیت ویرایش شد.", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("خطا در ویرایش کتاب.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _bookService.AddBook(bookData);
                    MessageBox.Show("کتاب با موفقیت افزوده شد.", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطای غیرمنتظره:\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
