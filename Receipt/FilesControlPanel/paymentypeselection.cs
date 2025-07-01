using System;
using System.Windows.Forms;

namespace Receipt.FilesControlPanel
{
    public partial class paymentypeselection : Form
    {
        public string SelectedPaymentType { get; private set; }
        public paymentypeselection()
        {
            InitializeComponent();
            kartodemebtn.Click += Kartodemebtn_Click;
            nakitodemebtn.Click += Nakitodemebtn_Click;
        }
        private void Kartodemebtn_Click(object sender, EventArgs e)
        {
            SelectedPaymentType = "Kart";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Nakitodemebtn_Click(object sender, EventArgs e)
        {
            SelectedPaymentType = "Nakit";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
