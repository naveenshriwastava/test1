using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
    public class DepartmentModels
    {

        public int Id { get; set; }
        public string DepartName { get; set; }
        public int RowStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}