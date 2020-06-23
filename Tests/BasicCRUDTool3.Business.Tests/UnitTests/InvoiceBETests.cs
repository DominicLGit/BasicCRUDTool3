using BasicCRUDTool3.Data.Models;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class InvoiceBETests
    {
        [TestMethod]
        public void TotalValidation()
        {
            CRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Total = 1.11M;
            Assert.IsTrue(invoiceBE.IsValid());
            invoiceBE.Total = 1.111M;
            Assert.IsFalse(invoiceBE.IsValid());
            invoiceBE.Total = 1.1M;
            Assert.IsTrue(invoiceBE.IsValid());
            invoiceBE.Total = 1M;
            Assert.IsTrue(invoiceBE.IsValid());
            invoiceBE.Total = 0.00M;
            Assert.IsTrue(invoiceBE.IsValid());
            invoiceBE.Total = -1.00M;
            Assert.IsFalse(invoiceBE.IsValid());
        }

        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customer = new Customer
            {
                CustomerId = 2,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@test.com"
            };
            var invoiceLoadValidIdTest = new Invoice { CustomerId = 2, InvoiceId = 2, BillingAddress = "123 Test Street" };
            context.Add(customer);
            context.Add(invoiceLoadValidIdTest);
            context.SaveChanges();

            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(2);
            Assert.IsTrue(invoiceBE.Id == 2);
            Assert.IsTrue(invoiceBE.BillingAddress == "123 Test Street");
            Assert.IsTrue(invoiceBE.CustomerFirstName == "TestFirstName");
            Assert.IsTrue(invoiceBE.CustomerLastName == "TestLastName");
        }

        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceSaveValidIdTest = new Invoice { InvoiceId = 3 };
            context.Add(invoiceSaveValidIdTest);
            context.SaveChanges();

            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(3);
            invoiceBE.BillingAddress = "234 Test Street";
            invoiceBE.BillingCity = "TestCity 232";
            invoiceBE.BillingCountry = "TestCountry 43534";
            invoiceBE.BillingPostalCode = "TestPC23";
            invoiceBE.BillingState = "TestState 2324";
            invoiceBE.InvoiceDate = new DateTime(2020, 1, 1);
            invoiceBE.Total = 10;
            invoiceBE.Save();

            InvoiceBE invoiceBE2 = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE2.Load(3);
            Assert.IsTrue(invoiceBE2.BillingAddress == "234 Test Street");
            Assert.IsTrue(invoiceBE2.BillingCity == "TestCity 232");
            Assert.IsTrue(invoiceBE2.BillingCountry == "TestCountry 43534");
            Assert.IsTrue(invoiceBE2.BillingPostalCode == "TestPC23");
            Assert.IsTrue(invoiceBE2.BillingState == "TestState 2324");
            Assert.IsTrue(DateTime.Compare(invoiceBE2.InvoiceDate, new DateTime(2020, 1, 1)) == 0);
            Assert.IsTrue(invoiceBE2.Total == 10);
        }

        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.New();
            invoiceBE.Save();

            Assert.IsTrue(invoiceBE.Id != default);
        }

        [TestMethod]
        public void GetInvoiceLinesTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceGetInvoiceLinesTest = new Invoice { InvoiceId = 4 };
            var invoiceGetInvoiceLinesTest2 = new Invoice { InvoiceId = 1 };
            var invoiceLineGetInvoiceLinesTest = new InvoiceLine { InvoiceLineId = 1, InvoiceId = 4, Quantity = 10 };
            context.Add(invoiceGetInvoiceLinesTest);
            context.Add(invoiceGetInvoiceLinesTest2);
            context.Add(invoiceLineGetInvoiceLinesTest);
            context.SaveChanges();

            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            InvoiceBE invoiceBE2 = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(4);
            invoiceBE2.Load(1);
            var invoiceLineBECollection = invoiceBE.GetInvoiceLines();
            Assert.IsTrue(invoiceLineBECollection.First().GetType() == typeof(InvoiceLineBE));
            Assert.IsTrue(invoiceLineBECollection.First().Quantity == 10);
            Assert.IsTrue(invoiceLineBECollection.First().Id == 1);
            Assert.IsTrue(invoiceBE2.GetInvoiceLines().IsNullOrEmpty());
        }

        [TestMethod]
        public void AddToInvoiceLineTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceAddToInvoiceLineTest = new Invoice { InvoiceId = 5 };
            var invoiceLineAddToInvoiceLineTest = new InvoiceLine { InvoiceLineId = 2, Quantity = 20 };
            context.Add(invoiceAddToInvoiceLineTest);
            context.Add(invoiceLineAddToInvoiceLineTest);
            context.SaveChanges();

            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(5);
            invoiceLineBE.Load(2);
            invoiceBE.AddToInvoiceLine(invoiceLineBE);
            invoiceLineBE.Save();

            invoiceBE.Load(5);
            var InvoiceLineBECollection = invoiceBE.GetInvoiceLines().Where(p => p.Id == 2);
            Assert.IsTrue(InvoiceLineBECollection.First().Id == 2);
            Assert.IsTrue(InvoiceLineBECollection.First().InvoiceId == 5);
        }

        [TestMethod]
        public void InvoiceLineCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceInvoiceLineCountTest = new Invoice { InvoiceId = 6 };
            var invoiceLineInvoiceLineCountTest = new InvoiceLine { InvoiceLineId = 3, InvoiceId = 6 };
            context.Add(invoiceInvoiceLineCountTest);
            context.Add(invoiceLineInvoiceLineCountTest);
            context.SaveChanges();

            InvoiceBE invoiceBe = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBe.Load(6);
            Assert.IsTrue(invoiceBe.InvoiceLineCount == 1);

            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLineBE.New();
            invoiceBe.AddToInvoiceLine(invoiceLineBE);
            invoiceLineBE.Save();

            InvoiceBE invoiceBe2 = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBe2.Load(6);
            Assert.IsTrue(invoiceBe2.InvoiceLineCount == 2);
        }

        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceToStringTest = new Invoice { InvoiceId = 1, CustomerId = 1, InvoiceDate = new DateTime(2020, 1, 1) };
            var customerToStringTest = new Customer { CustomerId = 1, FirstName = "TestFirstName", LastName = "TestLastName"};
            context.Add(customerToStringTest);
            context.Add(invoiceToStringTest);
            context.SaveChanges();

            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(1);
            Assert.IsTrue(invoiceBE.ToString().Equals("Invoice ID: 1 Customer Name:TestFirstName TestLastName Date:01/01/2020"));
        }
    }
}
