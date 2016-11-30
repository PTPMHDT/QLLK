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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace PresentationLayer
{
    public partial class UCLinhKien : UserControl
    {
        GridHelper<LinhKien_View> gridThaoTac;

        public UCLinhKien()
        {
            InitializeComponent();
            InitVal();
            btnXoa_Grid.Click += btnXoa_Grid_Click;
            gridView1.ValidatingEditor += gridView1_ValidatingEditor;
            gridView1.ValidateRow += gridView1_ValidateRow;
        }

        void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //GridView view = sender as GridView;
            //GridColumn tenLK_Col = view.Columns["TenLinhKien"];
            //string thuongHieu_Col = view.Columns["MaThuongHieu"].SummaryText ;
            
            //string tenLK = view.GetRowCellValue(e.RowHandle, tenLK_Col).ToString().Trim();
            //if(tenLK.Equals(""))
            //{
            //    view.SetColumnError(tenLK_Col, "Tên Linh Kiện không được rỗng!");
            //}  
        }

        void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            string fieldName = view.FocusedColumn.FieldName;
            switch (fieldName)
            {
                case "TenLinhKien":
                    if(e.Value.ToString().Trim().Equals(""))
                    {
                        e.Valid = false;
                        e.ErrorText = "Nhập vào tên Linh Kiện";
                    }
                    break;
                default:
                    break;
            }
            
        }

        private void InitVal()
        {
            gridControl1.DataSource = LinhKien_DAL.getAll_LinhKien();

            gridThaoTac = new GridHelper<LinhKien_View>(gridControl1);
            gridThaoTac.Mapping("MaThuongHieu", ThuongHieu_DAL.getAll_ThuongHieu());
            gridThaoTac.Mapping("MaNhaCungCap", NhaCungCap_DAL.getAll_NhaCungCap());
            gridThaoTac.Mapping("MaDonViTinh", DonViTinh_DAL.getAll_DonViTinh());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            gridThaoTac.addRow();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataUpdate<LinhKien_View> listUpdate = gridThaoTac.update();

                if (LinhKien_DAL.saves(listUpdate))
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

        void btnXoa_Grid_Click(object sender, EventArgs e)
        {
            if (!gridThaoTac.isDeleted()) gridThaoTac.Delete();
            else
                gridThaoTac.Undo();
        }

    }
}
