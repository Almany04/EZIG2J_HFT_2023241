using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace EZIG2J_HFT_2023241.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        public int DepartmentId { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }

        public Employee()
        {

        }

        public Employee(string line)
        {
            string[] split = line.Split('#');
            EmployeeId = int.Parse(split[0]);
            Name = split[1];
            HireDate = DateTime.Parse(split[2].Replace('*', '.'));
            DepartmentId = int.Parse(split[3]);
        }

    }
}
