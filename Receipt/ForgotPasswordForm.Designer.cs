namespace Receipt
{
    partial class ForgotPasswordForm
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
            this.textBoxAdminCode = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.labelAdminCode = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.buttonUpdatePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAdminCode
            // 
            this.textBoxAdminCode.Location = new System.Drawing.Point(86, 15);
            this.textBoxAdminCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAdminCode.Name = "textBoxAdminCode";
            this.textBoxAdminCode.PasswordChar = '*';
            this.textBoxAdminCode.Size = new System.Drawing.Size(168, 25);
            this.textBoxAdminCode.TabIndex = 0;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(86, 48);
            this.textBoxNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(168, 25);
            this.textBoxNewPassword.TabIndex = 1;
            // 
            // labelAdminCode
            // 
            this.labelAdminCode.AutoSize = true;
            this.labelAdminCode.Location = new System.Drawing.Point(7, 17);
            this.labelAdminCode.Name = "labelAdminCode";
            this.labelAdminCode.Size = new System.Drawing.Size(76, 17);
            this.labelAdminCode.TabIndex = 2;
            this.labelAdminCode.Text = "Reset Code";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(16, 51);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(63, 17);
            this.labelNewPassword.TabIndex = 3;
            this.labelNewPassword.Text = "Yeni Şifre";
            // 
            // buttonUpdatePassword
            // 
            this.buttonUpdatePassword.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdatePassword.Location = new System.Drawing.Point(111, 80);
            this.buttonUpdatePassword.Name = "buttonUpdatePassword";
            this.buttonUpdatePassword.Size = new System.Drawing.Size(112, 26);
            this.buttonUpdatePassword.TabIndex = 4;
            this.buttonUpdatePassword.Text = "Güncelle";
            this.buttonUpdatePassword.UseVisualStyleBackColor = false;
            this.buttonUpdatePassword.Click += new System.EventHandler(this.buttonUpdatePassword_Click);
            this.buttonUpdatePassword.Enter += new System.EventHandler(this.buttonUpdatePassword_Click);
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 115);
            this.ControlBox = false;
            this.Controls.Add(this.buttonUpdatePassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labelAdminCode);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxAdminCode);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ForgotPasswordForm";
            this.Text = "Şifre Güncelle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAdminCode;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label labelAdminCode;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Button buttonUpdatePassword;
    }
}