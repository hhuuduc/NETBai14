using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoi
{
    class DonVi
    {
        public int maDonVi { get; set; }
        public string tenDonVi { get; set; }
        public int maCoSo { get; set; }

        public DonVi(){}
        public DonVi(int ma, string ten, int macs)
        {
            this.maDonVi = ma;
            this.tenDonVi = ten;
            this.maCoSo = macs;
        }
    }
}
