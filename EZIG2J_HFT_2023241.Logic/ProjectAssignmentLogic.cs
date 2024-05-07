using EZIG2J_HFT_2023241.Logic.Interfaces;
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
    public class ProjectAssignmentLogic : IProjectAssignmentLogic
    {
        IRepository<ProjectAssignment> repo;

        public ProjectAssignmentLogic(IRepository<ProjectAssignment> repo)
        {
            this.repo = repo;
        }

        public void Create(ProjectAssignment item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public ProjectAssignment Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<ProjectAssignment> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(ProjectAssignment item)
        {
            this.repo.Update(item);
        }
    }
}
