using BasicCRUDTool3.Data.Models;
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
    }
}
