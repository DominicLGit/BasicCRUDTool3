using BasicCRUDTool3.Data.Models;
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
                HireDate = new DateTime(2020, 1 , 1),
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
            var customerGetCustomersTest = new Customer { CustomerId = 1,
                SupportRepId = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test" };

            var EmployeeGetCustomersTest = new Employee { EmployeeId = 1, FirstName = "TestFirst", LastName = "TestLast" };
            context.Add(customerGetCustomersTest);
            context.Add(EmployeeGetCustomersTest);
            context.SaveChanges();

            EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);
            employeeBE.Load(1);
            var customerBECollection = employeeBE.GetCustomers();
            Assert.IsTrue(customerBECollection.First().GetType() == typeof(CustomerBE));
            Assert.IsTrue(customerBECollection.First().FirstName == "Test");
            Assert.IsTrue(customerBECollection.First().Id == 1);
        }

        [TestMethod]
        public void AddToCustomersTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customer = new Customer { CustomerId = 1, FirstName = "TestFirst", LastName = "TestLast", Email = "Test"};
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
        }
    }
}
