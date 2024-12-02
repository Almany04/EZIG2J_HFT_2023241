using CommunityToolkit.Mvvm.ComponentModel;
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

namespace EZIG2J_HFT_2023241.WpfClient
{
    public class ProjectsWiewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Project> projects { get; set; }
        private Project selectedProject;

        public Project SelectedProject
        {

            get { return selectedProject; }
            set
            {
                if (value != null)
                {
                    selectedProject = new Project()
                    {
                        Title = value.Title,
                        ProjectId = value.ProjectId
                    };
                    OnPropertyChanged();
                    (DeleteProjectCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateProjectCommand { get; set; }

        public ICommand DeleteProjectCommand { get; set; }

        public ICommand UpdateProjectCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ProjectsWiewModel()
        {
            if (!IsInDesignMode)
            {
                projects = new RestCollection<Project>("http://localhost:39574/", "projects");
                CreateProjectCommand = new RelayCommand(() =>
                {
                    projects.Add(new Project()
                    {
                        Title = SelectedProject.Title
                    });
                });

                UpdateProjectCommand = new RelayCommand(() =>
                {
                    try
                    {
                        projects.Update(SelectedProject);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteProjectCommand = new RelayCommand(() =>
                {
                    projects.Delete(SelectedProject.ProjectId);
                },
                () =>
                {
                    return SelectedProject != null;
                });
                SelectedProject = new Project();
            }
        }
    }
}
