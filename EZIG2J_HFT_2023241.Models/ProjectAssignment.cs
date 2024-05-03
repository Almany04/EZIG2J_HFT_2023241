using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Models
{
    public class ProjectAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectAssignmentId { get; set; }

        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Project Project { get; set; }

        public ProjectAssignment()
        {

        }

        public ProjectAssignment(string line)
        {
            string[] split = line.Split('#');
            ProjectAssignmentId = int.Parse(split[0]);
            EmployeeId = int.Parse(split[1]);
            ProjectId = int.Parse(split[2]);
        }
    }
}
