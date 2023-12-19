using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetNoi
{
    public partial class FrmMain : Form
    {
        XuLy xl = new XuLy();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string may = txtTenMay.Text.ToString();
            string csdl = txtTenCSDL.Text.ToString();
            List<GV> dsgv = xl.LoadDSGV(may, csdl);
            if(dsgv.Count() > 0)
            {
                MessageBox.Show("Kết nối thành công", "Thông báo");
                this.Hide();
                FrmGV frmGV = new FrmGV(may, csdl);
                frmGV.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kết nối thất bại", "Thông báo");
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }
    }
}
