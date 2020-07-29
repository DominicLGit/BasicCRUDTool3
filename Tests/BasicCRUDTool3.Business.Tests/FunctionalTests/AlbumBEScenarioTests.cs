using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.FunctionalTests
{
    [TestClass]
    public class AlbumBEScenarioTests
    {
        /// <summary>
        /// Test for loading existing object from database with all attributes
        /// </summary>
        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider functionalCRUDTestDBContextProvider = new FunctionalCRUDTestDBContextProvider();

            AlbumBE albumBE = new AlbumBE(functionalCRUDTestDBContextProvider);
            albumBE.Load(1);
            Assert.IsTrue(albumBE.Id == 1);
            Assert.IsTrue(albumBE.Title == "For Those About To Rock We Salute You");
            Assert.IsTrue(albumBE.ArtistId == 1);
            Assert.IsTrue(albumBE.ArtistName == "AC/DC");

            AlbumBE albumBE2 = new AlbumBE(functionalCRUDTestDBContextProvider);
            albumBE2.Load(2);
            Assert.IsTrue(albumBE2.Id == 2);
            Assert.IsTrue(albumBE2.Title == "Balls to the Wall");
            Assert.IsTrue(albumBE2.ArtistId == 2);
            Assert.IsTrue(albumBE2.ArtistName == "Accept");

            AlbumBE albumBE3 = new AlbumBE(functionalCRUDTestDBContextProvider);
            albumBE3.Load(3);
            Assert.IsTrue(albumBE3.Id == 3);
            Assert.IsTrue(albumBE3.Title == "Restless and Wild");
            Assert.IsTrue(albumBE3.ArtistId == 2);
            Assert.IsTrue(albumBE3.ArtistName == "Accept");
        }
    }
}
