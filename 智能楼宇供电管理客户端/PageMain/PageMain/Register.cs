using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace PageMain
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (passwordRegisterTextBox.Text != confirmRegisterTextBox.Text)
            {
                MessageBox.Show("两次输入的密码不一致！");
            }
            else
            {
                SqlConnection myConnection = new SqlConnection("Server=localhost;database=PowerSystem;Integrated Security=True");
                myConnection.Open();
                SqlDataAdapter myCommand = new SqlDataAdapter("select * from UserInfo where username='" + usernameRegisterTextBox.Text + "'", myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "UserInfo");
                int rows = ds.Tables[0].Rows.Count;

                if (rows > 0)
                {
                    myConnection.Close();
                    ds.Clear();
                    MessageBox.Show("用户名已存在！");
                    usernameRegisterTextBox.Text = "";
                }
                else
                {
                    SqlConnection changeCon = new SqlConnection("Server=localhost;database=PowerSystem;Integrated Security=True");
                    changeCon.Open();
                    SqlCommand changeCmd = new SqlCommand("insert into UserInfo(username,password) values('"+usernameRegisterTextBox.Text+"','"+passwordRegisterTextBox.Text+"')", changeCon);
                    changeCmd.ExecuteNonQuery();
                    changeCon.Close();
                    MessageBox.Show("注册成功！");
                    Form1 mainForm = new Form1();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Hide();
                }
            }
        }

    }
}
