using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Castle.Core.Internal;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class BusinessTests
    {
        /// <summary>
        /// Test for returning all AlbumBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetAlbumBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var album = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 1
            };
            var album2 = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 2
            };
            context.Add(album);
            context.Add(album2);
            context.SaveChanges();

            var albums = new Business(cRUDTestDBContextProvider).GetAlbumBEs();
            Assert.IsTrue(albums.First().GetType() == typeof(AlbumBE));
            Assert.IsTrue(albums.First().Title == "TestAlbumTitle");
            Assert.IsTrue(albums.Count() == 2);
        }

        /// <summary>
        /// Test for returning no AlbumBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetAlbumBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetAlbumBEs().IsNullOrEmpty());
        }
    }
}
