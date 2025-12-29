using System;

namespace RanSanMoi
{
    public enum Huong { Len, Xuong, Trai, Phai }

    public readonly struct CauHinhGame
    {
        public readonly int KichThuocBanDo;
        public readonly int TocDoKhoiTao;

        public CauHinhGame(int kichThuoc = 20, int tocDo = 10000)
        {
            if (kichThuoc < 5) kichThuoc = 5;
            KichThuocBanDo = kichThuoc;
            TocDoKhoiTao = tocDo;
        }
    }

    public struct NguoiChoi
    {
        public string Ten;
        public int Diem;
        public double ThoiGianChoi;

        public NguoiChoi(string ten, int diem = 0, double thoiGian = 0)
        {
            Ten = ten;
            Diem = diem;
            ThoiGianChoi = thoiGian;
        }

        public override string ToString() => $"{Ten},{Diem},{ThoiGianChoi:F1}";

        public static NguoiChoi TuChuoi(string dong)
        {
            var tach = dong.Split(',');
            if (tach.Length < 3) return new NguoiChoi(tach[0]);
            int diem = int.Parse(tach[1]);
            double tg = double.Parse(tach[2]);
            return new NguoiChoi(tach[0], diem, tg);
        }
    }
}