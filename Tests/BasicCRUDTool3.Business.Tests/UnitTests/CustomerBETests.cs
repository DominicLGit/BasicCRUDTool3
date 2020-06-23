using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class CustomerBETests
    {
        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customer = new Customer
            {
                CustomerId = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@test.com",
                Company = "TestCompany",
                Address = "123 Test Address",
                City = "TestCity",
                State = "TestState",
                Country = "TestCountry",
                PostalCode = "TestPC",
                Phone = "TestPhone",
                Fax = "TestFax",
                SupportRepId = 1
            };
            var employeeLoadValidIdTest = new Employee { EmployeeId = 1, FirstName = "TestEmployeeFirst", LastName = "TestEmployeeLast"};
            context.Add(customer);
            context.Add(employeeLoadValidIdTest);
            context.SaveChanges();

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            customerBE.Load(1);
            Assert.IsTrue(customerBE.Id == 1);
            Assert.IsTrue(customerBE.FirstName == "TestFirstName");
            Assert.IsTrue(customerBE.LastName == "TestLastName");
            Assert.IsTrue(customerBE.Company == "TestCompany");
            Assert.IsTrue(customerBE.Address == "123 Test Address");
            Assert.IsTrue(customerBE.City == "TestCity");
            Assert.IsTrue(customerBE.State == "TestState");
            Assert.IsTrue(customerBE.Country == "TestCountry");
            Assert.IsTrue(customerBE.PostalCode == "TestPC");
            Assert.IsTrue(customerBE.Phone == "TestPhone");
            Assert.IsTrue(customerBE.Fax == "TestFax");
            Assert.IsTrue(customerBE.Email == "test@test.com");
            Assert.IsTrue(customerBE.SupportRepId == 1);
        }

        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customerSaveValidIdTest = new Customer { CustomerId = 1 };
            context.Add(customerSaveValidIdTest);
            context.SaveChanges();

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            customerBE.Load(1);
            customerBE.FirstName = "TestFirstName";
            customerBE.LastName = "TestLastName";
            customerBE.Company = "TestCompany";
            customerBE.Address = "123 Test Address";
            customerBE.City = "TestCity";
            customerBE.State = "TestState";
            customerBE.Country = "TestCountry";
            customerBE.PostalCode = "TestPC";
            customerBE.Phone = "TestPhone";
            customerBE.Fax = "TestFax";
            customerBE.Email = "test@test.com";
            customerBE.Save();

            CustomerBE customerBE2 = new CustomerBE(cRUDTestDBContextProvider);
            customerBE2.Load(1);
            Assert.IsTrue(customerBE2.Id == 1);
            Assert.IsTrue(customerBE2.FirstName == "TestFirstName");
            Assert.IsTrue(customerBE2.LastName == "TestLastName");
            Assert.IsTrue(customerBE2.Company == "TestCompany");
            Assert.IsTrue(customerBE2.Address == "123 Test Address");
            Assert.IsTrue(customerBE2.City == "TestCity");
            Assert.IsTrue(customerBE2.State == "TestState");
            Assert.IsTrue(customerBE2.Country == "TestCountry");
            Assert.IsTrue(customerBE2.PostalCode == "TestPC");
            Assert.IsTrue(customerBE2.Phone == "TestPhone");
            Assert.IsTrue(customerBE2.Fax == "TestFax");
            Assert.IsTrue(customerBE2.Email == "test@test.com");
        }

        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            customerBE.New();
            customerBE.FirstName = "TestFirstName";
            customerBE.LastName = "TestLastName";
            customerBE.Email = "test@test.com";
            customerBE.Save();

            Assert.IsTrue(customerBE.Id != default);
        }

        [TestMethod]
        public void GetInvoicesTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceGetInvoicesTest = new Invoice { InvoiceId = 1, CustomerId = 1, Total = 10};
            var customerGetInvoicesTest = new Customer { CustomerId = 1};
            context.Add(invoiceGetInvoicesTest);
            context.Add(customerGetInvoicesTest);
            context.SaveChanges();

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            customerBE.Load(1);
            var invoiceBECollection = customerBE.GetInvoices();
            Assert.IsTrue(invoiceBECollection.First().GetType() == typeof(InvoiceBE));
            Assert.IsTrue(invoiceBECollection.First().Total == 10);
            Assert.IsTrue(invoiceBECollection.First().Id == 1);
        }

        [TestMethod]
        public void AddToInvoiceTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customerAddToInvoiceTest = new Customer { CustomerId = 1 };
            var invoiceAddToInvoiceTest = new Invoice { InvoiceId = 1, Total = 20 };
            context.Add(customerAddToInvoiceTest);
            context.Add(invoiceAddToInvoiceTest);
            context.SaveChanges();

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(1);
            customerBE.Load(1);
            customerBE.AddToInvoice(invoiceBE);
            invoiceBE.Save();

            customerBE.Load(1);
            var InvoiceBECollection = customerBE.GetInvoices().Where(p => p.Id == 1);
            Assert.IsTrue(InvoiceBECollection.First().Id == 1);
        }

        [TestMethod]
        public void InvoiceCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceInvoiceCountTest = new Invoice { InvoiceId = 1, CustomerId = 1 };
            var customerInvoiceCountTest = new Customer { CustomerId = 1 };
            context.Add(invoiceInvoiceCountTest);
            context.Add(customerInvoiceCountTest);
            context.SaveChanges();

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            customerBE.Load(1);
            Assert.IsTrue(customerBE.InvoiceCount == 1);

            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.New();
            customerBE.AddToInvoice(invoiceBE);
            invoiceBE.Save();

            CustomerBE customerBE2 = new CustomerBE(cRUDTestDBContextProvider);
            customerBE2.Load(1);
            Assert.IsTrue(customerBE2.InvoiceCount == 2);
        }

        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customerToStringTest = new Customer { CustomerId = 1, 
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "Test@test.com" };
            context.Add(customerToStringTest);
            context.SaveChanges();

            CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);
            customerBE.Load(1);
            Assert.IsTrue(customerBE.ToString().Equals("Customer Name:TestFirstName TestLastName Email:Test@test.com"));
        }
    }
}
