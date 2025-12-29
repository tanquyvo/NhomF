using System;

namespace RanSanMoi
{
    public static class HienThi
    {
        public static void XemBangDiem(NguoiChoi[] ds)
        {
            Console.Clear();
            Console.WriteLine("=== BANG DIEM ===");
            if (ds.Length == 0)
            {
                Console.WriteLine("Chua co nguoi choi nao");
                return;
            }
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ds[i].Ten} - {ds[i].Diem} diem - {ds[i].ThoiGianChoi:F1}s");
            }
        }
    }
}