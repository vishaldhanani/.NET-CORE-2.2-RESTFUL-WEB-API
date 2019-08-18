using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Employee
    {
        //[Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //public Int64 Phone { get; set; }
        //public Int64 Salary { get; set; }
    }
}
