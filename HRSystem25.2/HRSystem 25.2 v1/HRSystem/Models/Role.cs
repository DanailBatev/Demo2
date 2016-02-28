using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRSystem.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set;}
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
}