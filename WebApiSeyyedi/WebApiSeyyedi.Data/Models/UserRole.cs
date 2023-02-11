﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSeyyedi.Data.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}
