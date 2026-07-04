using System.Reflection;
using System.Text;

namespace HW26.Serializers
{
    public class CSVSerializer : IMySerialize
    {
        public string Serialize<T>(T objT)
        {
            if (objT == null) return string.Empty;

            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder headers = new ();
            StringBuilder values = new ();

            for (int i = 0; i < properties.Length; i++)
            {
                headers.Append(properties[i].Name);
                values.Append(properties[i].GetValue(objT));

                if (i < properties.Length - 1)
                {
                    headers.Append(",");
                    values.Append(",");
                }
            }

            return $"{headers}\n{values}";
        }
        public T? Deserialize<T>(string csvText) where T : new()
        {
            if (string.IsNullOrWhiteSpace(csvText)) return default;

            string[] rows = csvText.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
            if (rows.Length < 2) return default;

            string[] headers = rows[0].Split(',');
            string[] values = rows[1].Split(',');

            T objT = new ();
            Type typeT = typeof(T);

            for (int i = 0; i < headers.Length; i++)
            {
                PropertyInfo? property = typeT.GetProperty(headers[i].Trim());
                if (property != null && i < values.Length)
                {
                    object typedValue = Convert.ChangeType(values[i].Trim(), property.PropertyType);
                    property.SetValue(objT, typedValue);
                }
            }
            return objT;
        }
    }
}
