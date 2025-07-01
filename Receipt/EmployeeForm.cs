using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Receipt
{
    public partial class EmployeeForm : Form
    {
        public List<string> Employees { get; private set; }
        private const string EmployeeFilePath = "Files/Employee.txt";

        public EmployeeForm(List<string> employees)
        {
            InitializeComponent();
            Employees = employees;
            UpdateEmployeeList();
        }

        private void UpdateEmployeeList()
        {
            listBoxEmployees.Items.Clear();
            EnsureEmployeeDirectoryExists();
            if (File.Exists(EmployeeFilePath))
            {
                Employees = new List<string>(File.ReadAllLines(EmployeeFilePath));
            }
            foreach (var employee in Employees)
            {
                listBoxEmployees.Items.Add(employee);
            }
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxEmployeeName.Text))
            {
                Employees.Add(textBoxEmployeeName.Text);
                SaveEmployees(Employees);
                UpdateEmployeeList();
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            SaveEmployees(Employees);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (listBoxEmployees.SelectedItem != null)
            {
                Employees.Remove(listBoxEmployees.SelectedItem.ToString());
                SaveEmployees(Employees);
                UpdateEmployeeList();
            }
        }

        private void SaveEmployees(List<string> employees)
        {
            EnsureEmployeeDirectoryExists();
            File.WriteAllLines(EmployeeFilePath, employees);
        }

        private void EnsureEmployeeDirectoryExists()
        {
            if (!Directory.Exists("Files"))
            {
                Directory.CreateDirectory("Files");
            }
        }
    }
}