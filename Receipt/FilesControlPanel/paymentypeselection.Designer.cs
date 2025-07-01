namespace Receipt.FilesControlPanel
{
    partial class paymentypeselection
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
            this.kartodemebtn = new Guna.UI2.WinForms.Guna2Button();
            this.nakitodemebtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kartodemebtn
            // 
            this.kartodemebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.kartodemebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.kartodemebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.kartodemebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.kartodemebtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(162)))), ((int)(((byte)(200)))));
            this.kartodemebtn.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kartodemebtn.ForeColor = System.Drawing.Color.White;
            this.kartodemebtn.Location = new System.Drawing.Point(19, 13);
            this.kartodemebtn.Name = "kartodemebtn";
            this.kartodemebtn.Size = new System.Drawing.Size(129, 50);
            this.kartodemebtn.TabIndex = 0;
            this.kartodemebtn.Text = "Kart";
            // 
            // nakitodemebtn
            // 
            this.nakitodemebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.nakitodemebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.nakitodemebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.nakitodemebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.nakitodemebtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(0)))), ((int)(((byte)(168)))));
            this.nakitodemebtn.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nakitodemebtn.ForeColor = System.Drawing.Color.White;
            this.nakitodemebtn.Location = new System.Drawing.Point(167, 13);
            this.nakitodemebtn.Name = "nakitodemebtn";
            this.nakitodemebtn.Size = new System.Drawing.Size(129, 50);
            this.nakitodemebtn.TabIndex = 1;
            this.nakitodemebtn.Text = "Nakit";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.nakitodemebtn);
            this.guna2ShadowPanel1.Controls.Add(this.kartodemebtn);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.DimGray;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(1, 2);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(315, 77);
            this.guna2ShadowPanel1.TabIndex = 2;
            // 
            // paymentypeselection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 78);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "paymentypeselection";
            this.Text = "paymentypeselection";
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button kartodemebtn;
        private Guna.UI2.WinForms.Guna2Button nakitodemebtn;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}