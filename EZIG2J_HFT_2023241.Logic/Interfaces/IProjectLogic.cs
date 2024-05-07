using EZIG2J_HFT_2023241.Models;
using System.Linq;

namespace EZIG2J_HFT_2023241.Logic
{
    public interface IProjectLogic
    {
        void Create(Project item);
        void Delete(int id);
        Project Read(int id);
        IQueryable<Project> ReadAll();
        void Update(Project item);
    }
}