using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetNoi
{
    public partial class FrmGV : Form
    {
        XuLy xl = new XuLy();
        private string tenMay, tenCsdl;

        public FrmGV()
        {
            InitializeComponent();
        }

        public FrmGV(string may, string csdl)
        {
            InitializeComponent();
            this.tenMay = may;
            this.tenCsdl = csdl;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmGV_Load(object sender, EventArgs e)
        {
            dtgvGV.DataSource = null;
            List<GV> dsgv = xl.LoadDSGV(tenMay, tenCsdl);
            dtgvGV.DataSource = dsgv;
            dtgvGV.Columns[0].HeaderText = "STT";
            dtgvGV.Columns[1].HeaderText = "Họ tên";
            dtgvGV.Columns[2].Visible = false;
            dtgvGV.Columns[3].Visible = false;
            dtgvGV.Columns[4].Visible = false;
            cbDonVi.DataSource = null;
            List<DonVi> dsdv = xl.LoadDSDV(tenMay, tenCsdl);
            var dv = new BindingSource();
            dv.DataSource = dsdv;
            cbDonVi.DataSource = dv.DataSource;
            cbDonVi.DisplayMember = "tendonvi";
            cbDonVi.ValueMember = "madonvi";
            cbCoSo.Text = "";
            
        }

        private void cbDonVi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtgvGV.DataSource = null;
            int id = Convert.ToInt32(cbDonVi.SelectedValue);
            List<GV> dsgv = xl.LoadDSGVtoID(tenMay, tenCsdl, id);
            dtgvGV.DataSource = dsgv;
            dtgvGV.Columns[0].HeaderText = "STT";
            dtgvGV.Columns[1].HeaderText = "Họ tên";
            dtgvGV.Columns[2].Visible = false;
            dtgvGV.Columns[3].Visible = false;
            dtgvGV.Columns[4].Visible = false;
            cbCoSo.Text = xl.LoadDSCStoID(xl.LoadDSCS(tenMay, tenCsdl), xl.LoadDSDVtoID(xl.LoadDSDV(tenMay, tenCsdl), id));

        }

        private void dtgvGV_CurrentCellChanged(object sender, EventArgs e)
        {
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            FrmGV_Load(sender, e);
        }

        private void tstbHienThi_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dtgvGV.Rows[dtgvGV.CurrentRow.Index].Cells[0].Value.ToString());
            List<GV> dsgv = xl.LoadDSGV(tenMay, tenCsdl);
            GV gv = xl.LoadGVtoID(dsgv, id);
            List<DonVi> dsdv = xl.LoadDSDV(tenMay, tenCsdl);
            string tendv = xl.LoadTenDVtoID(dsdv, gv.maDonVi);
            MessageBox.Show("Tên: " + gv.tenGV + "" + System.Environment.NewLine + 
                "SĐT: " + gv.sdt + "" + System.Environment.NewLine +
                "Ghi chú: " + gv.ghiChu + "" + System.Environment.NewLine + 
                "Đơn vị: " + tendv + "", "Thông báo");
        }

        private void dtgvGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dtgvGV.ClearSelection();
                dtgvGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                if (dtgvGV.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip == null)
                {
                    dtgvGV.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip = contextMenuStrip1;
                }
                tstbHienThi.Click += tstbHienThi_Click;
                tstbXoa.Click += tstbXoa_Click;
                dtgvGV.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip.Show(Cursor.Position);
            }
            //dtgvGV.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip.Show(Cursor.Position);
        }

        private void tstbXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dtgvGV.Rows[dtgvGV.CurrentRow.Index].Cells[0].Value.ToString());
                xl.XoaGV(tenMay, tenCsdl, id);
                MessageBox.Show("Xóa giáo viên thành công", "Thông báo");
                FrmGV_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
