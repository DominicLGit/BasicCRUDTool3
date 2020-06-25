using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class GenreBETests
    {
        /// <summary>
        /// Test for loading existing object from database with all attributes
        /// Test for loading existing object from database with missing attributes
        /// </summary>
        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var genre = new Genre
            {
                Name = "TestGenreName",
                GenreId = 1
            };
            var genre2 = new Genre
            {
                GenreId = 2
            };
            context.Add(genre);
            context.Add(genre2);
            context.SaveChanges();

            GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);
            genreBE.Load(1);
            Assert.IsTrue(genreBE.Id == 1);
            Assert.IsTrue(genreBE.Name == "TestGenreName");

            GenreBE genreBE2 = new GenreBE(cRUDTestDBContextProvider);
            genreBE2.Load(2);
            Assert.IsTrue(genreBE2.Id == 2);
        }
    }
}
