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
    public partial class menu_row : UserControl
    {
        public event EventHandler dce;
        public int s_inds = 0;
        public menu_row(string m_name, string m_count, string m_price,int ind)
        {
            InitializeComponent();
            row_mname.Text = m_name;
            row_count.Text = m_count;
            row_price.Text = m_price;
            s_inds = ind;
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            if (this.dce != null)
                dce(sender, e);
        }
    }
}
