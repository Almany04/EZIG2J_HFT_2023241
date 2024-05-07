using EZIG2J_HFT_2023241.Models;
using System.Linq;

namespace EZIG2J_HFT_2023241.Logic
{
    public interface IProjectAssignmentLogic
    {
        void Create(ProjectAssignment item);
        void Delete(int id);
        ProjectAssignment Read(int id);
        IQueryable<ProjectAssignment> ReadAll();
        void Update(ProjectAssignment item);
    }
}