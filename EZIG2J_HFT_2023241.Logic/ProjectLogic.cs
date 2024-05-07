﻿using EZIG2J_HFT_2023241.Logic.Interfaces;
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
    public class ProjectLogic : IProjectLogic
    {
        IRepository<Project> repo;

        public ProjectLogic(IRepository<Project> repo)
        {
            this.repo = repo;
        }

        public void Create(Project item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Project Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Project> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Project item)
        {
            this.repo.Update(item);
        }
    }
}