using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace EZIG2J_HFT_2023241.Logic
{
    public class EmployeeLogic
    {
        IRepository<Employee> repo;

        public EmployeeLogic(IRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public void Create(Employee item)
        {
            if (item.Name.Length < 3)
            {
                throw new ArgumentException("The Name is too short..");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Employee Read(int id)
        {
            var employee = this.repo.Read(id);
            if (employee == null)
            {
                throw new ArgumentException("This employee does not exists");
            }
            return employee;

        }

        public IQueryable<Employee> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Employee item)
        {
            this.repo.Update(item);
        }

       
    }
}
