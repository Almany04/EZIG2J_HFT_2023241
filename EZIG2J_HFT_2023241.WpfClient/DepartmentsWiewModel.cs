using CommunityToolkit.Mvvm.Input;
using EZIG2J_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EZIG2J_HFT_2023241.WpfClient
{
    public class DepartmentsWiewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Department> departments { get; set; }
        private Department selectedDepartment;

        public Department SelectedDepartment
        {

            get { return selectedDepartment; }
            set
            {
                if (value != null)
                {
                    selectedDepartment = new Department()
                    {
                        Name = value.Name,
                        DepartmentId = value.DepartmentId
                    };
                    OnPropertyChanged();
                    (DeleteDepartmentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateDepartmentCommand { get; set; }

        public ICommand DeleteDepartmentCommand { get; set; }

        public ICommand UpdateDepartmentCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public DepartmentsWiewModel()
        {
            if (!IsInDesignMode)
            {
                departments = new RestCollection<Department>("http://localhost:39574/", "department", "hub");
                CreateDepartmentCommand = new RelayCommand(() =>
                {
                    departments.Add(new Department()
                    {
                        Name = SelectedDepartment.Name
                    });
                });

                UpdateDepartmentCommand = new RelayCommand(() =>
                {
                    try
                    {
                        departments.Update(SelectedDepartment);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteDepartmentCommand = new RelayCommand(() =>
                {
                    departments.Delete(SelectedDepartment.DepartmentId);
                },
                () =>
                {
                    return SelectedDepartment != null;
                });
                SelectedDepartment = new Department();
            }
        }
    }
}
