using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Repository
{
    public class DepartmentRepository : Repository<Department>, IRepository<Department>
    {
        public DepartmentRepository(EmployeeDbContext ctx) : base(ctx)
        {
        }

        public override Department Read(int id)
        {
            return ctx.Departments.FirstOrDefault(t => t.DepartmentId == id);
        }

        public override void Update(Department item)
        {
            var old = Read(item.DepartmentId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
