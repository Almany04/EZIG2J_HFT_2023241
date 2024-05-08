using EZIG2J_HFT_2023241.Logic;
using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static EZIG2J_HFT_2023241.Logic.EmployeeLogic;

namespace EZIG2J_HFT_2023241.Test
{
    [TestFixture]
    public class EmployeeLogicTester
    {
        EmployeeLogic logic;
        Mock<IRepository<Employee>> mockEmployeeRepo;

        [SetUp]
        public void Init()
        {
            mockEmployeeRepo = new Mock<IRepository<Employee>>();
            mockEmployeeRepo.Setup(e => e.ReadAll()).Returns(new List<Employee>()
            {
                new Employee("1#John Doe#2008*05*02#1"),
                new Employee("2#Jane Doe#2009*05*02#1"),
                new Employee("3#Alice Smith#2009*05*02#2"),
                new Employee("4#Bob Johnson#2010*05*02#2"),
            }.AsQueryable());
            logic = new EmployeeLogic(mockEmployeeRepo.Object);
        }

        [Test]
        public void GetEmployeeCountOnProjectTest()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    ProjectAssignments = new List<ProjectAssignment>
                    {
                        new ProjectAssignment { ProjectId = 1, Project = new Project { ProjectId = 1, Title = "Project1", StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-10") } }
                    }
                },
                new Employee
                {
                    EmployeeId = 2,
                    ProjectAssignments = new List<ProjectAssignment>
                    {
                        new ProjectAssignment { ProjectId = 1, Project = new Project { ProjectId = 1, Title = "Project1", StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-10") } },
                        new ProjectAssignment { ProjectId = 2, Project = new Project { ProjectId = 2, Title = "Project2", StartDate = DateTime.Parse("2024-02-01"), EndDate = DateTime.Parse("2024-02-15") } }
                    }
                }
            };

            mockEmployeeRepo.Setup(e => e.ReadAll()).Returns(employees.AsQueryable());

            // Act
            var count = logic.GetEmployeeCountOnProject(1);

            // Assert
            Assert.AreEqual(2, count); // We expect 2 employees on Project1
        }

        [Test]
        public void GetDepartmentsInvolvedInProjectTest()
        {
            // Arrange
            var employees = new List<Employee>
    {
        new Employee
        {
            EmployeeId = 1,
            Department = new Department { DepartmentId = 1, Name = "Department1" },
            ProjectAssignments = new List<ProjectAssignment>
            {
                new ProjectAssignment { ProjectId = 1, Project = new Project { ProjectId = 1, Title = "Project1", StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-10") } }
            }
        },
        new Employee
        {
            EmployeeId = 2,
            Department = new Department { DepartmentId = 2, Name = "Department2" },
            ProjectAssignments = new List<ProjectAssignment>
            {
                new ProjectAssignment { ProjectId = 1, Project = new Project { ProjectId = 1, Title = "Project1", StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-10") } },
                new ProjectAssignment { ProjectId = 2, Project = new Project { ProjectId = 2, Title = "Project2", StartDate = DateTime.Parse("2024-02-01"), EndDate = DateTime.Parse("2024-02-15") } }
            }
        }
    };

            mockEmployeeRepo.Setup(e => e.ReadAll()).Returns(employees.AsQueryable());

            // Act
            var departments = logic.GetDepartmentsInvolvedInProject(1);

            // Assert
            Assert.AreEqual(2, departments.Count); // We expect 2 departments involved in Project1
            Assert.Contains("Department1", departments);
            Assert.Contains("Department2", departments);
        }


        [Test]
        public void GetLongestServingEmployeeDetailsTest()
        {
            // Arrange
            var employeesNoEmployee = new List<Employee>(); 
            var employeesValid = new List<Employee>
    {
        new Employee { Name = "John Doe", HireDate = DateTime.Parse("2010-01-01"), Department = new Department { Name = "Department1" } },
        new Employee { Name = "Jane Smith", HireDate = DateTime.Parse("2012-05-05"), Department = new Department { Name = "Department2" } }
    }; 

            mockEmployeeRepo.SetupSequence(e => e.ReadAll())
                            .Returns(employeesNoEmployee.AsQueryable())
                            .Returns(employeesValid.AsQueryable());     

            // Act & Assert
            
            Exception exNoEmployee = Assert.Throws<Exception>(() => logic.GetLongestServingEmployeeDetails());
            Assert.AreEqual("Nincs alkalmazott az adatbázisban.", exNoEmployee.Message);

           
            string resultValid = logic.GetLongestServingEmployeeDetails();
            Assert.AreEqual("John Doe - Department1", resultValid);
        }

        [Test]
        public void DepartmentWorkHoursStatisticsTest()
        {
            // Act
            var actual = logic.DepartmentWorkHoursStatistics().ToList();

            // Assert
            Assert.AreEqual(2, actual.Count);

            var expected1 = (DateTime.Now - DateTime.Parse("2008-05-02")).TotalHours + (DateTime.Now - DateTime.Parse("2009-05-02")).TotalHours;
            var expected2 = (DateTime.Now - DateTime.Parse("2009-05-02")).TotalHours + (DateTime.Now - DateTime.Parse("2010-05-02")).TotalHours;

            var actual1 = actual.FirstOrDefault(e => e.DepartmentId == 1);
            var actual2 = actual.FirstOrDefault(e => e.DepartmentId == 2);

            Assert.IsNotNull(actual1);
            Assert.IsNotNull(actual2);

            Assert.AreEqual(expected1, actual1.TotalWorkHours, 0.00001);
            Assert.AreEqual(expected2, actual2.TotalWorkHours, 0.00001);
        }
        [Test]
        public void GetTotalWorkHoursPerProjectTest()
        {
            // Arrange
            var employees = new List<Employee>
    {
        new Employee
        {
            EmployeeId = 1,
            ProjectAssignments = new List<ProjectAssignment>
            {
                new ProjectAssignment { ProjectId = 1, Project = new Project { ProjectId = 1, Title = "Project1", StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-10") } }
            }
        },
        new Employee
        {
            EmployeeId = 2,
            ProjectAssignments = new List<ProjectAssignment>
            {
                new ProjectAssignment { ProjectId = 1, Project = new Project { ProjectId = 1, Title = "Project1", StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-10") } },
                new ProjectAssignment { ProjectId = 2, Project = new Project { ProjectId = 2, Title = "Project2", StartDate = DateTime.Parse("2024-02-01"), EndDate = DateTime.Parse("2024-02-15") } }
            }
        }
    };

            mockEmployeeRepo.Setup(e => e.ReadAll()).Returns(employees.AsQueryable());

            // Act
            var result = logic.GetTotalWorkHoursPerProject();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(216, result["Project1"]); // 9 days * 24 hours = 216 hours
            Assert.AreEqual(336, result["Project2"]); // 14 days * 24 hours = 336 hours
        }

        [Test]
        public void CreateEmployeeTestWithCorrectName()
        {
            // Arrange
            var employee = new Employee() { Name = "John Doe" };

            // Act
            logic.Create(employee);

            // Assert
            mockEmployeeRepo.Verify(r => r.Create(employee), Times.Once);
        }

        [Test]
        public void CreateEmployeeTestWithEmptyName()
        {
            // Arrange
            var employee = new Employee() { Name = "" };

            try
            {
                // Act
                logic.Create(employee);
            }
            catch
            {
                // Expected exception
            }

            // Assert
            mockEmployeeRepo.Verify(r => r.Create(employee), Times.Never);
        }

        [Test]
        public void CreateEmployeeTestWithNullName()
        {
            // Arrange
            var employee = new Employee() { Name = null };

            try
            {
                // Act
                logic.Create(employee);
            }
            catch
            {
                // Expected exception
            }

            // Assert
            mockEmployeeRepo.Verify(r => r.Create(employee), Times.Never);
        }
        [Test]
        public void ReadEmployeeTestWithExistingId()
        {
            // Arrange
            var employee = new Employee() { EmployeeId = 1, Name = "John Doe" };
            mockEmployeeRepo.Setup(e => e.Read(1)).Returns(employee);

            // Act
            var result = logic.Read(1);

            // Assert
            Assert.AreEqual(employee, result);
        }

        [Test]
        public void ReadEmployeeTestWithNonExistingId()
        {
            // Arrange
            mockEmployeeRepo.Setup(e => e.Read(999)).Returns<Employee>(null);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => logic.Read(999));
        }

    }
}






