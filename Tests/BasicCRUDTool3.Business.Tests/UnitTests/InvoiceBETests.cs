using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            var invoiceLine = new InvoiceLine { InvoiceId = 1, InvoiceLineId = 1 };
            context.Add(customer);
            context.Add(invoice);
            context.Add(invoiceLine);
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
        public void LoadTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
            InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);
            invoiceBE.Load(1);
            Assert.IsTrue(invoiceBE.Id == 1);
            Assert.IsTrue(invoiceBE.BillingAddress == "123 Test Street");
            Assert.IsTrue(invoiceBE.CustomerFirstName == "TestFirstName");
            Assert.IsTrue(invoiceBE.CustomerLastName == "TestLastName");
        }
    }
}
