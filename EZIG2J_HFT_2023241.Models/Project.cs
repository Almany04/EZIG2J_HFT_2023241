using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }

        public Project()
        {

        }

        public Project(string line)
        {
            string[] split = line.Split('#');
            ProjectId = int.Parse(split[0]);
            Title = split[1];
            StartDate = DateTime.Parse(split[2].Replace('*', '.'));
            EndDate = DateTime.Parse(split[3].Replace('*', '.'));
        }
    }
}
