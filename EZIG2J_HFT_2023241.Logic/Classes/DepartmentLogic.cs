using EZIG2J_HFT_2023241.Logic.Interfaces;
using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Logic.Classes
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
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Department Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Department> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Department item)
        {
            repo.Update(item);
        }

    }
}
