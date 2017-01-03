﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.ViewObject;
using PresentationLayer.DAL;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using PresentationLayer.GlobalVariable;

namespace PresentationLayer
{
    public partial class UCLoaiNhanVien : UserControl
    {
        GridHelper<LoaiNhanVien_ViewBoolen> gridThaoTac;
        int count_row = 0;
        int prvRowFocus = 0;

        public UCLoaiNhanVien()
        {
            InitializeComponent();
            //gridView1.FocusedRowChanged += gridView1_FocusedRowChanged; ;
            //gridView1.FocusedColumnChanged += gridView1_FocusedColumnChanged;
            //gridView1.ValidatingEditor += gridView1_ValidatingEditor;
            InitVal();
            gridView1.KeyDown += gridView1_KeyDown;
            btnXoa.Click+=btnXoa_Click;
        }

        void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int r = gridView1.FocusedRowHandle;
                int count = gridView1.RowCount;
                if (r == count - 1 & gridView1.FocusedColumn.FieldName.Equals("MoTa"))
                {
                    add_Row();
                }
            }
        }

        void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            string fieldName = view.FocusedColumn.FieldName;
            switch (fieldName)
            {
                case "TenNhanVien":
                    if (e.Value.ToString().Trim().Equals(""))
                    {
                        e.Valid = false;
                        e.ErrorText = "Nhập vào tên Nhân Viên";
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

        void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            validateGrid(e.PrevFocusedColumn);            
        }

        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.PrevFocusedRowHandle >= 0)
                prvRowFocus = e.PrevFocusedRowHandle;
            validateGrid(prvRowFocus);
        }

        private void InitVal()
        {
            gridControl1.DataSource = LoaiNhanVien_DAL.getAll_LoaiNhanVien();
            gridThaoTac = new GridHelper<LoaiNhanVien_ViewBoolen>(gridControl1);
            count_row = 0;
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            if (!gridThaoTac.isDeleted()) gridThaoTac.Delete();
            else
                gridThaoTac.Undo();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataUpdate<LoaiNhanVien_ViewBoolen> listUpdate = gridThaoTac.update();

                if (LoaiNhanVien_DAL.saves(listUpdate))
                {
                    MessageBox.Show("Lưu thông tin thành công!");
                    InitVal();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại!");
                }
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            gridThaoTac.addRow(count_row);
            count_row += 1;
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

        bool validateGrid(GridColumn col)
        {
            int error = 0;
            NhanVien_View lk = gridView1.GetFocusedRow() as NhanVien_View;
            if (lk != null)
            {
                switch (col.FieldName)
                {
                    case "TenNhanVien":
                        if (lk.TenNhanVien == null || lk.TenNhanVien.Trim().Equals(""))
                        {
                            gridView1.SetColumnError(gridView1.Columns["TenNhanVien"], "Tên Nhân viên không được rỗng!");
                            error++;
                        }
                        else
                        {
                            gridView1.SetColumnError(col, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;
                    case "MaLoaiNhanVien":
                        if (lk.MaLoaiNhanVien == null)
                        {
                            gridView1.SetColumnError(gridView1.Columns["MaLoaiNhanVien"], "Loại Nhân viên không được rỗng!");
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
            NhanVien_View lk = gridView1.GetRow(preRow) as NhanVien_View;
            if (lk != null)
            {
                if (lk.TenNhanVien == null || lk.TenNhanVien.Trim().Equals("") || lk.MaLoaiNhanVien == null || lk.SoDienThoai == null)
                {
                    gridView1.FocusedRowHandle = preRow;
                    MessageBox.Show("Chưa nhập đầy đủ thông tin!");
                    error++;
                }
                if (lk.TenNhanVien == null || lk.TenNhanVien.Trim().Equals(""))
                {
                    gridView1.SetColumnError(gridView1.Columns["TenNhanVien"], "Tên Nhân viên không được rỗng!");
                }

                if (lk.MaLoaiNhanVien == null)
                {
                    gridView1.SetColumnError(gridView1.Columns["MaLoaiNhanVien"], "Loại Nhân viên không được rỗng!");
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
    }
}
