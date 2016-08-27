using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;                      /////////////////////  添加命名空间
using System.Text.RegularExpressions;       /////////////////////  添加命名空间
using System.Data.SqlClient;                /////////////////////  添加命名空间

namespace Test
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ComcomboBox1.SelectedIndex = 3;
            bpscomboBox2.SelectedIndex = 7;
        }

        public void Write(string sql_str)
        {
            SqlConnection writeCon = new SqlConnection("Server=localhost;database=procject;Integrated Security=True");
            writeCon.Open();
            SqlCommand writeCmd = new SqlCommand(sql_str, writeCon);
            writeCmd.ExecuteNonQuery();
            writeCon.Close();
        }
        private void OpenCOMbutton_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort2.PortName = ComcomboBox1.SelectedItem.ToString();
                serialPort2.BaudRate = Convert.ToInt32(bpscomboBox2.SelectedItem.ToString());
                serialPort2.Open();
                MessageBox.Show("打开成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseCOMbutton_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort2.Close();
                MessageBox.Show("关闭成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Clearbutton_Click(object sender, EventArgs e)
        {
            timetextBox.Text= "";
            temptextBox.Text = "";
            gastextBox.Text = "";
        }

        private void WRbutton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Encoding.Unicode.GetBytes("!@@#$#%$%$$$%Wan1111*&*^%^%KKjk ");
                string str = Convert.ToBase64String(data);
                serialPort2.WriteLine(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ESCbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
                SerialPort sp = (SerialPort)sender;
                String str1 = sp.ReadExisting();
                int index = str1.IndexOf("WD");
                if (index > -1)
                {
                    Regex expressions1 = new Regex(@"WD+(\d\d)");
                    Match match1 = expressions1.Match(str1);

                    String str2 = match1.ToString();
                    String time_str = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss");
                    timetextBox.Text = timetextBox.Text + time_str + "\r\n";
                    Regex expressions2 = new Regex(@"\d\d");
                    Match match2 = expressions2.Match(str2);
                    temptextBox.Text = temptextBox.Text + match2.ToString() + "\r\n";
                }
                else
                {
                    Regex expressions1 = new Regex(@"QT+(\d\d\d)");
                    Match match1 = expressions1.Match(str1);
                    String str3 = match1.ToString();
                    Regex expressions2 = new Regex(@"\d\d\d");
                    Match match3 = expressions2.Match(str3);
                    gastextBox.Text = gastextBox.Text + match3.ToString() + "\r\n";

                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection clearCon = new SqlConnection("Server=localhost;database=procject;Integrated Security=True");
            clearCon.Open();
            SqlCommand writeCmd = new SqlCommand("delete  from basicinfo", clearCon);
            writeCmd.ExecuteNonQuery();
            clearCon.Close();
            MessageBox.Show("清空表单成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i < gastextBox.Lines.Length; i++)
            {
                String time = timetextBox.Lines[i];
                String temp = temptextBox.Lines[i];
                String gas = gastextBox.Lines[i];
                Write("insert into basicinfo(时间,温度,气体) values('" + time + "','" + temp + "','" + gas + "')");
            }
            MessageBox.Show("匹配数据成功！");
        }



        


    }
}
