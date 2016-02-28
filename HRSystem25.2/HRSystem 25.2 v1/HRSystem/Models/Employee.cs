using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int? BossEmployeeID { get; set; }
        public int RoleID { get; set; }
        public int? ProjectID { get; set; }

    
        public int SalaryAmount { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("BossEmployeeID")]
        public virtual Employee BossEmployee { get; set; }
        public virtual Role Role { get; set; }
        public virtual Project Project { get; set; }
    }
}