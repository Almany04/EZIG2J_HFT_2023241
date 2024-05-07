using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Logic
{
    public class DepartmentLogic : IDepartmentLogic
    {
        IRepository<Department> repo;

        public DepartmentLogic(IRepository<Department> repo)
        {
            this.repo = repo;
        }

        public void Create(Department item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Department Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Department> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Department item)
        {
            this.repo.Update(item);
        }

    }
}
