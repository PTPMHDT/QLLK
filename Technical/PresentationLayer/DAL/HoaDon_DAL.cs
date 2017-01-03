using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class HoaDon_DAL
    {
        public static List<HoaDon_View> getAll_HoaDon()
        {
            var hd = from hoadon in Context.getInstance().db.HOADONs
                       select new HoaDon_View
                       {
                           MaHoaDon = hoadon.MaHoaDon,
                           NgayLap = hoadon.NgayLap,
                           NhanVien = hoadon.NHANVIEN.TenNhanVien,
                           MaNhanVien = hoadon.MaNguoiLap,
                           TongTien = hoadon.TongTien,
                           TrangThai = hoadon.TrangThai,
                           KhachHang = hoadon.KHACHHANG.TenKhachHang,
                           MaKhachHang = hoadon.MaKhachHang,
                           SoDienThoai = hoadon.KHACHHANG.SoDienThoai
                       };
            
            return hd.ToList();
        }

        public static HoaDon_View get_HoaDon_By_MaHD(string maHD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADONs
                     where hoadon.MaHoaDon == maHD
                     select new HoaDon_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN1.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TongLoiNhuan = hoadon.TongLoiNhuan,
                         TrangThai = hoadon.TrangThai,
                         KhachHang = hoadon.KHACHHANG.TenKhachHang,
                         MaKhachHang = hoadon.MaKhachHang,
                         SoDienThoai = hoadon.KHACHHANG.SoDienThoai,
                         MaNhanVienSua = hoadon.MaNguoiSua,
                         TenNhanVienSua = hoadon.NHANVIEN.TenNhanVien,
                         NgaySua = (DateTime)hoadon.NgaySua,
                         GhiChu = hoadon.GhiChu
                     };
            HoaDon_View hdV = hd.ToList()[0];
            hdV.ChiTietHoaDon = CT_HoaDon_DAL.get_CTHoaDon_By_MaHD_TT01(hdV.MaHoaDon);
            hdV.InitOldData();
            if(hdV.TrangThai == 0)
                hdV.Mode = TT.DELETE;
            return hdV;
        }

        public static string get_HoaDonMax()
        {
            try
            {
                string result = Context.getInstance().db.HOADONs.OrderByDescending(x => x.MaHoaDon).First().MaHoaDon;
                int index = (Convert.ToInt16((result).Substring(2)) + 1);
                if (index < 10)
                    return "HD00" + index;
                else if (index < 100)
                    return "HD0" + index;
                return "HD" + index;
            }
            catch (Exception)
            {
                return "HD001";
            }
        }

        internal static List<HoaDon_View> getAll_HoaDon_TheoThoiGian(DateTime startD, DateTime endD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADONs
                     where hoadon.NgayLap >= startD.Date 
                     where hoadon.NgayLap <= endD.Date
                     select new HoaDon_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN1.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TongLoiNhuan = hoadon.TongLoiNhuan,
                         TrangThai = hoadon.TrangThai,
                         KhachHang = hoadon.KHACHHANG.TenKhachHang,
                         MaKhachHang = hoadon.MaKhachHang,
                         SoDienThoai = hoadon.KHACHHANG.SoDienThoai,
                         MaNhanVienSua = hoadon.MaNguoiSua,
                         TenNhanVienSua = hoadon.NHANVIEN.TenNhanVien,
                         NgaySua = (DateTime)hoadon.NgaySua,
                         GhiChu = hoadon.GhiChu
                     };
            var khp = hd.ToList();
            foreach (var item in khp)
            {
                item.ChiTietHoaDon = CT_HoaDon_DAL.get_CTHoaDon_By_MaHD_TT01(item.MaHoaDon);
                item.InitOldData();
                if (item.TrangThai == 0)
                    item.Mode = TT.DELETE; 
            }
            return khp;
        }

        public static List<HoaDon_View> searchSeri(string seri)
        {
            var hd = from hoadon in Context.getInstance().db.CT_HOADON
                     where hoadon.Seri.Contains(seri) 
                     select new HoaDon_View
                     {
                         MaHoaDon = hoadon.MaHoaDon
                     };
            List<string> lstMaHD = new List<string>();
            List<HoaDon_View> lstHDV = new List<HoaDon_View>();
            if(hd != null)
            {
                foreach (var item in hd.ToList())
                {
                    if (lstHDV.Where(key => key.MaHoaDon == item.MaHoaDon).FirstOrDefault() == null)
                    {
                        lstHDV.Add(get_HoaDon_By_MaHD(item.MaHoaDon));
                    }
                }
                return lstHDV;
            }
                
            return null;
        }

        public static bool add_HoaDon(HoaDon_View hd, DataUpdate<CT_HOADON> list_Change)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    hd.TrangThai = 1;
                    Context.getInstance().db.Entry(hd.toHoaDon()).State = System.Data.Entity.EntityState.Added;
                    list_Change.Inserts.ForEach(x =>
                    {
                        //set trang thai = 1 o day
                        x.TinhTrang = 1;
                        Context.getInstance().db.Entry(x).State = System.Data.Entity.EntityState.Added;

                        //xoa trong kho
                        KHO kho = Context.getInstance().db.KHOes.Where(key => key.MaLinhKien == x.MaLinhKien).Where(k => k.Seri == x.Seri).FirstOrDefault();
                        kho.TrangThai = 0;
                        Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Modified;

                        //chuyen trang thai cho hoa don nhap sang 2 la ko duoc xoa
                        List<HoaDonNhap_View> listHDN = HoaDonNhap_DAL.searchSeri(x.Seri);
                        if (listHDN != null)
                        {
                            foreach (var item in listHDN)
                            {
                                HOADON_NHAPHANG hdn = item.toHoaDonNhap();
                                if(hdn.TrangThai == 1)
                                {
                                    hdn.TrangThai = 2;
                                    Context.getInstance().db.Entry(hdn).State = System.Data.Entity.EntityState.Modified;
                                }
                            }
                        }
                    });

                    //update so tien mua hang cua khach hang
                    KHACHHANG kh = Context.getInstance().db.KHACHHANGs.Where(key => key.MaKhachHang == hd.MaKhachHang).FirstOrDefault();
                    kh.Tong += hd.TongTien;
                    Context.getInstance().db.Entry(kh).State = System.Data.Entity.EntityState.Modified;

                    //update so luong ban hang cua nhan vien
                    NHANVIEN mNV = Context.getInstance().db.NHANVIENs.Where(key => key.MaNhanVien == hd.MaNhanVien).FirstOrDefault();
                    mNV.TongTien += hd.TongTien;
                    Context.getInstance().db.Entry(mNV).State = System.Data.Entity.EntityState.Modified;

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //Context.getInstance().db.KHOes.Local.Clear();
                    //Context.getInstance().db.CT_HOADON.Local.Clear();
                    //Context.getInstance().db.KHACHHANGs.Local.Clear();
                    //Context.getInstance().db.NHANVIENs.Local.Clear();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        public static bool del_HoaDon(HoaDon_View hd, DataUpdate<CT_HOADON> list_Change)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    hd.TrangThai = 0;
                    Context.getInstance().db.Entry(hd.toHoaDon()).State = System.Data.Entity.EntityState.Modified;

                    //list_Change.Inserts.ForEach(x =>
                    //{
                    //});

                    //list_Change.Updates.ForEach(x =>
                    //{
                    //    x.TinhTrang = 1;
                    //    Context.getInstance().db.Entry(getCTHD(x)).State = System.Data.Entity.EntityState.Modified;
                    //});

                    list_Change.Deletes.ForEach(x =>
                    {
                        //set trang thai = 0 o day
                        x.TinhTrang = 0;
                        Context.getInstance().db.Entry(getCTHD(x)).State = System.Data.Entity.EntityState.Modified;

                        //them trong kho
                        KHO kho = Context.getInstance().db.KHOes.Where(key => key.MaLinhKien == x.MaLinhKien).Where(k => k.Seri == x.Seri).FirstOrDefault();
                        kho.TrangThai = 1;
                        Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Modified;
                    });


                    //update so tien mua hang cua khach hang
                    KHACHHANG kh = Context.getInstance().db.KHACHHANGs.Where(key => key.MaKhachHang == hd.MaKhachHang).FirstOrDefault();
                    kh.Tong -= hd.TongTien;
                    Context.getInstance().db.Entry(kh).State = System.Data.Entity.EntityState.Modified;

                    //update so luong ban hang cua nhan vien
                    NHANVIEN mNV = Context.getInstance().db.NHANVIENs.Where(key => key.MaNhanVien == hd.MaNhanVien).FirstOrDefault();
                    mNV.TongTien -= hd.TongTien;
                    Context.getInstance().db.Entry(mNV).State = System.Data.Entity.EntityState.Modified;

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        public static bool update_HoaDon(HoaDon_View hd, DataUpdate<CT_HOADON> list_Change, decimal tongTien_old)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(hd.toHoaDon()).State = System.Data.Entity.EntityState.Modified;

                    list_Change.Inserts.ForEach(x =>
                    {
                        CT_HOADON ct = Context.getInstance().db.CT_HOADON.Where(key => key.MaHoaDon == x.MaHoaDon)
                                                                          .Where(key => key.MaLinhKien == x.MaLinhKien)
                                                                          .Where(key => key.Seri == x.Seri)
                                                                         .FirstOrDefault();
                        if (ct != null)
                        {
                            ct.TinhTrang = 1;
                            Context.getInstance().db.Entry(ct).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            x.TinhTrang = 1;
                            Context.getInstance().db.Entry(x).State = System.Data.Entity.EntityState.Added;
                        }

                        //xoa trong kho
                        KHO kho = Context.getInstance().db.KHOes.Where(key => key.MaLinhKien == x.MaLinhKien).Where(k => k.Seri == x.Seri).FirstOrDefault();
                        kho.TrangThai = 0;
                        Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Modified;
                    });

                    list_Change.Updates.ForEach(x =>
                    {
                        x.TinhTrang = 1;
                        Context.getInstance().db.Entry(getCTHD(x)).State = System.Data.Entity.EntityState.Modified;
                    });

                    list_Change.Deletes.ForEach(x =>
                    {
                        //set trang thai = 0 o day
                        x.TinhTrang = 0;
                        Context.getInstance().db.Entry(getCTHD(x)).State = System.Data.Entity.EntityState.Modified;

                        //them trong kho
                        KHO kho = Context.getInstance().db.KHOes.Where(key => key.MaLinhKien == x.MaLinhKien).Where(k => k.Seri == x.Seri).FirstOrDefault();
                        kho.TrangThai = 1;
                        Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Modified;
                    }); 

                    
                    //update so tien mua hang cua khach hang
                    KHACHHANG kh = Context.getInstance().db.KHACHHANGs.Where(key => key.MaKhachHang == hd.MaKhachHang).FirstOrDefault();
                    kh.Tong += hd.TongTien;
                    kh.Tong -= tongTien_old;
                    Context.getInstance().db.Entry(kh).State = System.Data.Entity.EntityState.Modified;

                    //update so luong ban hang cua nhan vien
                    NHANVIEN mNV = Context.getInstance().db.NHANVIENs.Where(key => key.MaNhanVien == hd.MaNhanVien).FirstOrDefault();
                    mNV.TongTien += hd.TongTien;
                    mNV.TongTien -= tongTien_old;
                    Context.getInstance().db.Entry(mNV).State = System.Data.Entity.EntityState.Modified;

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        private static CT_HOADON getCTHD(CT_HOADON x)
        {
            CT_HOADON ct = Context.getInstance().db.CT_HOADON.Where(key => key.MaHoaDon == x.MaHoaDon)
                                                                          .Where(key => key.MaLinhKien == x.MaLinhKien)
                                                                          .Where(key => key.Seri == x.Seri)
                                                                         .FirstOrDefault();
            if (ct == null)
            {
                ct = new CT_HOADON();
            }
            ct.ThanhTien = x.ThanhTien;
            ct.Thue = x.Thue;
            ct.TinhTrang = x.TinhTrang;
            ct.SoLuong = x.SoLuong;
            ct.GiaBan = x.GiaBan;
            ct.LoiNhuan = x.LoiNhuan;
            ct.GhiChu = x.GhiChu;
            return ct;
        }
    }
}
