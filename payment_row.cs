using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAI_KIOSK
{
    public partial class payment_row : UserControl
    {
        public payment_row(string menu, string count, string price)
        {
            InitializeComponent();
            row_pname.Text = menu;
            row_price.Text = price;
            row_count.Text = count;

        }
    }
}
