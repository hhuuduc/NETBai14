using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoi
{
    class GV
    {
        public int maGV { get; set; }
        public string tenGV { get; set; }
        public string sdt { get; set; }
        public string ghiChu { get; set; }
        public int maDonVi { get; set; }

        public GV() { }
        public GV(int ma, string ten, string dt, string gc, int madv)
        {
            this.maGV = ma;
            this.tenGV = ten;
            this.sdt = dt;
            this.ghiChu = gc;
            this.maDonVi = madv;
        }

    }
}
