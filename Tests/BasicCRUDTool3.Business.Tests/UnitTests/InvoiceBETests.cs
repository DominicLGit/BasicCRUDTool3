using BasicCRUDTool3.Data.Models;
using BasicCRUDTool3.WPFDesktop;
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
        public void InvoiceBETestsIntialise()
        {
            CRUDTestDBContext context = new CRUDTestDBContextProvider().GetContext();
            var customer = new Customer {
                CustomerId = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName", 
                Email = "test@test.com"};
            var invoice = new Invoice { Customer = customer, }
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
    }
}
