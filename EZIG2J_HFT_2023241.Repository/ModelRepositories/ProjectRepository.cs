using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Repository
{
    public class ProjectRepository : Repository<Project>, IRepository<Project>
    {
        public ProjectRepository(EmployeeDbContext ctx) : base(ctx)
        {
        }

        public override Project Read(int id)
        {
            return ctx.Projects.FirstOrDefault(t => t.ProjectId == id);
        }

        public override void Update(Project item)
        {
            var old = Read(item.ProjectId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
