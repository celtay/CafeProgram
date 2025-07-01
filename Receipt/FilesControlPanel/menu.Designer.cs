using System.Drawing;
using System.Windows.Forms;

namespace Receipt
{
    partial class menu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.foodname = new System.Windows.Forms.Label();
            this.gradientprice = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Gray;
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(162)))), ((int)(((byte)(200)))));
            this.guna2Button1.Location = new System.Drawing.Point(0, 0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(156, 82);
            this.guna2Button1.TabIndex = 0;
            // 
            // foodname
            // 
            this.foodname.AutoSize = true;
            this.foodname.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(73)))));
            this.foodname.Location = new System.Drawing.Point(2, 7);
            this.foodname.Name = "foodname";
            this.foodname.Size = new System.Drawing.Size(51, 21);
            this.foodname.TabIndex = 0;
            this.foodname.Text = "label1";
            this.foodname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientprice
            // 
            this.gradientprice.AutoSize = true;
            this.gradientprice.BackColor = System.Drawing.Color.Transparent;
            this.gradientprice.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientprice.ForeColor = System.Drawing.Color.Purple;
            this.gradientprice.Location = new System.Drawing.Point(43, 51);
            this.gradientprice.Name = "gradientprice";
            this.gradientprice.Size = new System.Drawing.Size(66, 28);
            this.gradientprice.TabIndex = 1;
            this.gradientprice.Text = "label2";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.gradientprice);
            this.guna2Panel1.Controls.Add(this.foodname);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(156, 82);
            this.guna2Panel1.TabIndex = 0;
            // 
            // menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "menu";
            this.Size = new System.Drawing.Size(156, 82);
            this.Load += new System.EventHandler(this.menu_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label foodname;
        private Label gradientprice;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
