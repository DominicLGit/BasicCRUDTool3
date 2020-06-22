using BasicCRUDTool3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class InvoiceLineBETests
    {
        [ClassInitialize]
        public static void InvoiceLineBETestsIntialise(TestContext testContext)
        {
            CRUDTestDBContext context = new CRUDTestDBContextProvider().GetContext();
            //var invoiceLoadValidIdTest = new Invoice { CustomerId = 1, InvoiceId = 2, BillingAddress = "123 Test Street" };
            //var invoiceSaveValidIdTest = new Invoice { InvoiceId = 3 };
            var invoiceLineLoadValidIdTest = new InvoiceLine { InvoiceLineId = 5 , Quantity = 10, UnitPrice = 20};
            //context.Add(invoiceLoadValidIdTest);
            //context.Add(invoiceSaveValidIdTest);
            context.Add(invoiceLineLoadValidIdTest);

            context.SaveChanges();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            CRUDTestDBContext context = new CRUDTestDBContextProvider().GetContext();
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [TestMethod]
        public void UnitPriceValidation()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLineBE.UnitPrice = 1.11M;
            Assert.IsTrue(invoiceLineBE.IsValid());
            invoiceLineBE.UnitPrice = 1.111M;
            Assert.IsFalse(invoiceLineBE.IsValid());
            invoiceLineBE.UnitPrice = 1.1M;
            Assert.IsTrue(invoiceLineBE.IsValid());
            invoiceLineBE.UnitPrice = 1M;
            Assert.IsTrue(invoiceLineBE.IsValid());
            invoiceLineBE.UnitPrice = 0.00M;
            Assert.IsTrue(invoiceLineBE.IsValid());
            invoiceLineBE.UnitPrice = -1.00M;
            Assert.IsFalse(invoiceLineBE.IsValid());
        }

        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider();
            InvoiceLineBE invoiceLine = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLine.Load(5);
            Assert.IsTrue(invoiceLine.Id == 5);
            Assert.IsTrue(invoiceLine.Quantity == 10);
            Assert.IsTrue(invoiceLine.UnitPrice == 20);
        }
    }
}
