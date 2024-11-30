using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EZIG2J_HFT_2023241.WpfClient
{
    public class StartWindowViewModel
    {
        public RelayCommand NavigateToEmployeesCommand { get; set; }
        public RelayCommand NavigateToProjectsCommand { get; set; }
        public RelayCommand NavigateToDepartmentsCommand { get; set; }

        public StartWindowViewModel()
        {
            NavigateToEmployeesCommand = new RelayCommand(() =>
            {
                var window = new MainWindow(); // Navigálás az Employee ablakhoz
                window.Show();
            });

            NavigateToProjectsCommand = new RelayCommand(() =>
            {
                var window2 = new Window1();
                window2.Show();
            });

          

            NavigateToDepartmentsCommand = new RelayCommand(() =>
            {
                var window3 = new Departments(); 
                window3.Show();
            });
        }
    }
}

