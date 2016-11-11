using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer
{
    public class GridHelper<T>
    {
        DevExpress.XtraGrid.GridControl gc;
        GridView mainView;

        public GridHelper(DevExpress.XtraGrid.GridControl gc)
        {
            this.gc = gc;
            mainView = gc.MainView as GridView;
            mainView.CellValueChanged += mainView_CellValueChanged;
        }

        void mainView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CGrid tmp = mainView.GetFocusedRow() as CGrid;
            if ((tmp.Mode == TT.NEW)
                || (tmp.Mode == TT.DELETE)) return;

            if (tmp.isChanged())
            {
                tmp.Mode = TT.UPDATE;
            }
            else
            {
                if (tmp.Mode == TT.UPDATE)
                {
                    tmp.Mode = TT.NONE;
                }
            }

            mainView.RefreshData();
        }

        public List<T> getDatas()
        {
            return gc.DataSource as List<T>;
        }

        public bool isDeleted()
        {
            CGrid tmp = mainView.GetFocusedRow() as CGrid;
            if (tmp.Mode == TT.DELETE) return true;
            return false;
        }

        public void addRow()
        {
            CGrid cData = CGrid.Create<T>();
            cData.Mode = TT.NEW;
            getDatas().Add(cData.ToType<T>());
            mainView.RefreshData();
        }

        public DataUpdate<T> update()
        {
            DataUpdate<T> dt = new DataUpdate<T>();
            List<T> list = getDatas();
            foreach (var item in list)
            {
                CGrid cgrid = item as CGrid;

                switch (cgrid.Mode)
                {
                    case TT.NEW:
                        dt.Inserts.Add(item);
                        break;
                    case TT.UPDATE:
                        dt.Updates.Add(item);
                        break;
                    case TT.DELETE:
                        dt.Deletes.Add(item);
                        break;
                }
            }

            return dt;
        }

        public void Delete()
        {
            CGrid tmp = mainView.GetFocusedRow() as CGrid;
            if (tmp.Mode == TT.NEW)
                getDatas().Remove(tmp.ToType<T>());
            else
            {
                tmp.Mode = TT.DELETE;

            }
            mainView.RefreshData();
        }

        public void Undo()
        {
            CGrid tmp = mainView.GetFocusedRow() as CGrid;
            if (tmp.Mode == TT.DELETE)
            {
                if (tmp.isChanged())
                {
                    tmp.Mode = TT.UPDATE;
                }
                else
                    tmp.Mode = TT.NONE;
                mainView.RefreshData();
            }
        }

        public void Mapping(string FieldName, Object ListDatas)
        {
            Type[] ts = ListDatas.GetType().GetGenericArguments();
            if (ts.Length <= 0) return;
            Type t = ts[0];
            string id = "";
            string name = "";
            string captionName = "";
            var prop = t.GetProperties().Where(p => Attribute.IsDefined(p, typeof(DisplaySelectionAttribute))).FirstOrDefault();
            if (prop != null)
            {
                name = prop.Name;
                captionName = prop.GetCustomAttributesData()[0].ConstructorArguments[0].Value.ToString();
            }
            prop = t.GetProperties().Where(p => Attribute.IsDefined(p, typeof(IdSelectionAttribute))).FirstOrDefault();
            if (prop != null)
                id = prop.Name;
            RepositoryItemLookUpEdit lk = new RepositoryItemLookUpEdit();

            lk.ValueMember = id;
            lk.DisplayMember = name;
            lk.DataSource = ListDatas;
            lk.NullText = string.Empty;
            LookUpColumnInfo lok = new DevExpress.XtraEditors.Controls.LookUpColumnInfo(name, captionName);
            lok.Visible = true;
            lk.Columns.Add(lok);
            var columnEdit = mainView.Columns.Where(item => item.FieldName == FieldName).FirstOrDefault();
            if (columnEdit != null) columnEdit.ColumnEdit = lk;
        }
    }
}
