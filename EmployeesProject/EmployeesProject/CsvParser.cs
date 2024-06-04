namespace EmployeesProject
{
    public static class CsvParser
    {
        private static readonly string[] dateFormats = {
         "yyyy-MM-dd",
         "MM/dd/yyyy",
         "yyyy/MM/dd",
         "yyyy-MM-dd HH:mm:ss", // Date with time in 24-hour format
         "MM/dd/yyyy HH:mm:ss", // Date with time in 12-hour format
         "yyyy/MM/dd HH:mm:ss",
         "yyyy-MM-ddTHH:mm:ss", // ISO 8601 format
         "yyyy-MM-ddTHH:mm:ssZ", // ISO 8601 format with UTC offset
         "yyyy-MM-ddTHH:mm:ss.fffffff", // ISO 8601 format with fractional seconds
         "yyyy-MM-ddTHH:mm:ss.fffffffZ",
         "MM/dd/yyyyTHH:mm:ss",
         "MM/dd/yyyyTHH:mm:ssZ",
         "MM/dd/yyyyTHH:mm:ss.fffffff",
         "MM/dd/yyyyTHH:mm:ss.fffffffZ",
         "yyyy/MM/ddTHH:mm:ss",
         "yyyy/MM/ddTHH:mm:ssZ",
         "yyyy/MM/ddTHH:mm:ss.fffffff",
         "yyyy/MM/ddTHH:mm:ss.fffffffZ",
         "dd-MM-yyyy",
         "dd/MM/yyyy",
         "dd.MM.yyyy",
         "dd-MM-yyyy HH:mm:ss",
         "dd/MM/yyyy HH:mm:ss",
         "dd.MM.yyyy HH:mm:ss",
         "dd-MM-yyyyTHH:mm:ss",
         "dd/MM/yyyyTHH:mm:ss",
         "dd.MM.yyyyTHH:mm:ss",
         "dd-MM-yyyyTHH:mm:ssZ",
         "dd/MM/yyyyTHH:mm:ssZ",
         "dd.MM.yyyyTHH:mm:ssZ",
         "dd-MM-yyyyTHH:mm:ss.fffffff",
         "dd/MM/yyyyTHH:mm:ss.fffffff",
         "dd.MM.yyyyTHH:mm:ss.fffffff",
         "dd-MM-yyyyTHH:mm:ss.fffffffZ",
         "dd/MM/yyyyTHH:mm:ss.fffffffZ",
         "dd.MM.yyyyTHH:mm:ss.fffffffZ"
        };

        public static List<EmployeeRecord> ParseCsv(string filePath)
        {
            var records = new List<EmployeeRecord>();

            foreach (var line in File.ReadLines(filePath))
            {
                var values = line.Split(',');
                if (values.Length != 4) continue;

                var empID = int.Parse(values[0].Trim());
                var projectID = int.Parse(values[1].Trim());
                var dateFrom = ParseDate(values[2].Trim());
                var dateTo = ParseDate(values[3].Trim());

                var record = new EmployeeRecord
                {
                    EmpID = empID,
                    ProjectID = projectID,
                    DateFrom = dateFrom,
                    DateTo = dateTo
                };

                records.Add(record);
            }

            return records;
        }

        private static DateTime ParseDate(string dateString)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(dateString, dateFormats, null, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }
            else if (dateString.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            {
                return DateTime.Now;
            }
            throw new FormatException($"Cannot parse '{dateString}' as a valid date.");
        }
    }
}
