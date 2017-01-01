using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PresentationLayer.DAL;
using PresentationLayer.ViewObject;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Globalization;

namespace PresentationLayer.Viewer
{
    public partial class Add_LinhKien : DevExpress.XtraEditors.XtraForm
    {
        GridHelper<LinhKien_View> gridThaoTac;
        int count_row;
        string maNCC = "";
        int prvRowFocus = 0;

        public Add_LinhKien()
        {
            InitializeComponent();
            InitVal();
            btnXoa_Grid.Click += btnXoa_Grid_Click;
        }

        public Add_LinhKien(string maNCC)
        {
            InitializeComponent();
            this.Load += Add_LinhKien_Load;
            this.maNCC = maNCC;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.FocusedColumnChanged += gridView1_FocusedColumnChanged;
            InitVal();
            btnXoa_Grid.Click += btnXoa_Grid_Click;
            gridView1.ValidatingEditor += gridView1_ValidatingEditor;
        }

        void Add_LinhKien_Load(object sender, EventArgs e)
        {
            this.text_money.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.text_money.DisplayFormat.Format = new CultureInfo("vi-VN");
            this.text_money.DisplayFormat.FormatString = "c";
        }

        void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            validateGrid(e.PrevFocusedColumn);
        }

        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(e.PrevFocusedRowHandle >= 0)
            {
                prvRowFocus = e.PrevFocusedRowHandle;
                validateGrid(prvRowFocus);
            }
        }

        void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            string fieldName = view.FocusedColumn.FieldName;
            switch (fieldName)
            {
                case "TenLinhKien":
                    if (e.Value.ToString().Trim().Equals(""))
                    {
                        e.Valid = false;
                        e.ErrorText = "Nhập vào tên Linh Kiện";
                    }
                    break;
                default:
                    break;
            }
        }

        bool validateGrid(GridColumn col)
        {
            int error = 0;
            LinhKien_View lk = gridView1.GetFocusedRow() as LinhKien_View;
            if (lk != null)
            {
                switch (col.FieldName)
                {
                    case "TenLinhKien":
                        if (lk.TenLinhKien == null)
                        {
                            gridView1.SetColumnError(col, "Tên Linh Kiện không được rỗng!");
                            error++;
                        }
                        else
                        {
                            gridView1.SetColumnError(col, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;
                    case "MaThuongHieu":
                        if (lk.MaThuongHieu == null)
                        {
                            gridView1.SetColumnError(col, "Thương hiệu không được rỗng!");
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
            LinhKien_View lk = gridView1.GetFocusedRow() as LinhKien_View;
            if (lk != null)
            {
                if (lk.TenLinhKien == null || lk.TenLinhKien.Trim().Equals("") || lk.MaThuongHieu == null || lk.MaNhaCungCap == null)
                {
                    gridView1.FocusedRowHandle = preRow;
                    MessageBox.Show("Chưa nhập đầy đủ thông tin!");
                    error++;
                }
                if (lk.TenLinhKien == null)
                {
                    gridView1.SetColumnError(gridView1.Columns["TenLinhKien"], "Tên Linh Kiện không được rỗng!");
                }

                if (lk.MaThuongHieu == null)
                {
                    gridView1.SetColumnError(gridView1.Columns["MaThuongHieu"], "Thương hiệu không được rỗng!");
                }


                if (error > 0)
                    return false;
            }

            gridView1.ClearColumnErrors();
            return true;
        }

        private void InitVal()
        {
            gridControl1.DataSource = new List<LinhKien_View>();
            gridThaoTac = new GridHelper<LinhKien_View>(gridControl1);
            gridThaoTac.Mapping("MaThuongHieu", ThuongHieu_DAL.getAll_ThuongHieu());
            gridThaoTac.Mapping("MaNhaCungCap", NhaCungCap_DAL.getAll_NhaCungCap());
            gridThaoTac.Mapping("MaDonViTinh", DonViTinh_DAL.getAll_DonViTinh());
            count_row = 0;

            add_Row();
        }

        private void btnXoa_Grid_Click(object sender, EventArgs e)
        {
            if (!gridThaoTac.isDeleted()) gridThaoTac.Delete();
            else
                gridThaoTac.Undo();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (validateGrid(gridView1.FocusedRowHandle))
            {
                var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DataUpdate<LinhKien_View> listUpdate = gridThaoTac.update();

                    if (LinhKien_DAL.saves(listUpdate))
                    {
                        MessageBox.Show("Lưu thông tin thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin thất bại!");
                    }
                }  
            }
            else
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin!");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bnt_AddRow_Click(object sender, EventArgs e)
        {
            add_Row();
        }

        private void add_Row()
        {
            if (validateGrid(gridView1.FocusedRowHandle))
            {
                LinhKien_View lk = gridThaoTac.addRow(count_row) as LinhKien_View;
                lk.MaNhaCungCap = maNCC;
                lk.MaDonViTinh = "DVT001";
                gridThaoTac.refreshData();
                count_row++;
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
            {
                int r = gridView1.FocusedRowHandle;
                int count = gridView1.RowCount;
                if (r == count - 1 & gridView1.FocusedColumn.FieldName.Equals("MoTa"))
                {
                    add_Row();
                }
            }
        }

    }
}