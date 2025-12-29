using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace RanSanMoi
{
    public class TroChoi
    {
        private readonly int KICH_THUOC_BAN_DO;
        private readonly int TocDo;
        private List<(int x, int y)> thanRan;
        private (int x, int y) thucAn;
        private Huong huongHienTai;
        private bool KetThuc;
        private Stopwatch dongHo;
        public int Diem { get; private set; }

        public TroChoi(CauHinhGame cauHinh)
        {
            KICH_THUOC_BAN_DO = cauHinh.KichThuocBanDo;
            TocDo = cauHinh.TocDoKhoiTao;
            thanRan = new List<(int x, int y)>();
            dongHo = new Stopwatch();
        }

        private void KhoiTaoTroChoi()
        {
            Console.Clear();
            thanRan.Clear();
            thanRan.Add((10, 10));
            huongHienTai = Huong.Phai;
            Diem = 0;
            KetThuc = false;
            TaoThucAn();
            dongHo.Restart();
            Console.CursorVisible = false;
        }

        private void TaoThucAn()
        {
            Random rd = new Random();
            thucAn = (rd.Next(1, KICH_THUOC_BAN_DO - 1), rd.Next(1, KICH_THUOC_BAN_DO - 1));
        }

        private void VeBanDo()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < KICH_THUOC_BAN_DO; i++)
            {
                for (int j = 0; j < KICH_THUOC_BAN_DO; j++)
                {
                    if (i == 0 || j == 0 || i == KICH_THUOC_BAN_DO - 1 || j == KICH_THUOC_BAN_DO - 1)
                        Console.Write("#");
                    else if (i == thucAn.y && j == thucAn.x)
                        Console.Write("*");
                    else if (thanRan.Contains((j, i)))
                        Console.Write("O");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Diem: {Diem}");
            Console.WriteLine($"Thoi gian: {dongHo.Elapsed.Seconds}s");
        }

        private void DiChuyenRan(ref Huong huongNhap)
        {
            if (Console.KeyAvailable)
            {
                var phim = Console.ReadKey(true).Key;
                switch (phim)
                {
                    case ConsoleKey.UpArrow: huongNhap = Huong.Len; break;
                    case ConsoleKey.DownArrow: huongNhap = Huong.Xuong; break;
                    case ConsoleKey.LeftArrow: huongNhap = Huong.Trai; break;
                    case ConsoleKey.RightArrow: huongNhap = Huong.Phai; break;
                }
            }

            var dauRan = thanRan[0];
            (int x, int y) moi = dauRan;

            switch (huongNhap)
            {
                case Huong.Len: moi.y--; break;
                case Huong.Xuong: moi.y++; break;
                case Huong.Trai: moi.x--; break;
                case Huong.Phai: moi.x++; break;
            }

            if (moi.x == 0 || moi.y == 0 || moi.x == KICH_THUOC_BAN_DO - 1 || moi.y == KICH_THUOC_BAN_DO - 1 || thanRan.Contains(moi))
            {
                KetThuc = true;
                return;
            }

            thanRan.Insert(0, moi);

            if (moi == thucAn)
            {
                Diem += 10;
                TaoThucAn();
            }
            else
            {
                thanRan.RemoveAt(thanRan.Count - 1);
            }

            huongHienTai = huongNhap;
        }

        public void BatDauChoi()
        {
            KhoiTaoTroChoi();
            Huong huongNhap = huongHienTai;

            while (!KetThuc)
            {
                DiChuyenRan(ref huongNhap);
                VeBanDo();
                Thread.Sleep(TocDo);
            }

            dongHo.Stop();
            Console.Clear();
            Console.WriteLine("Tro choi ket thuc!");
            Console.WriteLine($"Diem: {Diem}");
            Console.WriteLine($"Thoi gian: {dongHo.Elapsed.TotalSeconds:F2}s");
            Console.CursorVisible = true;
        }

        public double LayThoiGianChoi() => dongHo.Elapsed.TotalSeconds;
    }
}