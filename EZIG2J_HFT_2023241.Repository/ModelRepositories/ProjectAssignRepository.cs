using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Repository
{
    public class ProjectAssignRepository : Repository<ProjectAssignment>, IRepository<ProjectAssignment>
    {
        public ProjectAssignRepository(EmployeeDbContext ctx) : base(ctx)
        {
        }

        public override ProjectAssignment Read(int id)
        {
            return ctx.ProjectAssignments.FirstOrDefault(t => t.ProjectAssignmentId == id);
        }

        public override void Update(ProjectAssignment item)
        {
            var old = Read(item.ProjectAssignmentId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
