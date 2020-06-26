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
    public class AlbumBETests
    {
        /// <summary>
        /// Test for loading existing object from database with all attributes
        /// Test for loading existing object from database with no relationships
        /// Test for loading existing object from database with missing non-required attributes from relationships
        /// </summary>
        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var album = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 1,
                ArtistId = 1
            };
            var artist = new Artist
            {
                ArtistId = 1,
                Name = "TestArtistName"
            };
            var album2 = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 2
            };
            var album3 = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 3,
                ArtistId = 2
            };
            var artist2 = new Artist
            {
                ArtistId = 2
            };
            context.Add(album);
            context.Add(artist);
            context.Add(album2);
            context.Add(album3);
            context.Add(artist2);
            context.SaveChanges();

            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(1);
            Assert.IsTrue(albumBE.Id == 1);
            Assert.IsTrue(albumBE.Title == "TestAlbumTitle");
            Assert.IsTrue(albumBE.ArtistId == 1);
            Assert.IsTrue(albumBE.ArtistName == "TestArtistName");

            AlbumBE albumBE2 = new AlbumBE(cRUDTestDBContextProvider);
            albumBE2.Load(2);
            Assert.IsTrue(albumBE2.Id == 2);
            Assert.IsTrue(albumBE2.Title == "TestAlbumTitle");

            AlbumBE albumBE3 = new AlbumBE(cRUDTestDBContextProvider);
            albumBE3.Load(3);
            Assert.IsTrue(albumBE3.Id == 3);
            Assert.IsTrue(albumBE3.Title == "TestAlbumTitle");
            Assert.IsTrue(albumBE3.ArtistId == 2);
        }

        /// <summary>
        /// Test for loading existing record via ID and saving it.
        /// </summary>
        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var album = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 1
            };
            context.Add(album);
            context.SaveChanges();

            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(1);
            albumBE.Title = "TestAlbumTitleChanged";
            albumBE.Save();

            AlbumBE albumBE2 = new AlbumBE(cRUDTestDBContextProvider);
            albumBE2.Load(1);
            Assert.IsTrue(albumBE2.Id == 1);
            Assert.IsTrue(albumBE2.Title == "TestAlbumTitleChanged");
        }

        /// <summary>
        /// Test for creating new record and saving it. 
        /// </summary>
        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.New();
            albumBE.Title = "TestAlbumTitle";
            albumBE.Save();

            Assert.IsTrue(albumBE.Id != default);
        }

        /// <summary>
        /// Test for returning TrackBE objects related to record if relationship exists
        /// Test for returning no TrackBE objects related to record is relationships do not exist
        /// </summary>
        [TestMethod]
        public void GetTracksTest()
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
            var track = new Track { TrackId = 1, AlbumId = 1, Name = "TestTrackName" };
            context.Add(album);
            context.Add(album2);
            context.Add(track);
            context.SaveChanges();

            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(1);
            AlbumBE albumBE2 = new AlbumBE(cRUDTestDBContextProvider);
            albumBE2.Load(2);
            var TrackBECollection = albumBE.GetTracks();
            Assert.IsTrue(TrackBECollection.First().GetType() == typeof(TrackBE));
            Assert.IsTrue(TrackBECollection.First().Name == "TestTrackName");
            Assert.IsTrue(TrackBECollection.First().Id == 1);
            Assert.IsTrue(albumBE2.GetTracks().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for adding new Track relationship
        /// </summary>
        [TestMethod]
        public void AddToTrackTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var album = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 1
            };
            var track = new Track { TrackId = 1, Name = "TestTrackName" };
            context.Add(album);
            context.Add(track);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(1);
            trackBE.Load(1);
            albumBE.AddToTrack(trackBE);
            trackBE.Save();

            albumBE.Load(1);
            var InvoiceLineBECollection = albumBE.GetTracks();
            Assert.IsTrue(InvoiceLineBECollection.First().Id == 1);
            Assert.IsTrue(InvoiceLineBECollection.First().AlbumId == 1);
        }

        /// <summary>
        /// Test for accurate TrackCount
        /// </summary>
        [TestMethod]
        public void TrackCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var album = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 1
            };
            var track = new Track { TrackId = 1, AlbumId = 1, Name = "TestTrackName" };
            context.Add(album);
            context.Add(track);
            context.SaveChanges();

            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(1);
            Assert.IsTrue(albumBE.TrackCount == 1);

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.New();
            trackBE.Name = "TestName";
            albumBE.AddToTrack(trackBE);
            trackBE.Save();

            AlbumBE albumBE2 = new AlbumBE(cRUDTestDBContextProvider);
            albumBE2.Load(1);
            Assert.IsTrue(albumBE2.TrackCount == 2);
        }

        /// <summary>
        /// Test for accurate ToString method
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();

            var album = new Album
            {
                Title = "TestAlbumTitle",
                AlbumId = 1
            };
            context.Add(album);
            context.SaveChanges();

            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(1);
            Assert.IsTrue(albumBE.ToString().Equals("Albumb Title: TestAlbumTitle"));
        }
    }
}
