using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Data.Tests.UnitTests
{
    [TestClass]
    public class ActiveRecordTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionOnLoadIdDoesNotExist()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var activeRecordStub = new ActiveRecordStub<Genre, int>(cRUDTestDBContextProvider);
            activeRecordStub.Load(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionOnDeleteIdDoesNotExist()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var activeRecordStub = new ActiveRecordStub<Genre, int>(cRUDTestDBContextProvider);
            activeRecordStub.Delete();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var genre = new Genre { GenreId = 1 };
            context.Add(genre);
            context.SaveChanges();

            var activeRecordStub = new ActiveRecordStub<Genre, int>(cRUDTestDBContextProvider);
            activeRecordStub.Load(1);
            Assert.IsTrue(activeRecordStub.Id == 1);
            activeRecordStub.Delete();
            activeRecordStub.Load(1);

        }

        private class ActiveRecordStub<TEntity, TKey> : ActiveRecord<TEntity, TKey> where TEntity : class, new()
        {
            #region Constructors
            public ActiveRecordStub(ICRUDTestDBContextProvider cRUDTestDBContext) : base(cRUDTestDBContext)
            {
            }
            #endregion
        }
    }
}
