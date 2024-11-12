using EZIG2J_HFT_2023241.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.WpfClient
{
    public class MainWindowWiewModel
    {
        public RestCollection<Employee> employees { get; set; }
        public MainWindowWiewModel()
        {
            employees = new RestCollection<Employee>("http://localhost:39574/", "employee");
        }
    }
}
