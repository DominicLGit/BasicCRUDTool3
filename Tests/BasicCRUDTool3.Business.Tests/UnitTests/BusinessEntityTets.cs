using BasicCRUDTool3.Data.Models;
using Castle.DynamicProxy.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class BusinessEntityTets
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ValidationExceptionOnNotValidTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var businessEntityStub = new BusinessEntityStub<TEntityStub, int>(cRUDTestDBContextProvider);
            businessEntityStub.Save();
        }

        private class BusinessEntityStub<TEntity, TKey> : BusinessEntity<TEntity, TKey> where TEntity : class, new()
        {
            #region Constructors
            public BusinessEntityStub(ICRUDTestDBContextProvider cRUDTestDBContext) : base(cRUDTestDBContext)
            {
            }
            #endregion

            public override bool IsValid(out IEnumerable<ValidationResult> validationResults)
            {
                IEnumerable<ValidationResult> newValidationResults = new List<ValidationResult>();
                validationResults = newValidationResults;
                return false;
            }
        }

        private class TEntityStub
        {
        }
    }
}
