using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Topic2_WorkingEF
{
    public partial class FrmUpdate : Form
    {
        int movieId;
        public FrmUpdate(int movieId)
        {
            InitializeComponent();
            this.movieId = movieId;
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            label1.Text = movieId.ToString();
        }
    }
}
