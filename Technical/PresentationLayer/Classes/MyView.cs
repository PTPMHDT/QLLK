using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PresentationLayer.Classes
{
   public class MyView
    {
        public MyView(Object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] fields = type.GetProperties();
            PropertyInfo[] thisFields = this.GetType().GetProperties();

            for (int i = 0; i < fields.Length; i++)
            {
                thisFields[i].SetValue(this, fields[i].GetValue(obj, null), null);
            }
        }
        public MyView()
        {

        }
        
        public static List<T> from<T>(Object list)
        {
            List<T> temp = new List<T>();

            IEnumerable enumerable = list as IEnumerable;
            if (enumerable != null)
            {
                foreach (object element in enumerable)
                {

                    T nguoidung = (T)Activator.CreateInstance(typeof(T), element);
                    temp.Add(nguoidung);
                }
            }
            return temp;
        }
    }
}
