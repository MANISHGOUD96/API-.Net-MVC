using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK_API_WebMVC.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Age { get; set; }
        public string Adress { get; set; }
        public string Company { get; set; }
        public double? Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Addhar { get; set; }
    }
}