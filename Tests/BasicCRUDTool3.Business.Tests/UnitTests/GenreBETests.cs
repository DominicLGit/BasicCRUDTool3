using BasicCRUDTool3.Data.Models;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Test for loading existing record via ID and saving it.
        /// </summary>
        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var genre = new Genre
            {
                GenreId = 1
            };
            context.Add(genre);
            context.SaveChanges();

            GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);
            genreBE.Load(1);
            genreBE.Name = "TestGenreName";
            genreBE.Save();

            GenreBE genreBE2 = new GenreBE(cRUDTestDBContextProvider);
            genreBE2.Load(1);
            Assert.IsTrue(genreBE2.Id == 1);
            Assert.IsTrue(genreBE2.Name == "TestGenreName");
        }

        /// <summary>
        /// Test for creating new record and saving it. 
        /// </summary>
        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);
            genreBE.New();
            genreBE.Name = "TestGenreName";
            genreBE.Save();

            Assert.IsTrue(genreBE.Id != default);
        }

        /// <summary>
        /// Test for returning InvoiceLineBE objects related to record if relationship exists
        /// Test for returning no PlaylistTRackBE objects related to record is relationships do not exist
        /// </summary>
        [TestMethod]
        public void GetTracksTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var genre = new Genre
            {
                GenreId = 1
            };
            var genre2 = new Genre
            {
                GenreId = 2
            };
            var track = new Track { TrackId = 1 , GenreId = 1, Name = "TestTrackName"};
            context.Add(genre);
            context.Add(genre2);
            context.Add(track);
            context.SaveChanges();

            GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);
            GenreBE genreBE2 = new GenreBE(cRUDTestDBContextProvider);
            genreBE.Load(1);
            genreBE2.Load(2);
            var TrackBECollection = genreBE.GetTracks();
            Assert.IsTrue(TrackBECollection.First().GetType() == typeof(TrackBE));
            Assert.IsTrue(TrackBECollection.First().Name == "TestTrackName");
            Assert.IsTrue(TrackBECollection.First().Id == 1);
            Assert.IsTrue(genreBE2.GetTracks().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for adding new Track relationship
        /// </summary>
        [TestMethod]
        public void AddToTrackTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var genre = new Genre
            {
                GenreId = 1
            };
            var track = new Track { TrackId = 1, Name = "TestTrackName" };
            context.Add(genre);
            context.Add(track);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            genreBE.Load(1);
            genreBE.AddToTrack(trackBE);
            trackBE.Save();

            genreBE.Load(1);
            var InvoiceLineBECollection = genreBE.GetTracks();
            Assert.IsTrue(InvoiceLineBECollection.First().Id == 1);
            Assert.IsTrue(InvoiceLineBECollection.First().GenreId == 1);
        }

        /// <summary>
        /// Test for accurate TrackCount
        /// </summary>
        [TestMethod]
        public void TrackCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var genre = new Genre
            {
                GenreId = 1
            };
            var track = new Track { TrackId = 1, GenreId = 1, Name = "TestTrackName" };
            context.Add(genre);
            context.Add(track);
            context.SaveChanges();

            GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);
            genreBE.Load(1);
            Assert.IsTrue(genreBE.TrackCount == 1);

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.New();
            trackBE.Name = "TestName";
            genreBE.AddToTrack(trackBE);
            trackBE.Save();

            GenreBE genreBE2 = new GenreBE(cRUDTestDBContextProvider);
            genreBE2.Load(1);
            Assert.IsTrue(genreBE2.TrackCount == 2);
        }

        /// <summary>
        /// Test for accurate ToString method
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();

            var genre = new Genre
            {
                GenreId = 1,
                Name = "TestGenreName"
            };
            context.Add(genre);
            context.SaveChanges();

            GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);
            genreBE.Load(1);
            Assert.IsTrue(genreBE.ToString().Equals("GenreName: TestGenreName"));
        }
    }
}
