using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.DAL;
using PresentationLayer.ViewObject;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;

namespace PresentationLayer
{
    public partial class UCKhachHang : UserControl
    {
        GridHelper<KhachHang_View> gridThaoTac;
        int count_row = 0;
        int prvRowFocus = 0;

        public UCKhachHang()
        {
            InitializeComponent();
            this.Load += UCKhachHang_Load;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.FocusedColumnChanged += gridView1_FocusedColumnChanged;
            gridView1.ValidatingEditor += gridView1_ValidatingEditor;
            InitVal();
            btnXoa_Grid.Click += btnXoa_Grid_Click;
            gridView1.KeyDown += gridView1_KeyDown;
        }

        void UCKhachHang_Load(object sender, EventArgs e)
        {
            this.text_money.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.text_money.DisplayFormat.Format = new CultureInfo("vi-VN");
            this.text_money.DisplayFormat.FormatString = "c";
        }

        private void InitVal()
        {
            gridControl1.DataSource = KhachHang_DAL.getAll_KhachHang();
            gridThaoTac = new GridHelper<KhachHang_View>(gridControl1);
            gridThaoTac.Mapping("MaLoaiKhachHang", LoaiKhachHang_DAL.getAll_LoaiKhachHang());
            count_row = 0;
        }

        void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            validateGrid(e.PrevFocusedColumn);
        }

        void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            string fieldName = view.FocusedColumn.FieldName;
            switch (fieldName)
            {
                case "TenKhachHang":
                    if (e.Value.ToString().Trim().Equals(""))
                    {
                        e.Valid = false;
                        e.ErrorText = "Nhập vào tên Khách Hàng";
                    }
                    break;
                case "SoDienThoai":
                    if (e.Value.ToString().Trim().Equals(""))
                    {
                        e.Valid = false;
                        e.ErrorText = "Nhập vào số điện thoại";
                    }
                    break;
                default:
                    break;
            }
        }

        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.PrevFocusedRowHandle >= 0)
                prvRowFocus = e.PrevFocusedRowHandle;
            validateGrid(prvRowFocus);
        }

        void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int r = gridView1.FocusedRowHandle;
                int count = gridView1.RowCount;
                if (r == count - 1 & gridView1.FocusedColumn.FieldName.Equals("GhiChu"))
                {
                    add_Row();
                }
            }
        }
       
        bool validateGrid(GridColumn col)
        {
            int error = 0;
            KhachHang_View lk = gridView1.GetFocusedRow() as KhachHang_View;
            if (lk != null)
            {
                switch (col.FieldName)
                {
                    case "TenKhachHang":
                        if (lk.TenKhachHang == null || lk.TenKhachHang.Trim().Equals(""))
                        {
                            gridView1.SetColumnError(gridView1.Columns["TenKhachHang"], "Tên Khách hàng không được rỗng!");
                            error++;
                        }
                        else
                        {
                            gridView1.SetColumnError(col, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;
                    case "MaLoaiKhachHang":
                        if (lk.MaLoaiKhachHang == null)
                        {
                            gridView1.SetColumnError(gridView1.Columns["MaLoaiKhachHang"], "Loại Khách hàng không được rỗng!");
                            error++;
                        }
                        else
                        {
                            gridView1.SetColumnError(col, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;
                    case "SoDienThoai":
                        if (lk.SoDienThoai == null)
                        {
                            gridView1.SetColumnError(gridView1.Columns["SoDienThoai"], "Số điện thoại không được rỗng!");
                            error++;
                        }
                        else
                        {
                            gridView1.SetColumnError(col, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;
                }

                if (error > 0)
                    return false;
            }
            //            gridView1.ClearColumnErrors();
            return true;
        }

        bool validateGrid(int preRow)
        {
            int error = 0;
            KhachHang_View lk = gridView1.GetRow(preRow) as KhachHang_View;
            if (lk != null)
            {
                if (lk.TenKhachHang == null || lk.TenKhachHang.Trim().Equals("") || lk.MaLoaiKhachHang == null || lk.SoDienThoai == null)
                {
                    gridView1.FocusedRowHandle = preRow;
                    MessageBox.Show("Chưa nhập đầy đủ thông tin!");
                    error++;
                }
                if (lk.TenKhachHang == null || lk.TenKhachHang.Trim().Equals(""))
                {
                    gridView1.SetColumnError(gridView1.Columns["TenKhachHang"], "Tên Khách hàng không được rỗng!");
                }

                if (lk.MaLoaiKhachHang == null)
                {
                    gridView1.SetColumnError(gridView1.Columns["MaLoaiKhachHang"], "Loại Khách hàng không được rỗng!");
                }
                if (lk.SoDienThoai == null)
                {
                    gridView1.SetColumnError(gridView1.Columns["SoDienThoai"], "Số điện thoại không được rỗng!");
                }
                if (error > 0)
                    return false;
            }

            gridView1.ClearColumnErrors();
            return true;
        }

        private void add_Row()
        {
            if (validateGrid(gridView1.FocusedRowHandle))
            {
                KhachHang_View lk = gridThaoTac.addRow(count_row) as KhachHang_View;
                gridThaoTac.refreshData();
                count_row++;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            gridThaoTac.addRow(count_row);
            count_row += 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataUpdate<KhachHang_View> listUpdate = gridThaoTac.update();

                if (KhachHang_DAL.saves(listUpdate))
                {
                    MessageBox.Show("Lưu thông tin thành công!");
                    InitVal();
                    count_row = 0;
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại!");
                }
            }         
        }

        void btnXoa_Grid_Click(object sender, EventArgs e)
        {
            if (!gridThaoTac.isDeleted()) gridThaoTac.Delete();
            else
                gridThaoTac.Undo();
        }

    }
}
