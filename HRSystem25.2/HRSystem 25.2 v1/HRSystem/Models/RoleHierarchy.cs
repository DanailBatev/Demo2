using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    public class RoleHierarchy
    {
        public int ID { get; set; }
        
        public int ChildRoleID { get; set; }
        public virtual Role ChildRole { get; set; }
        
        public int? ParentRoleID { get; set; }
        public virtual Role ParentRole { get; set; }


    }
}