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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            if (NewPasswordTextBox.Text != confirmNewPasswordTextBox.Text)
            {
                MessageBox.Show("两次输入的新密码不一致！");
            }
            else
            {
                SqlConnection myConnection = new SqlConnection("Server=localhost;database=PowerSystem;Integrated Security=True");
                myConnection.Open();
                SqlDataAdapter myCommand = new SqlDataAdapter("select * from UserInfo where username='"+usernameTextBox.Text+"'", myConnection);
                DataSet ds=new DataSet();
                myCommand.Fill(ds,"UserInfo");
                int rows = ds.Tables[0].Rows.Count;

                if (rows == 0)
                {
                    myConnection.Close();
                    ds.Clear();
                    MessageBox.Show("您输入的用户不存在！");
                }

                else
                {
                     SqlConnection myConnection1 = new SqlConnection("Server=localhost;database=PowerSystem;Integrated Security=True");
                     myConnection1.Open();
                     SqlDataAdapter myCommand1 = new SqlDataAdapter("select password from UserInfo where username='"+usernameTextBox.Text+"'", myConnection1);
                     DataSet ds1 = new DataSet();
                     myCommand1.Fill(ds1,"UserInfo");
                     String password = ds1.Tables["UserInfo"].Rows[0]["password"].ToString();

                     if(oldPasswordTextBox.Text!=password)
                     {
                         myConnection1.Close();
                         ds1.Clear();
                         MessageBox.Show("原密码错误！");
                     }
                     else
                     {
                        SqlConnection changeCon = new SqlConnection("Server=localhost;database=PowerSystem;Integrated Security=True");
                        changeCon.Open();
                        SqlCommand changeCmd=new SqlCommand("update UserInfo set password='"+NewPasswordTextBox.Text+"' where username='"+usernameTextBox.Text+"'",changeCon);
                        changeCmd.ExecuteNonQuery();
                        changeCon.Close();
                        MessageBox.Show("密码修改成功！");
                        this.Close();
                     }
                }
            }
        }
    }
}