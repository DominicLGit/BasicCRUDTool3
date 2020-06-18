using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class InvoiceBETests
    {
        [ClassInitialize]
        public static void InvoiceBETestsIntialise(TestContext testContext)
        {
            CRUDTestDBContext context = new CRUDTestDBContextProvider().GetContext();
            var customer = new Customer {
                CustomerId = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName", 
                Email = "test@test.com"};
            var invoice = new Invoice { CustomerId = 1, InvoiceId = 1, BillingAddress = "123 Test Street"};
            var invoice2 = new Invoice { InvoiceId = 2 };
            var invoiceLine = new InvoiceLine { InvoiceLineId = 1, InvoiceId = 1, Quantity = 10 };
            var invoiceLine2 = new InvoiceLine {InvoiceLineId = 2, Quantity = 20 };
            context.Add(customer);
            context.Add(invoice);
            context.Add(invoice2);
            context.Add(invoiceLine);
            context.Add(invoiceLine2);
            context.SaveChanges();
        }

        [TestMethod]
        public void TotalValidation()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
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
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(1);
            Assert.IsTrue(invoiceBE.Id == 1);
            Assert.IsTrue(invoiceBE.BillingAddress == "123 Test Street");
            Assert.IsTrue(invoiceBE.CustomerFirstName == "TestFirstName");
            Assert.IsTrue(invoiceBE.CustomerLastName == "TestLastName");
        }

        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(2);
            invoiceBE.BillingAddress = "234 Test Street";
            invoiceBE.BillingCity = "TestCity 232";
            invoiceBE.BillingCountry = "TestCountry 43534";
            invoiceBE.BillingPostalCode = "TestPC23";
            invoiceBE.BillingState = "TestState 2324";
            invoiceBE.InvoiceDate = new DateTime(2020, 1, 1);
            invoiceBE.Total = 10;
            invoiceBE.Save();

            InvoiceBE invoiceBE2 = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE2.Load(2);
            Assert.IsTrue(invoiceBE2.BillingAddress == "234 Test Street");
            Assert.IsTrue(invoiceBE2.BillingCity == "TestCity 232");
            Assert.IsTrue(invoiceBE2.BillingCountry == "TestCountry 43534");
            Assert.IsTrue(invoiceBE2.BillingPostalCode == "TestPC23");
            Assert.IsTrue(invoiceBE2.BillingState == "TestState 2324");
            Assert.IsTrue(DateTime.Compare(invoiceBE2.InvoiceDate, new DateTime(2020, 1, 1)) == 0);
            Assert.IsTrue(invoiceBE2.Total == 10);
        }

        [TestMethod]
        public void GetInvoiceLinesTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(1);
            var invoiceLineBECollection = invoiceBE.GetInvoiceLines();
            Assert.IsTrue(invoiceLineBECollection.First().GetType() == typeof(InvoiceLineBE));
            Assert.IsTrue(invoiceLineBECollection.First().Quantity == 10);
            Assert.IsTrue(invoiceLineBECollection.First().Id == 1);
        }

        [TestMethod]
        public void AddToInvoiceLineTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(1);
            invoiceLineBE.Load(2);
            invoiceBE.AddToInvoiceLine(invoiceLineBE);
            invoiceLineBE.Save();

            invoiceBE.Load(1);
            var InvoiceLineBECollection = invoiceBE.GetInvoiceLines().Where(p => p.Id == 2);
            Assert.IsTrue(InvoiceLineBECollection.First().Id == 2);
        }
    }
}
