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
    }

}






