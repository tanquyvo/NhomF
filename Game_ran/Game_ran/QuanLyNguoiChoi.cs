using System;
using System.Collections.Generic;
using System.Linq;

namespace RanSanMoi
{
    public class QuanLyNguoiChoi
    {
        private List<NguoiChoi> danhSach = new List<NguoiChoi>();

        public NguoiChoi[] LayTatCa() => danhSach.ToArray();

        public void ThemNguoiChoi(string ten) => danhSach.Add(new NguoiChoi(ten));

        public void ThemNguoiChoi(string ten, int diem, double tg = 0) =>
            danhSach.Add(new NguoiChoi(ten, diem, tg));

        public bool XoaNguoiChoi(string ten)
        {
            var p = danhSach.FirstOrDefault(x => x.Ten.Equals(ten, StringComparison.OrdinalIgnoreCase));
            if (p.Ten == null) return false;
            danhSach.Remove(p);
            return true;
        }

        public bool CapNhatNguoiChoi(ref NguoiChoi p)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].Ten.Equals(p.Ten, StringComparison.OrdinalIgnoreCase))
                {
                    danhSach[i] = p;
                    return true;
                }
            }
            return false;
        }

        public NguoiChoi? LayTheoTen(string ten)
        {
            var p = danhSach.FirstOrDefault(x => x.Ten.Equals(ten, StringComparison.OrdinalIgnoreCase));
            if (p.Ten == null) return null;
            return p;
        }

        public void ThayDanhSach(NguoiChoi[] ds)
        {
            danhSach = new List<NguoiChoi>(ds);
        }
    }
}