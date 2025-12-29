using System;
using System.Linq;

namespace RanSanMoi
{
    public static class ThongKe
    {
        public static int DiemCaoNhat(NguoiChoi[] ds) =>
            ds.Length == 0 ? 0 : ds.Max(p => p.Diem);

        public static double DiemTrungBinh(NguoiChoi[] ds) =>
            ds.Length == 0 ? 0 : ds.Average(p => p.Diem);

        public static int TongSoNguoiChoi(NguoiChoi[] ds) => ds.Length;
    }
}