using System.ComponentModel;
using System.Globalization;

namespace EmployeesProject
{
    public class EmployeeRecord
    {
        public int EmpID { get; set; }
        public int ProjectID { get; set; }

        [TypeConverter(typeof(CustomDateTimeConverter))]
        public DateTime DateFrom { get; set; }

        [TypeConverter(typeof(CustomDateTimeConverter))]
        public DateTime? DateTo { get; set; }
    }

    public class CustomDateTimeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string strValue)
            {
                if (DateTime.TryParse(strValue, out DateTime dateValue))
                {
                    return dateValue;
                }
                else if (string.Equals(strValue, "NULL", StringComparison.OrdinalIgnoreCase))
                {
                    return DateTime.Today;
                }
                throw new FormatException($"Cannot convert '{strValue}' to DateTime.");
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
