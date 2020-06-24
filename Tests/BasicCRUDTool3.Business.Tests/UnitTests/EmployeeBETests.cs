using BasicCRUDTool3.Data.Models;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class EmployeeBETests
    {
        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Title = "TestTitle",
                ReportsTo = 2,
                BirthDate = new DateTime(2000, 1, 1),
                HireDate = new DateTime(2020, 1, 1),
                Email = "test@test.com",
                Address = "123 Test Address",
                City = "TestCity",
                State = "TestState",
                Country = "TestCountry",
                PostalCode = "TestPC",
                Phone = "TestPhone",
                Fax = "TestFax",
            };
            var employee2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                Title = "TestTitle2",
                BirthDate = new DateTime(1990, 1, 1),
                HireDate = new DateTime(2020, 1, 1),
                Email = "t2est@test.com",
                Address = "123 Test Address",
                City = "TestCity",
                State = "TestState",
                Country = "TestCountry",
                PostalCode = "TestPC",
                Phone = "TestPhone",
                Fax = "TestFax",
            };
            context.Add(employee);
            context.Add(employee2);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            Assert.IsTrue(employeeBE.Id == 1);
            Assert.IsTrue(employeeBE.FirstName == "TestFirstName");
            Assert.IsTrue(employeeBE.LastName == "TestLastName");
            Assert.IsTrue(employeeBE.Title == "TestTitle");
            Assert.IsTrue(employeeBE.BirthDate.Equals(new DateTime(2000, 1, 1)));
            Assert.IsTrue(employeeBE.HireDate.Equals(new DateTime(2020, 1, 1)));
            Assert.IsTrue(employeeBE.Address == "123 Test Address");
            Assert.IsTrue(employeeBE.City == "TestCity");
            Assert.IsTrue(employeeBE.State == "TestState");
            Assert.IsTrue(employeeBE.Country == "TestCountry");
            Assert.IsTrue(employeeBE.PostalCode == "TestPC");
            Assert.IsTrue(employeeBE.Phone == "TestPhone");
            Assert.IsTrue(employeeBE.Fax == "TestFax");
            Assert.IsTrue(employeeBE.Email == "test@test.com");
            Assert.IsTrue(employeeBE.ReportsTo == 2);
        }

        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var employee = new Employee { EmployeeId = 1 };
            context.Add(employee);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            employeeBE.FirstName = "TestFirstName";
            employeeBE.LastName = "TestLastName";
            employeeBE.Title = "TestTitle";
            employeeBE.BirthDate = new DateTime(2000, 1, 1);
            employeeBE.HireDate = new DateTime(2020, 1, 1);
            employeeBE.Address = "123 Test Address";
            employeeBE.City = "TestCity";
            employeeBE.State = "TestState";
            employeeBE.Country = "TestCountry";
            employeeBE.PostalCode = "TestPC";
            employeeBE.Phone = "TestPhone";
            employeeBE.Fax = "TestFax";
            employeeBE.Email = "test@test.com";
            employeeBE.Save();

            EmployeeBE employeeBE2 = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE2.Load(1);
            Assert.IsTrue(employeeBE2.Id == 1);
            Assert.IsTrue(employeeBE2.FirstName == "TestFirstName");
            Assert.IsTrue(employeeBE2.LastName == "TestLastName");
            Assert.IsTrue(employeeBE2.Title == "TestTitle");
            Assert.IsTrue(employeeBE2.BirthDate.Equals(new DateTime(2000, 1, 1)));
            Assert.IsTrue(employeeBE2.HireDate.Equals(new DateTime(2020, 1, 1)));
            Assert.IsTrue(employeeBE2.Address == "123 Test Address");
            Assert.IsTrue(employeeBE2.City == "TestCity");
            Assert.IsTrue(employeeBE2.State == "TestState");
            Assert.IsTrue(employeeBE2.Country == "TestCountry");
            Assert.IsTrue(employeeBE2.PostalCode == "TestPC");
            Assert.IsTrue(employeeBE2.Phone == "TestPhone");
            Assert.IsTrue(employeeBE2.Fax == "TestFax");
            Assert.IsTrue(employeeBE2.Email == "test@test.com");
        }

        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.New();
            employeeBE.FirstName = "TestFirstName";
            employeeBE.LastName = "TestLastName";
            employeeBE.Save();

            Assert.IsTrue(employeeBE.Id != default);
        }

        [TestMethod]
        public void GetCustomersTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customerGetCustomersTest = new Customer
            {
                CustomerId = 1,
                SupportRepId = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test"
            };

            var employeeGetCustomersTest = new Employee { EmployeeId = 1, FirstName = "TestFirst", LastName = "TestLast" };
            var employeeGetCustomersTest2 = new Employee { EmployeeId = 2, FirstName = "TestFirst", LastName = "TestLast" };
            context.Add(customerGetCustomersTest);
            context.Add(employeeGetCustomersTest);
            context.Add(employeeGetCustomersTest2);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            EmployeeBE employeeBE2 = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            employeeBE2.Load(2);
            var customerBECollection = employeeBE.GetCustomers();
            Assert.IsTrue(customerBECollection.First().GetType() == typeof(CustomerBE));
            Assert.IsTrue(customerBECollection.First().FirstName == "Test");
            Assert.IsTrue(customerBECollection.First().Id == 1);
            Assert.IsTrue(employeeBE2.GetCustomers().IsNullOrEmpty());
        }

        [TestMethod]
        public void AddToCustomersTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customer = new Customer { CustomerId = 1, FirstName = "TestFirst", LastName = "TestLast", Email = "Test" };
            var employee = new Employee { EmployeeId = 1, FirstName = "TesteFirst", LastName = "TesteLast", Email = "eTest" };
            context.Add(customer);
            context.Add(employee);
            context.SaveChanges();

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            customerBE.Load(1);
            employeeBE.AddToCustomer(customerBE);
            customerBE.Save();

            employeeBE.Load(1);
            var customerBECollection = employeeBE.GetCustomers();
            Assert.IsTrue(customerBECollection.First().Id == 1);
            Assert.IsTrue(customerBECollection.First().SupportRepId == 1);
        }

        [TestMethod]
        public void CustomerCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customer = new Customer { CustomerId = 1, SupportRepId = 1, FirstName = "TestFirst", LastName = "TestLast", Email = "Test" };
            var customer2 = new Customer { CustomerId = 2, FirstName = "Test2First", LastName = "Test2Last", Email = "2Test" };
            var employee = new Employee { EmployeeId = 1, FirstName = "TesteFirst", LastName = "TesteLast", Email = "eTest" };
            context.Add(customer);
            context.Add(customer2);
            context.Add(employee);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            Assert.IsTrue(employeeBE.CustomerCount == 1);

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            customerBE.Load(2);
            employeeBE.AddToCustomer(customerBE);
            customerBE.Save();

            EmployeeBE employeeBE2 = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE2.Load(1);
            Assert.IsTrue(employeeBE2.CustomerCount == 2);
        }

        [TestMethod]
        public void GetReportsToThisEmployeeTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();

            var employee1 = new Employee { EmployeeId = 1, ReportsTo = 2, FirstName = "Test1First", LastName = "Test1Last" };
            var employee2 = new Employee { EmployeeId = 2, FirstName = "Test2First", LastName = "Test2Last" };
            context.Add(employee1);
            context.Add(employee2);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            EmployeeBE employeeBE2 = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(2);
            employeeBE2.Load(1);
            var employeeBECollection = employeeBE.GetReportsToThisEmployee();
            Assert.IsTrue(employeeBECollection.First().GetType() == typeof(EmployeeBE));
            Assert.IsTrue(employeeBECollection.First().FirstName == "Test1First");
            Assert.IsTrue(employeeBECollection.First().Id == 1);
            Assert.IsTrue(employeeBECollection.First().ReportsTo == 2);
            Assert.IsTrue(employeeBE2.GetReportsToThisEmployee().IsNullOrEmpty());
        }

        [TestMethod]
        public void AddToEmployeeTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var employee1 = new Employee { EmployeeId = 1, FirstName = "Test1First", LastName = "Test1Last" };
            var employee2 = new Employee { EmployeeId = 2, FirstName = "Test2First", LastName = "Test2Last" };
            context.Add(employee1);
            context.Add(employee2);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            EmployeeBE employeeBE2 = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            employeeBE2.Load(2);
            employeeBE2.AddSubordinate(employeeBE);
            employeeBE.Save();

            employeeBE.Load(1);
            var employeeBECollection = employeeBE2.GetReportsToThisEmployee();
            Assert.IsTrue(employeeBECollection.First().Id == 1);
            Assert.IsTrue(employeeBECollection.First().ReportsTo == 2);
        }

        [TestMethod]
        public void ReportsToCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var employee = new Employee { EmployeeId = 1, ReportsTo = 3, FirstName = "TestFirst", LastName = "TestLast", Email = "Test" };
            var employee2 = new Employee { EmployeeId = 2, FirstName = "Test2First", LastName = "Test2Last", Email = "2Test" };
            var employeeReportedTo = new Employee { EmployeeId = 3, FirstName = "Test3First", LastName = "Test3Last", Email = "3Test" };
            context.Add(employee);
            context.Add(employee2);
            context.Add(employeeReportedTo);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(3);
            Assert.IsTrue(employeeBE.ReportsToCount == 1);

            EmployeeBE employeeBE2 = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE2.Load(2);
            employeeBE.AddSubordinate(employeeBE2);
            employeeBE2.Save();

            EmployeeBE employeeBE3 = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE3.Load(3);
            Assert.IsTrue(employeeBE3.ReportsToCount == 2);
        }

        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var employee = new Employee { EmployeeId = 1, Title = "TestTitle", FirstName = "TestFirst", LastName = "TestLast", Email = "Test" };
            context.Add(employee);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            Assert.IsTrue(employeeBE.ToString().Equals("Employee Name:TestFirst TestLast Title:TestTitle"));
        }
    }
}
