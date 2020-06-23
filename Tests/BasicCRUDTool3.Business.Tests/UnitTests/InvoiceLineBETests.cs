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
        [TestMethod]
        public void UnitPriceValidation()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
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
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceLineLoadValidIdTest = new InvoiceLine { InvoiceLineId = 1, TrackId = 1, Quantity = 10, UnitPrice = 20 };
            var trackLoadValidIdTest = new Track { TrackId = 1, Name = "TestTrackName" };
            context.Add(invoiceLineLoadValidIdTest);
            context.Add(trackLoadValidIdTest);
            context.SaveChanges();

            InvoiceLineBE invoiceLine = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLine.Load(1);
            Assert.IsTrue(invoiceLine.Id == 1);
            Assert.IsTrue(invoiceLine.Quantity == 10);
            Assert.IsTrue(invoiceLine.UnitPrice == 20);
            Assert.IsTrue(invoiceLine.TrackName == "TestTrackName");
        }

        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceLineLoadValidIdTest = new InvoiceLine { InvoiceLineId = 1 };
            context.Add(invoiceLineLoadValidIdTest);
            context.SaveChanges();

            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLineBE.Load(1);
            invoiceLineBE.Quantity = 15;
            invoiceLineBE.UnitPrice = 10;
            invoiceLineBE.Save();

            InvoiceLineBE invoiceLineBE2 = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLineBE2.Load(1);
            Assert.IsTrue(invoiceLineBE2.Id == 1);
            Assert.IsTrue(invoiceLineBE2.Quantity == 15);
            Assert.IsTrue(invoiceLineBE2.UnitPrice == 10);
        }

        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLineBE.New();
            invoiceLineBE.Save();

            Assert.IsTrue(invoiceLineBE.Id != default);
        }

        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceToStringTest = new InvoiceLine { InvoiceLineId = 1, TrackId = 1, Quantity = 10};
            var trackToStringTest = new Track { TrackId = 1,  Name = "TestTrackName"};
            context.Add(invoiceToStringTest);
            context.Add(trackToStringTest);
            context.SaveChanges();

            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLineBE.Load(1);


            Assert.IsTrue(invoiceLineBE.ToString() == "Track Name: TestTrackName Quantity: 10");
        }
    }
}
