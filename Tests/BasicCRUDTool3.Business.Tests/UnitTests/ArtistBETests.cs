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
    public class ArtistBETests
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
            var artist = new Artist
            {
                Name = "TestArtistName",
                ArtistId = 1
            };
            var artist2 = new Artist
            {
                ArtistId = 2
            };
            context.Add(artist);
            context.Add(artist2);
            context.SaveChanges();

            ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);
            artistBE.Load(1);
            Assert.IsTrue(artistBE.Id == 1);
            Assert.IsTrue(artistBE.Name == "TestArtistName");

            ArtistBE artistBE2 = new ArtistBE(cRUDTestDBContextProvider);
            artistBE2.Load(2);
            Assert.IsTrue(artistBE2.Id == 2);
        }

        /// <summary>
        /// Test for loading existing record via ID and saving it.
        /// </summary>
        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var artist = new Artist
            {
                ArtistId = 1
            };
            context.Add(artist);
            context.SaveChanges();

            ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);
            artistBE.Load(1);
            artistBE.Name = "TestArtistName";
            artistBE.Save();

            ArtistBE artistBE2 = new ArtistBE(cRUDTestDBContextProvider);
            artistBE2.Load(1);
            Assert.IsTrue(artistBE2.Id == 1);
            Assert.IsTrue(artistBE2.Name == "TestArtistName");
        }

        /// <summary>
        /// Test for creating new record and saving it. 
        /// </summary>
        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);
            artistBE.New();
            artistBE.Name = "TestArtistName";
            artistBE.Save();

            Assert.IsTrue(artistBE.Id != default);
        }

        /// <summary>
        /// Test for returning AlbumBE objects related to record if relationship exists
        /// Test for returning no AlbumBE objects related to record is relationships do not exist
        /// </summary>
        [TestMethod]
        public void GetAlbumsTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var artist = new Artist
            {
                ArtistId = 1
            };
            var artist2 = new Artist
            {
                ArtistId = 2
            };
            var album = new Album { AlbumId = 1, ArtistId = 1, Title = "TestAlbumTitle" };
            context.Add(artist);
            context.Add(artist2);
            context.Add(album);
            context.SaveChanges();

            ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);
            artistBE.Load(1);
            ArtistBE artistBE2 = new ArtistBE(cRUDTestDBContextProvider);
            artistBE2.Load(2);
            var albumBECollection = artistBE.GetAlbums();
            Assert.IsTrue(albumBECollection.First().GetType() == typeof(AlbumBE));
            Assert.IsTrue(albumBECollection.First().Title == "TestAlbumTitle");
            Assert.IsTrue(albumBECollection.First().Id == 1);
            Assert.IsTrue(artistBE2.GetAlbums().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for adding new Track relationship
        /// </summary>
        [TestMethod]
        public void AddToAlbumTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var artist = new Artist
            {
                ArtistId = 1
            };
            var album = new Album { AlbumId = 1, Title = "TestAlbumTitle" };
            context.Add(artist);
            context.Add(album);
            context.SaveChanges();

            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);
            artistBE.Load(1);
            albumBE.Load(1);
            artistBE.AddToAlbum(albumBE);
            albumBE.Save();

            artistBE.Load(1);
            var AlbumBECollection = artistBE.GetAlbums();
            Assert.IsTrue(AlbumBECollection.First().Id == 1);
            Assert.IsTrue(AlbumBECollection.First().ArtistId == 1);
        }

        /// <summary>
        /// Test for accurate AlbumCount
        /// </summary>
        [TestMethod]
        public void AlbumCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var artist = new Artist
            {
                ArtistId = 1
            };
            var album = new Album { AlbumId = 1, ArtistId = 1, Title = "TestAlbumTitle" };
            context.Add(artist);
            context.Add(album);
            context.SaveChanges();

            ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);
            artistBE.Load(1);
            Assert.IsTrue(artistBE.AlbumCount == 1);

            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.New();
            albumBE.Title = "TestAlbumTitle";
            artistBE.AddToAlbum(albumBE);
            albumBE.Save();

            ArtistBE artistBE2 = new ArtistBE(cRUDTestDBContextProvider);
            artistBE2.Load(1);
            Assert.IsTrue(artistBE2.AlbumCount == 2);
        }

        /// <summary>
        /// Test for accurate ToString method
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();

            var artist = new Artist
            {
                Name = "TestArtistName",
                ArtistId = 1
            };
            context.Add(artist);
            context.SaveChanges();

            ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);
            artistBE.Load(1);
            Assert.IsTrue(artistBE.ToString().Equals("Artist Name: TestArtistName"));
        }
    }
}
