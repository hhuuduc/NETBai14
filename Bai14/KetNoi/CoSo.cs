using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoi
{
    class CoSo
    {
        public int maCoSo { get; set; }
        public string tenCoSo { get; set; }

        public CoSo() { }

        public CoSo(int ma, string ten)
        {
            this.maCoSo = ma;
            this.tenCoSo = ten;
        }
    }
}
