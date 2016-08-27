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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        // ////////////////////////////////////////////// 数据库查询函数
        public string Query(string _queryStr)
        {
            try
            {
                string transmitStr = null;
                int i = 0;

                SqlConnection myConnection = new SqlConnection("Server=localhost;database=PowerSystem;Integrated Security=True");
                myConnection.Open();

                SqlDataReader myRead;
                SqlCommand myCommand = new SqlCommand(_queryStr, myConnection);

                myRead = myCommand.ExecuteReader();
                while (myRead.Read())
                {
                    transmitStr += myRead[i];
                    i++;
                }
                myRead.Close();
                myConnection.Close();
                return transmitStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //    //////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            string queryResult=Query("select password from UserInfo where username='"+usernameTextBox.Text+"'");

            if (passwordTextBox.Text == queryResult)
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("密码或用户名错误！");
                passwordTextBox.Text = "";
                usernameTextBox.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
            this.Close();
        }
    }
}
