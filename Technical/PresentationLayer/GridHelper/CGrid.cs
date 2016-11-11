using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PresentationLayer
{
    public enum TT
    {
        NONE = 0,
        NEW = 1,
        UPDATE = 2,
        DELETE = 3
    }
    public class CGrid
    {
        public TT Mode { get; set; }
        public CGrid OldData;
        public CGrid()
        {
            Mode = TT.NONE;
            OldData = null;
           
        }
        public CGrid InitOldData()
        {
            Mode = TT.NONE;   
            Type type = this.GetType();
            OldData = Create(type);
           
            PropertyInfo[] fields = type.GetProperties();
            PropertyInfo[] oldDataFields = OldData.GetType().GetProperties();

            for (int i = 0; i < fields.Length; i++)
            {
                if ((oldDataFields[i].Name != "TrangThai") && (oldDataFields[i].Name != "OldData"))
                {
                    oldDataFields[i].SetValue(OldData, fields[i].GetValue(this, null), null);
                }
            }
            return this;
        }
        public bool isChanged()
        {
            PropertyInfo[] fields = OldData.GetType().GetProperties();
            PropertyInfo[] thisFields = this.GetType().GetProperties();

            for (int i = 0; i < fields.Length; i++)
            {
                if ((thisFields[i].Name != "Mode") && (thisFields[i].Name != "OldData"))
                {
                    var current = thisFields[i].GetValue(this, null);
                    var old = fields[i].GetValue(OldData, null);
                    if (current == null) current = "";
                    if (old == null) old = "";

                    if (!current.Equals(old))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static CGrid Create<T>()
        {
           return (CGrid)Activator.CreateInstance(typeof(T));
        }
        public static CGrid Create(Type type)
        {
            return (CGrid)Activator.CreateInstance(type);
        }
        public T ToType<T>()
        {
            return (T)Convert.ChangeType(this, typeof(T));
        }
    }
    public class DataUpdate<T>
    {
        public List<T> Inserts;
        public List<T> Updates;
        public List<T> Deletes;

        public DataUpdate()
        {
            this.Inserts = new List<T>();
            this.Updates = new List<T>();
            this.Deletes = new List<T>();
        }
    }
}
