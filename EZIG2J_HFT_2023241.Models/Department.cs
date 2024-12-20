﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EZIG2J_HFT_2023241.Models
{
   public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public Department(string line)
        {
            string[] split = line.Split('#');
            DepartmentId = int.Parse(split[0]);
            Name = split[1];
            Employees = new HashSet<Employee>();
        }
    }
}
