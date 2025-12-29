namespace RanSanMoi
{
    public static class SapXep
    {
        public static void SapXepTheoDiem_Bubble(NguoiChoi[] ds)
        {
            for (int i = 0; i < ds.Length - 1; i++)
                for (int j = 0; j < ds.Length - i - 1; j++)
                    if (ds[j].Diem < ds[j + 1].Diem)
                    {
                        var t = ds[j];
                        ds[j] = ds[j + 1];
                        ds[j + 1] = t;
                    }
        }

        public static void SapXepTheoTen_Selection(NguoiChoi[] ds)
        {
            for (int i = 0; i < ds.Length - 1; i++)
            {
                int vt = i;
                for (int j = i + 1; j < ds.Length; j++)
                    if (string.Compare(ds[j].Ten, ds[vt].Ten) < 0)
                        vt = j;

                var t = ds[i];
                ds[i] = ds[vt];
                ds[vt] = t;
            }
        }
    }
}