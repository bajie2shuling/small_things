namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ESCbutton = new System.Windows.Forms.Button();
            this.WRbutton = new System.Windows.Forms.Button();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.CloseCOMbutton = new System.Windows.Forms.Button();
            this.OpenCOMbutton = new System.Windows.Forms.Button();
            this.ComcomboBox1 = new System.Windows.Forms.ComboBox();
            this.bpscomboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.timelabel = new System.Windows.Forms.Label();
            this.gaslabel = new System.Windows.Forms.Label();
            this.tempabel = new System.Windows.Forms.Label();
            this.timetextBox = new System.Windows.Forms.TextBox();
            this.gastextBox = new System.Windows.Forms.TextBox();
            this.temptextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ESCbutton);
            this.panel1.Controls.Add(this.WRbutton);
            this.panel1.Controls.Add(this.Clearbutton);
            this.panel1.Controls.Add(this.CloseCOMbutton);
            this.panel1.Controls.Add(this.OpenCOMbutton);
            this.panel1.Controls.Add(this.ComcomboBox1);
            this.panel1.Controls.Add(this.bpscomboBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 517);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 408);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 26);
            this.button2.TabIndex = 12;
            this.button2.Text = "匹配数据到表单";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 362);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 26);
            this.button1.TabIndex = 11;
            this.button1.Text = "清空数据表单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ESCbutton
            // 
            this.ESCbutton.Location = new System.Drawing.Point(53, 301);
            this.ESCbutton.Margin = new System.Windows.Forms.Padding(4);
            this.ESCbutton.Name = "ESCbutton";
            this.ESCbutton.Size = new System.Drawing.Size(117, 41);
            this.ESCbutton.TabIndex = 10;
            this.ESCbutton.Text = "退出";
            this.ESCbutton.UseVisualStyleBackColor = true;
            this.ESCbutton.Click += new System.EventHandler(this.ESCbutton_Click);
            // 
            // WRbutton
            // 
            this.WRbutton.Location = new System.Drawing.Point(53, 454);
            this.WRbutton.Margin = new System.Windows.Forms.Padding(4);
            this.WRbutton.Name = "WRbutton";
            this.WRbutton.Size = new System.Drawing.Size(117, 26);
            this.WRbutton.TabIndex = 9;
            this.WRbutton.Text = "读写测试";
            this.WRbutton.UseVisualStyleBackColor = true;
            this.WRbutton.Click += new System.EventHandler(this.WRbutton_Click);
            // 
            // Clearbutton
            // 
            this.Clearbutton.Location = new System.Drawing.Point(53, 240);
            this.Clearbutton.Margin = new System.Windows.Forms.Padding(4);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(117, 41);
            this.Clearbutton.TabIndex = 8;
            this.Clearbutton.Text = "清空缓存区";
            this.Clearbutton.UseVisualStyleBackColor = true;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // CloseCOMbutton
            // 
            this.CloseCOMbutton.Location = new System.Drawing.Point(53, 178);
            this.CloseCOMbutton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseCOMbutton.Name = "CloseCOMbutton";
            this.CloseCOMbutton.Size = new System.Drawing.Size(117, 42);
            this.CloseCOMbutton.TabIndex = 7;
            this.CloseCOMbutton.Text = "关闭串口";
            this.CloseCOMbutton.UseVisualStyleBackColor = true;
            this.CloseCOMbutton.Click += new System.EventHandler(this.CloseCOMbutton_Click);
            // 
            // OpenCOMbutton
            // 
            this.OpenCOMbutton.Location = new System.Drawing.Point(53, 116);
            this.OpenCOMbutton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenCOMbutton.Name = "OpenCOMbutton";
            this.OpenCOMbutton.Size = new System.Drawing.Size(117, 42);
            this.OpenCOMbutton.TabIndex = 6;
            this.OpenCOMbutton.Text = "打开串口";
            this.OpenCOMbutton.UseVisualStyleBackColor = true;
            this.OpenCOMbutton.Click += new System.EventHandler(this.OpenCOMbutton_Click);
            // 
            // ComcomboBox1
            // 
            this.ComcomboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComcomboBox1.FormattingEnabled = true;
            this.ComcomboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15"});
            this.ComcomboBox1.Location = new System.Drawing.Point(93, 16);
            this.ComcomboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.ComcomboBox1.Name = "ComcomboBox1";
            this.ComcomboBox1.Size = new System.Drawing.Size(129, 28);
            this.ComcomboBox1.TabIndex = 3;
            // 
            // bpscomboBox2
            // 
            this.bpscomboBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bpscomboBox2.FormattingEnabled = true;
            this.bpscomboBox2.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.bpscomboBox2.Location = new System.Drawing.Point(93, 60);
            this.bpscomboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.bpscomboBox2.Name = "bpscomboBox2";
            this.bpscomboBox2.Size = new System.Drawing.Size(129, 28);
            this.bpscomboBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "  串口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "波特率：";
            // 
            // serialPort2
            // 
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.timelabel);
            this.panel2.Controls.Add(this.gaslabel);
            this.panel2.Controls.Add(this.tempabel);
            this.panel2.Controls.Add(this.timetextBox);
            this.panel2.Controls.Add(this.gastextBox);
            this.panel2.Controls.Add(this.temptextBox);
            this.panel2.Location = new System.Drawing.Point(231, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 516);
            this.panel2.TabIndex = 1;
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.BackColor = System.Drawing.Color.RosyBrown;
            this.timelabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timelabel.Location = new System.Drawing.Point(537, 30);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(50, 26);
            this.timelabel.TabIndex = 5;
            this.timelabel.Text = "时间";
            // 
            // gaslabel
            // 
            this.gaslabel.AutoSize = true;
            this.gaslabel.BackColor = System.Drawing.Color.RosyBrown;
            this.gaslabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gaslabel.Location = new System.Drawing.Point(312, 30);
            this.gaslabel.Name = "gaslabel";
            this.gaslabel.Size = new System.Drawing.Size(50, 26);
            this.gaslabel.TabIndex = 4;
            this.gaslabel.Text = "气体";
            // 
            // tempabel
            // 
            this.tempabel.AutoSize = true;
            this.tempabel.BackColor = System.Drawing.Color.RosyBrown;
            this.tempabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tempabel.Location = new System.Drawing.Point(99, 30);
            this.tempabel.Name = "tempabel";
            this.tempabel.Size = new System.Drawing.Size(50, 26);
            this.tempabel.TabIndex = 3;
            this.tempabel.Text = "温度";
            // 
            // timetextBox
            // 
            this.timetextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.timetextBox.Location = new System.Drawing.Point(446, 65);
            this.timetextBox.Multiline = true;
            this.timetextBox.Name = "timetextBox";
            this.timetextBox.Size = new System.Drawing.Size(259, 444);
            this.timetextBox.TabIndex = 2;
            this.timetextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gastextBox
            // 
            this.gastextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gastextBox.Location = new System.Drawing.Point(236, 65);
            this.gastextBox.Multiline = true;
            this.gastextBox.Name = "gastextBox";
            this.gastextBox.Size = new System.Drawing.Size(204, 444);
            this.gastextBox.TabIndex = 1;
            this.gastextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // temptextBox
            // 
            this.temptextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.temptextBox.Location = new System.Drawing.Point(23, 65);
            this.temptextBox.Multiline = true;
            this.temptextBox.Name = "temptextBox";
            this.temptextBox.Size = new System.Drawing.Size(207, 444);
            this.temptextBox.TabIndex = 0;
            this.temptextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(948, 529);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工程实践";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox bpscomboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComcomboBox1;
        private System.Windows.Forms.Button WRbutton;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.Button CloseCOMbutton;
        private System.Windows.Forms.Button OpenCOMbutton;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button ESCbutton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Label gaslabel;
        private System.Windows.Forms.Label tempabel;
        private System.Windows.Forms.TextBox timetextBox;
        private System.Windows.Forms.TextBox gastextBox;
        private System.Windows.Forms.TextBox temptextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

