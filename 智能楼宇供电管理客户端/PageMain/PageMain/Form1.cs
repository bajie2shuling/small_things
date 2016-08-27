using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;//需要添加的命名空间
using System.Data.SqlClient;
using About2;


namespace PageMain
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        // ///////////////////////////////////////////////////////////

        public string InitQuery(string str)  //初始化查询
        {
            string selectResult = null;
            int i = 0;

            SqlConnection connection = new SqlConnection("Server=localhost;database=PowerSystem;Integrated Security=True");
            connection.Open();
            SqlDataAdapter initCmd = new SqlDataAdapter("select * from " + str + "", connection);
            DataSet ds = new DataSet();
            initCmd.Fill(ds, "" + str + "");

            for (i = 0; i < ds.Tables["" + str + ""].Rows.Count; i++)
            {
                selectResult += (ds.Tables["" + str + ""].Rows[i]["ClassroomID"].ToString() + ds.Tables["" + str + ""].Rows[i]["LightSwitchState"].ToString() + '\n');
                selectResult += (ds.Tables["" + str + ""].Rows[i]["ClassroomID"].ToString() + ds.Tables["" + str + ""].Rows[i]["FannerSwitchState"].ToString() + '\n');
                selectResult += (ds.Tables["" + str + ""].Rows[i]["ClassroomID"].ToString() + ds.Tables["" + str + ""].Rows[i]["MediaSwitchState"].ToString() + '\n');
            }
            connection.Close();
            ds.Clear();
            return selectResult;
        }
        ///////////////////////////////////////////////////////////////////////

        string time = null;

        private void transmitTimer_Tick(object sender, EventArgs e)             //时钟查询函数
        {
            time = System.DateTime.Now.ToString("HH:mm");

            if (time == "18:35")
            {
                string resultMorning = InitQuery("InitClassroomMorning");
                Transmit(resultMorning);
            }
            else if (time == "18:36")
            {
                string resultNoon = InitQuery("InitClassroomNoon");
                Transmit(resultNoon);
            }
            else if (time == "18:37")
            {
                string resultEvening = InitQuery("InitClassroomEvening");
                Transmit(resultEvening);
            }
        }
        //  ////////////////////////////////
        private void Form1_Load(object sender, EventArgs e)
        {
            楼层二Panel.Visible = false;
            楼层一Panel.Visible = true;
            楼层三panel.Visible = false;
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //    //////////////////////////////////////////////  串口发送函数
        
        public void Transmit(String _transmitStr)   
        {
            try
            {
                SerialPort serialPort1 = new SerialPort();

                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                byte[] data = Encoding.Unicode.GetBytes(_transmitStr);
                string str = Convert.ToBase64String(data);
                serialPort1.WriteLine(str);
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void 楼层一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            楼层二Panel.Visible = false;
            楼层一Panel.Visible = true;
            楼层三panel.Visible = false;
        }

        private void 楼层二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            楼层一Panel.Visible = false;
            楼层二Panel.Visible = true;
            // 楼层二Panel.BringToFront();
            楼层三panel.Visible = false;
        }

        private void 楼层三ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            楼层一Panel.Visible = false;
            楼层二Panel.Visible = false;
            楼层三panel.Visible = true;
        }
       // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // /////////////
        // ////////////////一楼
        private void floor1PowerButton_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼总开关";
        }

        private void floor1PowerButton_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼总开关";
        }

        private void floor1PowerButton_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        private void floor1PowerButton_Click(object sender, EventArgs e)
        {
            if (floor1PowerLabel.Text == "Open")
            {
                floor1PowerLabel.Text = "Close";
                floor1PowerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("01:1111111Open");
            }
            else
            {
                floor1PowerLabel.Text = "Open";
                floor1PowerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("01:1111111Clos");
            }

        }
        //////////////////////////////////////////////////////////////
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室01";
            textBox3.Text = "灯";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室01";
            textBox3.Text = "灯";
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Open")
            {
                button1.Text = "Close";
                button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("01-01LightOpen");
            }
            else
            {
                button1.Text = "Open";
                button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("01-01LightClos");
            }
        }

        //////////////////////////////////////////////////////////////////

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室02";
            textBox3.Text = "灯";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室02";
            textBox3.Text = "灯";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Open")
            {
                button2.Text = "Close";
                button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("01-02LightOpen");
            }
            else
            {
                button2.Text = "Open";
                button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("01-02LightClos");
            }
        }

        ///////////////////////////////////////////

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室03";
            textBox3.Text = "灯";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室03";
            textBox3.Text = "灯";
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Open")
            {

                button3.Text = "Close";
                button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {

                button3.Text = "Open";
                button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        ///////////////////////////
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室04";
            textBox3.Text = "灯";
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室04";
            textBox3.Text = "灯";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Open")
            {
                button4.Text = "Close";
                button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button4.Text = "Open";
                button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }



        //////////////////////////////////////////
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室05";
            textBox3.Text = "灯";
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室05";
            textBox3.Text = "灯";
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Open")
            {
                button5.Text = "Close";
                button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button5.Text = "Open";
                button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }


        // /////////////////////////////////
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室01";
            textBox3.Text = "电扇";
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室01";
            textBox3.Text = "电扇";
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Open")
            {

                button6.Text = "Close";
                button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("01-01FanneOpen");
            }
            else
            {
                button6.Text = "Open";
                button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("01-01FanneClos");
            }
        }
        // /////////////////////////////////////////////////
        private void button7_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室02";
            textBox3.Text = "电扇";
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室02";
            textBox3.Text = "电扇";
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Open")
            {

                button7.Text = "Close";
                button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("01-02FanneOpen");
            }
            else
            {
                button7.Text = "Open";
                button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("01-02FanneClos");
            }
        }
        // ///////////////////////////////////
        private void button8_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室03";
            textBox3.Text = "电扇";
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室03";
            textBox3.Text = "电扇";
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Open")
            {
                button8.Text = "Close";
                button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button8.Text = "Open";
                button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // //////////////////////////////////////////
        private void button9_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室04";
            textBox3.Text = "电扇";
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室04";
            textBox3.Text = "电扇";
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "Open")
            {
                button9.Text = "Close";
                button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button9.Text = "Open";
                button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // ///////////////////////////////////////
        private void button10_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室05";
            textBox3.Text = "电扇";
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室05";
            textBox3.Text = "电扇";
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "Open")
            {
                button10.Text = "Close";
                button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button10.Text = "Open";
                button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        //   //////////////////////////////////////////
        private void button11_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室01";
            textBox3.Text = "多媒体";
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室01";
            textBox3.Text = "多媒体";
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (button11.Text == "Open")
            {

                button11.Text = "Close";
                button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("01-01MediaOpen");
            }
            else
            {

                button11.Text = "Open";
                button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("01-01MediaClos");
            }
        }
        // ///////////////////////////////////////////////////////////////

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室02";
            textBox3.Text = "多媒体";
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室02";
            textBox3.Text = "多媒体";
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (button12.Text == "Open")
            {

                button12.Text = "Close";
                button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("01-02MediaOpen");
            }
            else
            {

                button12.Text = "Open";
                button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("01-02MediaClos");
            }
        }
        // ////////////////////////////////////////////////////////////////

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室03";
            textBox3.Text = "多媒体";
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室03";
            textBox3.Text = "多媒体";
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text == "Open")
            {

                button13.Text = "Close";
                button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {

                button13.Text = "Open";
                button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // //////////////////////////////////////////////////////////////

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室04";
            textBox3.Text = "多媒体";
        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室04";
            textBox3.Text = "多媒体";
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (button14.Text == "Open")
            {

                button14.Text = "Close";
                button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {

                button14.Text = "Open";
                button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // //////////////////////////////////////////////////////////
        private void button15_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室05";
            textBox3.Text = "多媒体";
        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "一楼";
            textBox2.Text = "教室05";
            textBox3.Text = "多媒体";
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text == "Open")
            {

                button15.Text = "Close";
                button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {

                button15.Text = "Open";
                button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
       // ////////////////
        // //////////////////
        // ///////////////////////
        // ////////////////////////////
        // ///////////////////////////////////二楼
        private void floor2PowerButton_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼总开关";
        }

        private void floor2PowerButton_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼总开关";
        }

        private void floor2PowerButton_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        private void floor2PowerButton_Click(object sender, EventArgs e)
        {
            if (floor2PowerLabel.Text == "Open")
            {
                floor2PowerLabel.Text = "Close";
                floor2PowerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("02:1111111Open");
            }
            else
            {
                floor2PowerLabel.Text = "Open";
                floor2PowerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("02:1111111Clos");
            }
        }
        //    //   /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button50_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室01";
            textBox3.Text = "灯";
        }

        private void button50_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室01";
            textBox3.Text = "灯";
        }

        private void button50_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button50_Click(object sender, EventArgs e)
        {
            if (button50.Text == "Open")
            {
                button50.Text = "Close";
                button50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("02-01LightOpen");
            }
            else
            {
                button50.Text = "Open";
                button50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("02-01LightClos");
            }
        }
        // ////////////////////////////////////////////////////////////////////
        private void button49_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室02";
            textBox3.Text = "灯";
        }

        private void button49_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室02";
            textBox3.Text = "灯";
        }

        private void button49_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button49_Click(object sender, EventArgs e)
        {
            if (button49.Text == "Open")
            {
                button49.Text = "Close";
                button49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("02-02LightOpen");
            }
            else
            {

                button49.Text = "Open";
                button49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("02-02LightClos");
            }
        }
        // //////////////////////////////////////////////////////////
        private void button48_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室03";
            textBox3.Text = "灯";
        }

        private void button48_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室03";
            textBox3.Text = "灯";
        }

        private void button48_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button48_Click(object sender, EventArgs e)
        {
            if (button48.Text == "Open")
            {
                button48.Text = "Close";
                button48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button48.Text = "Open";
                button48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // ////////////////////////////////////////////////////

        private void button47_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室04";
            textBox3.Text = "灯";
        }

        private void button47_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室04";
            textBox3.Text = "灯";
        }

        private void button47_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button47_Click(object sender, EventArgs e)
        {
            if (button47.Text == "Open")
            {
                button47.Text = "Close";
                button47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button47.Text = "Open";
                button47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // //////////////////////////////////////////////////

        private void button46_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室05";
            textBox3.Text = "灯";
        }

        private void button46_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室05";
            textBox3.Text = "灯";
        }

        private void button46_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button46_Click(object sender, EventArgs e)
        {
            if (button46.Text == "Open")
            {
                button46.Text = "Close";
                button46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button46.Text = "Open";
                button46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // ///////////////////////////////////////////////////////////////
        private void button45_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室01";
            textBox3.Text = "电扇";
        }

        private void button45_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室01";
            textBox3.Text = "电扇";
        }

        private void button45_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button45_Click(object sender, EventArgs e)
        {
            if (button45.Text == "Open")
            {
                button45.Text = "Close";
                button45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("02-01FanneOpen");
            }
            else
            {
                button45.Text = "Open";
                button45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("02-01FanneClos");
            }
        }
        // //////////////////////////////////////////////////////////////////
        private void button44_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室02";
            textBox3.Text = "电扇";
        }

        private void button44_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室02";
            textBox3.Text = "电扇";
        }

        private void button44_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button44_Click(object sender, EventArgs e)
        {
            if (button44.Text == "Open")
            {
                button44.Text = "Close";
                button44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("02-02FanneOpen");
            }
            else
            {
                button44.Text = "Open";
                button44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("02-02FanneClos");
            }
        }
        // ///////////////////////////////////////////////////////////
        private void button43_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室03";
            textBox3.Text = "电扇";
        }

        private void button43_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室03";
            textBox3.Text = "电扇";
        }

        private void button43_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button43_Click(object sender, EventArgs e)
        {
            if (button43.Text == "Open")
            {
                button43.Text = "Close";
                button43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button43.Text = "Open";
                button43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // /////////////////////////////////////////////////////////////////////
        private void button42_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室04";
            textBox3.Text = "电扇";
        }

        private void button42_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室04";
            textBox3.Text = "电扇";
        }

        private void button42_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button42_Click(object sender, EventArgs e)
        {
            if (button42.Text == "Open")
            {
                button42.Text = "Close";
                button42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button42.Text = "Open";
                button42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // /////////////////////////////////////////////////
        private void button41_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室05";
            textBox3.Text = "电扇";
        }

        private void button41_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室05";
            textBox3.Text = "电扇";
        }

        private void button41_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
        private void button41_Click(object sender, EventArgs e)
        {
            if (button41.Text == "Open")
            {
                button41.Text = "Close";
                button41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button41.Text = "Open";
                button41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // /////////////////////////////////////////////////////////////////////
        private void button40_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室01";
            textBox3.Text = "多媒体";
        }

        private void button40_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室01";
            textBox3.Text = "多媒体";
        }

        private void button40_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (button40.Text == "Open")
            {
                button40.Text = "Close";
                button40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("02-01MediaOpen");
            }
            else
            {
                button40.Text = "Open";
                button40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("02-01MediaClos");
            }
        }
        // ///////////////////////////////////////////////////////////////////////////////////
        private void button39_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室02";
            textBox3.Text = "多媒体";
        }

        private void button39_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室02";
            textBox3.Text = "多媒体";
        }

        private void button39_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (button39.Text == "Open")
            {
                button39.Text = "Close";
                button39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("02-02MediaOpen");
            }
            else
            {
                button39.Text = "Open";
                button39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("02-02MediaClos");
            }
        }
        // /////////////////////////////////////////////////////////////////////////////////////////
        private void button38_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室03";
            textBox3.Text = "多媒体";
        }

        private void button38_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室03";
            textBox3.Text = "多媒体";
        }

        private void button38_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (button38.Text == "Open")
            {
                button38.Text = "Close";
                button38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button38.Text = "Open";
                button38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // //////////////////////////////////////////////////////////////////////
        private void button37_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室04";
            textBox3.Text = "多媒体";
        }

        private void button37_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室04";
            textBox3.Text = "多媒体";
        }

        private void button37_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (button37.Text == "Open")
            {
                button37.Text = "Close";
                button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button37.Text = "Open";
                button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }
        // ///////////////////////////////////////////////////////////////////////////////////
        private void button36_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室05";
            textBox3.Text = "多媒体";
        }

        private void button36_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "二楼";
            textBox2.Text = "教室05";
            textBox3.Text = "多媒体";
        }

        private void button36_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (button36.Text == "Open")
            {
                button36.Text = "Close";
                button36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button36.Text = "Open";
                button36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        // /////////////////////////////////
        // 
        // ////////////////////////
        // ////////////////////////
        // //////////////////////////////    三楼

        private void floor3PowerButton_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "三楼总开关";
        }

        private void floor3PowerButton_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "三楼总开关";
        }

        private void floor3PowerButton_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        private void floor3PowerButton_Click(object sender, EventArgs e)
        {
            if (floor3PowerLabel.Text == "Open")
            {
                floor3PowerLabel.Text = "Close";
                floor3PowerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                Transmit("03:1111111Open");
            }
            else
            {
                floor3PowerLabel.Text = "Open";
                floor3PowerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                Transmit("03:1111111Clos");
            }
        }
       // ////////////////////////////////////////////////////////////////////////
        private void button75_Click(object sender, EventArgs e)
        {
            if (button75.Text == "Open")
            {
                button75.Text = "Close";
                button75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button75.Text = "Open";
                button75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            if (button74.Text == "Open")
            {
                button74.Text = "Close";
                button74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button74.Text = "Open";
                button74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            if (button73.Text == "Open")
            {
                button73.Text = "Close";
                button73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button73.Text = "Open";
                button73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button72_Click(object sender, EventArgs e)
        {
            if (button72.Text == "Open")
            {
                button72.Text = "Close";
                button72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button72.Text = "Open";
                button72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button71_Click(object sender, EventArgs e)
        {
            if (button71.Text == "Open")
            {
                button71.Text = "Close";
                button71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button71.Text = "Open";
                button71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button70_Click(object sender, EventArgs e)
        {
            if (button70.Text == "Open")
            {
                button70.Text = "Close";
                button70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button70.Text = "Open";
                button70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button69_Click(object sender, EventArgs e)
        {
            if (button69.Text == "Open")
            {
                button69.Text = "Close";
                button69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button69.Text = "Open";
                button69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            if (button68.Text == "Open")
            {
                button68.Text = "Close";
                button68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button68.Text = "Open";
                button68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if (button67.Text == "Open")
            {
                button67.Text = "Close";
                button67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button67.Text = "Open";
                button67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {
            if (button66.Text == "Open")
            {
                button66.Text = "Close";
                button66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            }
            else
            {
                button66.Text = "Open";
                button66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutDialog aboutDialog1 = new aboutDialog();
            aboutDialog1.ShowDialog();
        }

        private void 管理ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            // Font font = new Font("微软雅黑", 18, FontStyle.Regular);
            管理ToolStripMenuItem.Text = "电力管理";
        }

        private void 管理ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            管理ToolStripMenuItem.Text = " ";
        }

        private void 工具ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            工具ToolStripMenuItem.Text = "工具";
        }

        private void 工具ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            工具ToolStripMenuItem.Text = " ";
        }

        private void 修改密码ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            修改密码ToolStripMenuItem.Text = "用户管理";
        }

        private void 修改密码ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            修改密码ToolStripMenuItem.Text = " ";
        }

        private void 视图ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            视图ToolStripMenuItem.Text = "视图";
        }

        private void 视图ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            视图ToolStripMenuItem.Text = " ";
        }

        private void 帮助ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            帮助ToolStripMenuItem.Text = "帮助";
        }

        private void 帮助ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            帮助ToolStripMenuItem.Text = " ";
        }

        private void 退出ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            退出ToolStripMenuItem.Text = "退出";
        }

        private void 退出ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            退出ToolStripMenuItem.Text = " ";
        }
// //////////////////////////////////////////////////////////////////////////////

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close close1 = new Close();
            close1.ShowDialog(this);
        }

// ///////////////////////////////////////////////////////////////////////////////////
        private void 更改密码toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangePassword changpassword = new ChangePassword();
            changpassword.ShowDialog();
        }

        private void 注册toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



 




 

 
 
    }
}
