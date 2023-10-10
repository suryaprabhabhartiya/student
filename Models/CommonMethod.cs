using System.ComponentModel;
using System.Data;

namespace student.Models
{
    public static class CommonMethod
    {
        public static DataTable ConvertListToDataTable<T>(this IList<T> Data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name,prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in Data) 
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }


    }
}
