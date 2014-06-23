using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
namespace BLL
{
    public static class cls_funciones
    {
        public static DataTable AsDataTable<T>(this IEnumerable<T> enumberable)
        {
            DataTable table = new DataTable("Generated");
            T first = enumberable.FirstOrDefault<T>();
            DataTable result;
            if (first == null)
            {
                result = table;
            }
            else
            {
                PropertyInfo[] properties = first.GetType().GetProperties();
                PropertyInfo[] array = properties;
                for (int i = 0; i < array.Length; i++)
                {
                    PropertyInfo pi = array[i];
                    Type columnType = pi.PropertyType;
                    if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        columnType = pi.PropertyType.GetGenericArguments()[0];
                    }
                    table.Columns.Add(new DataColumn(pi.Name, columnType));
                }
                foreach (T t in enumberable)
                {
                    DataRow row = table.NewRow();
                    array = properties;
                    for (int i = 0; i < array.Length; i++)
                    {
                        PropertyInfo pi = array[i];
                        Type valueType = pi.GetType();
                        row[pi.Name] = t.GetType().InvokeMember(pi.Name, BindingFlags.GetProperty, null, t, null);
                    }
                    table.Rows.Add(row);
                }
                result = table;
            }
            return result;
        }
    }
}
