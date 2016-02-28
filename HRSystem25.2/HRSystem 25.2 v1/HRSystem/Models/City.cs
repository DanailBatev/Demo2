using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRSystem.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}