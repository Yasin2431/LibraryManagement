using BLL_Library;
using DAL_Library;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class AddUserForm : Form
    {
        string _databace;
        string _type;
        public AddUserForm(string databace, string type)
        {
            InitializeComponent();
            _databace = databace;
            _type = type;
            _userservice = new BLL_UserService(_databace, _type);
        }
        BLL_UserService _userservice;
        User user = new User();
        private void AddUserForm_Load(object sender, EventArgs e)
        {
           
        }
        

        private void btn_add_Click(object sender, EventArgs e)
        {
            string firstname = txt_firstname.Text.Trim();
            string lastname = txt_lastname.Text.Trim();
            string nationalcode = txt_nationalnode.Text.Trim();
            string phonenumber = txt_phonenumber.Text.Trim();
            

            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel5.BackColor = Color.White;
        }
        private byte[]? pictuerboxtobyte(PictureBox pictuerbox) 
        {
            if (pictuerbox == null) { return null; }
            using var stram= new MemoryStream();
            pictuerbox.Image.Save(stram, ImageFormat.Jpeg);
            return stram.ToArray();
        
        }

        private void validation(string firstname, string lastname, string nationalcode, string phonenumber,PictureBox pictureBox1 )
        {
            byte[] photo = pictuerboxtobyte(pictureBox1);
             user =new User(firstname, lastname, nationalcode, phonenumber, photo);
            _userservice.AddUser()
        }






    }
}
