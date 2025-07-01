using System.Windows.Forms;

namespace Receipt.MenuScreenDatas
{
    public partial class menusiparislist : UserControl
    {
        public menusiparislist()
        {
            InitializeComponent();
        }

        public string ProductName
        {
            get { return productnamesiparismenu.Text; }
            set { productnamesiparismenu.Text = value; }
        }

        public string Price
        {
            get { return pricemenu.Text; }
            set { pricemenu.Text = value; }
        }
    }
}
