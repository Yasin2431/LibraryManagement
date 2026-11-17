using BLL_Library;
using DAL_Library;
using LibraryManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class UserForm : Form
    {
        private readonly string _database;
        private readonly string _type;
        private readonly BLL_UserService _memberService;
        private List<Member> _cachedMember = new List<Member>();
        public UserForm(string database, string type)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            EnableDoubleBuffer(dgv_member);
            dgv_member.AutoGenerateColumns = false;
            _database = database;
            _type=type;
            _memberService = new BLL_UserService(_database, _type);
            InitButtonStyles();
        }
        private void InitButtonStyles()
        {
            if (dgv_member.Columns["colEdit"] is DataGridViewButtonColumn colEdit)
            {
                colEdit.FlatStyle = FlatStyle.Flat;
                colEdit.DefaultCellStyle.BackColor = Color.FromArgb(255, 193, 7);
                colEdit.DefaultCellStyle.ForeColor = Color.Black;
                colEdit.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 168, 0);
                colEdit.DefaultCellStyle.SelectionForeColor = Color.Black;
                colEdit.Width = 65;
                colEdit.DefaultCellStyle.Padding = new Padding(4, 3, 4, 3);
            }

            if (dgv_member.Columns["colDelete"] is DataGridViewButtonColumn colDelete)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            try
            {
                _cachedMember = _memberService.GetUsers() ?? new List<Member>();
            }
            catch (Exception ex)
            {
                _cachedMember = new List<Member>();
                MessageBox.Show("خطا در دریافت لیست کتاب‌ها: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
        private void EnableDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }
    }
}
