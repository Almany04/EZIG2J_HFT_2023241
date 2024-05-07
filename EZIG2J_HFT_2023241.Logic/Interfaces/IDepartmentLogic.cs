using EZIG2J_HFT_2023241.Models;
using System.Linq;

namespace EZIG2J_HFT_2023241.Logic.Interfaces
{
    public interface IDepartmentLogic
    {
        void Create(Department item);
        void Delete(int id);
        Department Read(int id);
        IQueryable<Department> ReadAll();
        void Update(Department item);
    }
}