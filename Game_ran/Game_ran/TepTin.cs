using System;
using System.Collections.Generic;
using System.IO;

namespace RanSanMoi
{
    public static class TepTin
    {
        public static void Luu(NguoiChoi[] ds, string duongDan = "data.txt")
        {
            try
            {
                if (File.Exists(duongDan))
                    File.Copy(duongDan, "data.bak", true);

                using (var w = new StreamWriter(duongDan))
                {
                    foreach (var p in ds)
                        w.WriteLine(p.ToString());
                }
                Console.WriteLine("Da luu du lieu thanh cong");
            }
            catch
            {
                Console.WriteLine("Loi khi luu du lieu");
            }
        }

        public static NguoiChoi[] Tai(string duongDan = "data.txt")
        {
            var ds = new List<NguoiChoi>();
            if (!File.Exists(duongDan)) return ds.ToArray();
            foreach (var dong in File.ReadAllLines(duongDan))
                ds.Add(NguoiChoi.TuChuoi(dong));
            return ds.ToArray();
        }
    }
}