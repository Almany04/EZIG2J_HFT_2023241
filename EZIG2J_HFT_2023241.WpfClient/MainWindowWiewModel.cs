using EZIG2J_HFT_2023241.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EZIG2J_HFT_2023241.WpfClient
{
    public class MainWindowWiewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Employee> employees { get; set; }
        private Employee selectedEmployee;

        public Employee SelectedEmployee { 

            get { return selectedEmployee; }
            set
            {
                if (value != null)
                {
                    selectedEmployee = new Employee()
                    {
                        Name = value.Name,
                        EmployeeId = value.EmployeeId
                    };
                    OnPropertyChanged();
                    (DeleteEmployeeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateEmployeeCommand { get; set; }

        public ICommand DeleteEmployeeCommand { get; set; }

        public ICommand UpdateEmployeeCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowWiewModel()
        {
            if (!IsInDesignMode)
            {
                employees = new RestCollection<Employee>("http://localhost:39574/", "employee", "hub");
                CreateEmployeeCommand = new RelayCommand(() =>
                {
                    employees.Add(new Employee()
                    {
                        Name = SelectedEmployee.Name
                    });
                });

                UpdateEmployeeCommand = new RelayCommand(() =>
                {
                    try
                    {
                        employees.Update(SelectedEmployee);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteEmployeeCommand = new RelayCommand(() =>
                {
                    employees.Delete(SelectedEmployee.EmployeeId);
                },
                () =>
                {
                    return SelectedEmployee != null;
                });
                SelectedEmployee = new Employee();
            }
        }
    }
}
