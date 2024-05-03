using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Linq;

namespace EZIG2J_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IRepository<Employee> repo = new EmployeeRepository(new EmployeeDbContext() );
            var items =repo.ReadAll().ToArray();
            
             
        }
    }
}
