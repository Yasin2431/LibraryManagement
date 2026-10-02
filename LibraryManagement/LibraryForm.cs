using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class LibraryForm : Form
    {
        private readonly string _database;
        private readonly IBookRepository _repository;
        private List<IBook> _cachedBooks = new List<IBook>();

        // حذف کامل پرش و لگ‌های رندر UI و فرم در ویندوز فرمز
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        public LibraryForm(string database)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            // فعال‌سازی DoubleBuffered برای DataGridView جهت روان‌سازی کامل اسکرول
            EnableDoubleBuffer(dgv_book);

            dgv_book.AutoGenerateColumns = false;
            _database = database;

            // انتخاب نوع دیتابیس
            if (_database == "SQL")
            {
                _repository = new SqlBookRepository();
            }
            else
            {
                _repository = new InMemoryBookRepository();
            }

            InitButtonStyles();
        }

        private void EnableDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }

        private void InitButtonStyles()
        {
            if (dgv_book.Columns["colEdit"] is DataGridViewButtonColumn colEdit)
            {
                colEdit.FlatStyle = FlatStyle.Flat;
                colEdit.DefaultCellStyle.BackColor = Color.FromArgb(255, 193, 7);
                colEdit.DefaultCellStyle.ForeColor = Color.Black;
                colEdit.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 168, 0);
                colEdit.DefaultCellStyle.SelectionForeColor = Color.Black;
                colEdit.Width = 65;
                colEdit.DefaultCellStyle.Padding = new Padding(4, 3, 4, 3);
            }

            if (dgv_book.Columns["colDelete"] is DataGridViewButtonColumn colDelete)
            {
                colDelete.FlatStyle = FlatStyle.Flat;
                colDelete.DefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
                colDelete.DefaultCellStyle.ForeColor = Color.White;
                colDelete.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 35, 51);
                colDelete.DefaultCellStyle.SelectionForeColor = Color.White;
                colDelete.Width = 65;
                colDelete.DefaultCellStyle.Padding = new Padding(4, 3, 4, 3);
            }
        }

        // بارگذاری و کش کردن داده‌ها
        private void LoadBooks()
        {
            try
            {
                _cachedBooks = _repository.GetAllBooks() ?? new List<IBook>();
            }
            catch (Exception ex)
            {
                _cachedBooks = new List<IBook>();
                MessageBox.Show("خطا در دریافت لیست کتاب‌ها: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyFilterAndBind();
        }

        // اعمال فیلتر سرچ و نمایش در گرید
        private void ApplyFilterAndBind()
        {
            string searchText = txt_search.Text?.Trim();
            List<IBook> filteredList = SearchBook(searchText);

            dgv_book.DataSource = null;
            dgv_book.DataSource = filteredList;
        }

        public List<IBook> SearchBook(string text)
        {
            if (_cachedBooks == null)
                return new List<IBook>();

            if (string.IsNullOrWhiteSpace(text))
                return _cachedBooks;

            text = text.Trim().ToLower();

            return _cachedBooks.Where(x =>
                (!string.IsNullOrEmpty(x.Title) && x.Title.ToLower().Contains(text)) ||
                (!string.IsNullOrEmpty(x.Author) && x.Author.ToLower().Contains(text)) ||
                (!string.IsNullOrEmpty(x.ISBN) && x.ISBN.Contains(text))
            ).ToList();
        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (AddForm addForm = new AddForm(_database))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
        }

        private void dgv_book_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // عملیات حذف
            if (dgv_book.Columns["colDelete"] != null && e.ColumnIndex == dgv_book.Columns["colDelete"].Index)
            {
                if (dgv_book.Rows[e.RowIndex].Cells["Id"].Value is int id)
                {
                    DialogResult result = MessageBox.Show(
                        "آیا از حذف این کتاب مطمئن هستید؟",
                        "حذف کتاب",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _repository.RemoveBook(id);
                            LoadBooks();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("خطا در حذف کتاب: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                return;
            }

            // عملیات ویرایش
            if (dgv_book.Columns["colEdit"] != null && e.ColumnIndex == dgv_book.Columns["colEdit"].Index)
            {
                if (dgv_book.Rows[e.RowIndex].Cells["Id"].Value is int id)
                {
                    using (AddForm editForm = new AddForm(_database, id, true))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadBooks();
                        }
                    }
                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = string.IsNullOrEmpty(txt_search.Text);
            ApplyFilterAndBind();
        }

        private void dgv_book_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
