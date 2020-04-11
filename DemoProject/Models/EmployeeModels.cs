using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
    public class EmployeeModels
    {

        public int Id { get; set; }
        public string EmpoyeeName { get; set; }
        public int DepartmentId { get; set; }
        public double Salary { get; set; }
        public int RowStatus { get; set; }
        public string DepartmentName { get; set; }
        public List<DepartmentModels> dpModels { get; set; }
    }
}