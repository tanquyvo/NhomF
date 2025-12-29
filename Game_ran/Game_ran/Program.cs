using System;

namespace RanSanMoi
{
    class Program
    {
        static void Main()
        {
            var quanly = new QuanLyNguoiChoi();
            quanly.ThayDanhSach(TepTin.Tai());

            CauHinhGame cauHinh = new CauHinhGame(20, 300);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU CHINH ===");
                Console.WriteLine("1. Bat dau choi");
                Console.WriteLine("2. Quan ly nguoi choi (Them/Xoa)");
                Console.WriteLine("3. Xem bang diem");
                Console.WriteLine("4. Sap xep bang diem");
                Console.WriteLine("5. Thong ke");
                Console.WriteLine("6. Luu du lieu");
                Console.WriteLine("7. Thoat");
                Console.Write("Chon: ");
                var chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        Console.Write("Nhap ten nguoi choi: ");
                        string ten = Console.ReadLine();
                        var troChoi = new TroChoi(cauHinh);
                        troChoi.BatDauChoi();
                        quanly.ThemNguoiChoi(ten, troChoi.Diem, troChoi.LayThoiGianChoi());
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("1. Them nguoi choi");
                        Console.WriteLine("2. Xoa nguoi choi");
                        Console.WriteLine("3. Tim nguoi choi");
                        Console.WriteLine("4. Cap nhat nguoi choi");
                        Console.Write("Chon: ");
                        var opt = Console.ReadLine();

                        if (opt == "1")
                        {
                            Console.Write("Ten: ");
                            string t = Console.ReadLine();
                            Console.Write("Diem: ");
                            int d = int.Parse(Console.ReadLine());
                            Console.Write("Thoi gian: ");
                            double tg = double.Parse(Console.ReadLine());

                            quanly.ThemNguoiChoi(t, d, tg);
                            Console.WriteLine("Da them nguoi choi!");
                        }
                        else if (opt == "2")
                        {
                            Console.Write("Nhap ten can xoa: ");
                            if (quanly.XoaNguoiChoi(Console.ReadLine()))
                                Console.WriteLine("Da xoa thanh cong!");
                            else
                                Console.WriteLine("Khong tim thay nguoi choi!");
                        }
                        else if (opt == "3")
                        {
                            Console.Write("Nhap ten can tim: ");
                            var p = quanly.LayTheoTen(Console.ReadLine());
                            if (p == null)
                                Console.WriteLine("Khong tim thay nguoi choi!");
                            else
                                Console.WriteLine($"{p.Value.Ten} - {p.Value.Diem} diem - {p.Value.ThoiGianChoi:F1}s");
                        }
                        else if (opt == "4")
                        {
                            Console.Write("Nhap ten can sua: ");
                            var p = quanly.LayTheoTen(Console.ReadLine());

                            if (p == null)
                            {
                                Console.WriteLine("Khong tim thay nguoi choi!");
                            }
                            else
                            {
                                var nc = p.Value;
                                Console.Write("Nhap diem moi: ");
                                nc.Diem = int.Parse(Console.ReadLine());
                                Console.Write("Nhap thoi gian moi: ");
                                nc.ThoiGianChoi = double.Parse(Console.ReadLine());

                                if (quanly.CapNhatNguoiChoi(ref nc))
                                    Console.WriteLine("Cap nhat thanh cong!");
                            }
                        }

                        Console.ReadLine();
                        break;
                    case "3":
                        HienThi.XemBangDiem(quanly.LayTatCa());
                        Console.ReadLine();
                        break;

                    case "4":
                        var ds = quanly.LayTatCa();
                        SapXep.SapXepTheoDiem_Bubble(ds);
                        HienThi.XemBangDiem(ds);
                        Console.ReadLine();
                        break;

                    case "5":
                        var dss = quanly.LayTatCa();
                        Console.WriteLine($"Diem cao nhat: {ThongKe.DiemCaoNhat(dss)}");
                        Console.WriteLine($"Diem trung binh: {ThongKe.DiemTrungBinh(dss):F1}");
                        Console.WriteLine($"Tong so nguoi choi: {ThongKe.TongSoNguoiChoi(dss)}");
                        Console.ReadLine();
                        break;

                    case "6":
                        TepTin.Luu(quanly.LayTatCa());
                        Console.ReadLine();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            }
        }
    }
}