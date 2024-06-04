using CsvHelper;
using CsvHelper.Configuration;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace EmployeesProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Open CSV File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var records = CsvParser.ParseCsv(openFileDialog.FileName);
                var overlappingPeriods = CalculateOverlappingPeriods(records);
                DisplayResults(overlappingPeriods);
            }
        }

        
        static List<(EmployeeRecord, EmployeeRecord, int, int)> CalculateOverlappingPeriods(List<EmployeeRecord> records)
        {
            var overlappingPeriods = new List<(EmployeeRecord, EmployeeRecord, int, int)>();

            var groupedByProject = records.GroupBy(r => r.ProjectID);

            foreach (var group in groupedByProject)
            {
                var employees = group.ToList();
                for (int i = 0; i < employees.Count; i++)
                {
                    for (int j = i + 1; j < employees.Count; j++)
                    {
                        var overlap = GetOverlapPeriod(employees[i], employees[j]);
                        if (overlap.TotalDays > 0)
                        {
                            overlappingPeriods.Add((employees[i], employees[j], group.Key, (int)overlap.TotalDays));
                        }
                    }
                }
            }

            return overlappingPeriods;
        }

        static TimeSpan GetOverlapPeriod(EmployeeRecord emp1, EmployeeRecord emp2)
        {
            var start = emp1.DateFrom > emp2.DateFrom ? emp1.DateFrom : emp2.DateFrom;
            var end = emp1.DateTo < emp2.DateTo ? emp1.DateTo : emp2.DateTo;

            if (start < end)
            {
                return (TimeSpan)(end - start);
            }
            else
            {
                return TimeSpan.Zero;
            }
        }

        private void DisplayResults(List<(EmployeeRecord, EmployeeRecord, int, int)> overlappingPeriods)
        {
            dataGridViewResults.Rows.Clear();
            dataGridViewResults.Columns.Clear();

            dataGridViewResults.Columns.Add("EmpID1", "Employee ID #1");
            dataGridViewResults.Columns.Add("EmpID2", "Employee ID #2");
            dataGridViewResults.Columns.Add("ProjectID", "Project ID");
            dataGridViewResults.Columns.Add("DaysWorked", "Days Worked");

            foreach (var period in overlappingPeriods)
            {
                dataGridViewResults.Rows.Add(period.Item1.EmpID, period.Item2.EmpID, period.Item3, period.Item4);
            }
        }
    }

}
