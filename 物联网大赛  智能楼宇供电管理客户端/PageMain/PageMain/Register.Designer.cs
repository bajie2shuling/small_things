namespace PageMain
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usernameRegisterLabel = new System.Windows.Forms.Label();
            this.usernameRegisterTextBox = new System.Windows.Forms.TextBox();
            this.passwordRegisterTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.confirmRegisterLabel = new System.Windows.Forms.Label();
            this.confirmRegisterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(125, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "密码：";
            // 
            // usernameRegisterLabel
            // 
            this.usernameRegisterLabel.AutoSize = true;
            this.usernameRegisterLabel.Font = new System.Drawing.Font("幼圆", 10.8F, System.Drawing.FontStyle.Bold);
            this.usernameRegisterLabel.Location = new System.Drawing.Point(114, 34);
            this.usernameRegisterLabel.Name = "usernameRegisterLabel";
            this.usernameRegisterLabel.Size = new System.Drawing.Size(83, 19);
            this.usernameRegisterLabel.TabIndex = 1;
            this.usernameRegisterLabel.Text = "用户名:";
            // 
            // usernameRegisterTextBox
            // 
            this.usernameRegisterTextBox.Location = new System.Drawing.Point(219, 34);
            this.usernameRegisterTextBox.Name = "usernameRegisterTextBox";
            this.usernameRegisterTextBox.Size = new System.Drawing.Size(162, 25);
            this.usernameRegisterTextBox.TabIndex = 0;
            // 
            // passwordRegisterTextBox
            // 
            this.passwordRegisterTextBox.Location = new System.Drawing.Point(219, 98);
            this.passwordRegisterTextBox.Name = "passwordRegisterTextBox";
            this.passwordRegisterTextBox.PasswordChar = '*';
            this.passwordRegisterTextBox.Size = new System.Drawing.Size(162, 25);
            this.passwordRegisterTextBox.TabIndex = 1;
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.registerButton.Location = new System.Drawing.Point(187, 232);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(113, 33);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "确认";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // confirmRegisterLabel
            // 
            this.confirmRegisterLabel.AutoSize = true;
            this.confirmRegisterLabel.Font = new System.Drawing.Font("幼圆", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmRegisterLabel.Location = new System.Drawing.Point(83, 162);
            this.confirmRegisterLabel.Name = "confirmRegisterLabel";
            this.confirmRegisterLabel.Size = new System.Drawing.Size(114, 19);
            this.confirmRegisterLabel.TabIndex = 6;
            this.confirmRegisterLabel.Text = "确认密码：";
            // 
            // confirmRegisterTextBox
            // 
            this.confirmRegisterTextBox.Location = new System.Drawing.Point(219, 162);
            this.confirmRegisterTextBox.Name = "confirmRegisterTextBox";
            this.confirmRegisterTextBox.PasswordChar = '*';
            this.confirmRegisterTextBox.Size = new System.Drawing.Size(162, 25);
            this.confirmRegisterTextBox.TabIndex = 2;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(512, 296);
            this.Controls.Add(this.confirmRegisterTextBox);
            this.Controls.Add(this.confirmRegisterLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.passwordRegisterTextBox);
            this.Controls.Add(this.usernameRegisterTextBox);
            this.Controls.Add(this.usernameRegisterLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label usernameRegisterLabel;
        private System.Windows.Forms.TextBox usernameRegisterTextBox;
        private System.Windows.Forms.TextBox passwordRegisterTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label confirmRegisterLabel;
        private System.Windows.Forms.TextBox confirmRegisterTextBox;
    }
}