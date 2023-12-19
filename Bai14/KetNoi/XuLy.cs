using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KetNoi
{
    class XuLy
    {
        public XuLy() { }
        ConnectionDB db = new ConnectionDB();

        //public string conStr = @"Data Source=A209PC39\CSSQL08;Initial Catalog=QLGV;Integrated Security=True";



        public List<GV> LoadDSGV(string tenMay, string tenCsdl)
        {
            List<GV> dsgv = new List<GV>();
            dsgv.Clear();
            //string constr = "Data Source=" + tenMay + ";Initial Catalog=" + tenCsdl + ";Integrated Security=True";
            SqlConnection conn = db.getConnect(tenMay, tenCsdl);
            string sql = "select * from GV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int ma = Convert.ToInt32(rdr.GetValue(0).ToString());
                string ten = rdr.GetValue(1).ToString();
                string sdt = rdr.GetValue(2).ToString();
                string ghichu = rdr.GetValue(3).ToString();
                int madv = Convert.ToInt32(rdr.GetValue(4).ToString());
                dsgv.Add(new GV(ma, ten, sdt, ghichu, madv));
            }
            conn.Close();
            return dsgv;
        }

        public List<GV> LoadDSGVtoID(string tenMay, string tenCsdl, int id)
        {
            List<GV> dsgv = new List<GV>();
            dsgv.Clear();
            //string constr = "Data Source=" + tenMay + ";Initial Catalog=" + tenCsdl + ";Integrated Security=True";
            SqlConnection conn = db.getConnect(tenMay, tenCsdl);
            string sql = "select * from GV where madonvi = " + id + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int ma = Convert.ToInt32(rdr.GetValue(0).ToString());
                string ten = rdr.GetValue(1).ToString();
                string sdt = rdr.GetValue(2).ToString();
                string ghichu = rdr.GetValue(3).ToString();
                int madv = Convert.ToInt32(rdr.GetValue(4).ToString());
                dsgv.Add(new GV(ma, ten, sdt, ghichu, madv));
            }
            conn.Close();
            return dsgv;
        }

        public List<DonVi> LoadDSDV(string tenMay, string tenCsdl)
        {
            List<DonVi> dsdv = new List<DonVi>();
            dsdv.Clear();
            //string constr = "Data Source=" + tenMay + ";Initial Catalog=" + tenCsdl + ";Integrated Security=True";
            SqlConnection conn = db.getConnect(tenMay, tenCsdl);
            string sql = "select * from DONVI";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int ma = Convert.ToInt32(rdr.GetValue(0).ToString());
                string ten = rdr.GetValue(1).ToString();
                int macs = Convert.ToInt32(rdr.GetValue(2).ToString());
                dsdv.Add(new DonVi(ma, ten, macs));
            }
            conn.Close();
            return dsdv;
        }

        public List<CoSo> LoadDSCS(string tenMay, string tenCsdl)
        {
            List<CoSo> dscs = new List<CoSo>();
            dscs.Clear();
            //string constr = "Data Source=" + tenMay + ";Initial Catalog=" + tenCsdl + ";Integrated Security=True";
            SqlConnection conn = db.getConnect(tenMay, tenCsdl);
            string sql = "select * from COSO";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int ma = Convert.ToInt32(rdr.GetValue(0).ToString());
                string ten = rdr.GetValue(1).ToString();
                dscs.Add(new CoSo(ma, ten));
            }
            conn.Close();
            return dscs;
        }

        public string LoadDSCStoID(List<CoSo> dscs, int id)
        {
            for (int i = 0; i < dscs.Count(); i++)
            {
                if (dscs[i].maCoSo == id)
                    return dscs[i].tenCoSo;
            }
            return null;
        }

        public string LoadTenDVtoID(List<DonVi> dsdv, int id)
        {
            for (int i = 0; i < dsdv.Count(); i++)
            {
                if (dsdv[i].maDonVi == id)
                    return dsdv[i].tenDonVi;
            }
            return null;
        }

        public int LoadDSDVtoID(List<DonVi> dsdv, int id)
        {
            for (int i = 0; i < dsdv.Count(); i++)
            {
                if (dsdv[i].maDonVi == id)
                    return dsdv[i].maCoSo;
            }
            return 0;
        }

        public GV LoadGVtoID(List<GV> dsgv, int id)
        {
            for (int i = 0; i < dsgv.Count(); i++)
            {
                if (dsgv[i].maGV == id)
                    return dsgv[i];
            }
            return null;
        }

        public void XoaGV(string tenMay, string tenCsdl, int id)
        {
            SqlConnection conn = db.getConnect(tenMay, tenCsdl);
            conn.Open();
            string sql = "DELETE FROM GV WHERE [magv] = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
