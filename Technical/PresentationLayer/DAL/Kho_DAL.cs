using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PresentationLayer.DAL
{
    public class Kho_DAL
    {

        public static List<Kho_View> getAll_LinhKien()
        {
            var kho1 = from kho in Context.getInstance().db.KHOes
                       select new Kho_View
                       {
                           MaLinhKien = kho.MaLinhKien,
                           TenLinhKien = kho.LINHKIEN.TenLinhKien,
                           SoLuong = kho.SoLuong,
                           DonViTinh = kho.LINHKIEN.DONVITINH.TenDonViTinh,
                           GiaBanLe = kho.LINHKIEN.GiaBanLe,
                           GiaBanSi = kho.LINHKIEN.GiaBanSi,
                           TinhTrangLK = kho.LINHKIEN.TinhTrang,
                           MoTaLK = kho.LINHKIEN.MoTa,
                           ThuongHieu = kho.LINHKIEN.THUONGHIEU.TenThuongHieu
                       };
            return kho1.ToList();
        }

        public static Kho_View get_LinhKien_By_MaLinhKien(string maLK)
        {
            var kho1 = from kho in Context.getInstance().db.KHOes
                       where kho.MaLinhKien == maLK
                       select new Kho_View
                       {
                           MaLinhKien = kho.MaLinhKien,
                           TenLinhKien = kho.LINHKIEN.TenLinhKien,
                           SoLuong = kho.SoLuong,
                           DonViTinh = kho.LINHKIEN.DONVITINH.TenDonViTinh,
                           GiaBanLe = kho.LINHKIEN.GiaBanLe,
                           GiaBanSi = kho.LINHKIEN.GiaBanSi,
                           TinhTrangLK = kho.LINHKIEN.TinhTrang,
                           MoTaLK = kho.LINHKIEN.MoTa,
                           ThuongHieu = kho.LINHKIEN.THUONGHIEU.TenThuongHieu
                       };
            return kho1.ToList()[0];
        }
    }

}
