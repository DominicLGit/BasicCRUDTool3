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
    public class TrackBETests
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
            var track = new Track
            {
                TrackId = 1,
                Name = "TestTrackName",
                Composer = "TestComposer",
                Milliseconds = 1000,
                AlbumId = 1,
                MediaTypeId = 1,
                GenreId = 1
                
            };
            var track2 = new Track
            {
                TrackId = 2,
                Name = "TestTrackName",
                Composer = "TestComposer",
                Milliseconds = 1000,
            };
            var track3 = new Track
            {
                TrackId = 3,
                Name = "TestTrackName",
                Composer = "TestComposer",
                Milliseconds = 1000,
                AlbumId = 3,
                MediaTypeId = 3,
                GenreId = 3

            };
            var album = new Album { AlbumId = 1 , Title = "TestTitle"};
            var mediaType = new MediaType { MediaTypeId = 1 , Name = "TestMediaType"};
            var genre = new Genre { GenreId = 1, Name = "TestGenre" };
            var album3 = new Album { AlbumId = 3, Title = "TestTitle" };
            var mediaType3 = new MediaType { MediaTypeId = 3 };
            var genre3 = new Genre { GenreId = 3 };
            context.Add(album);
            context.Add(mediaType);
            context.Add(genre);
            context.Add(track);
            context.Add(track2);
            context.Add(track3);
            context.Add(album3);
            context.Add(mediaType3);
            context.Add(genre3);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            Assert.IsTrue(trackBE.Id == 1);
            Assert.IsTrue(trackBE.Name == "TestTrackName");
            Assert.IsTrue(trackBE.Composer == "TestComposer");
            Assert.IsTrue(trackBE.Milliseconds == 1000);
            Assert.IsTrue(trackBE.AlbumId == 1);
            Assert.IsTrue(trackBE.MediaTypeId == 1);
            Assert.IsTrue(trackBE.GenreId == 1);
            Assert.IsTrue(trackBE.AlbumTitle == "TestTitle");
            Assert.IsTrue(trackBE.MediaTypeName == "TestMediaType");
            Assert.IsTrue(trackBE.GenreName == "TestGenre");

            TrackBE trackBE2 = new TrackBE(cRUDTestDBContextProvider);
            trackBE2.Load(2);
            Assert.IsTrue(trackBE2.Id == 2);
            Assert.IsTrue(trackBE2.Name == "TestTrackName");
            Assert.IsTrue(trackBE2.Composer == "TestComposer");
            Assert.IsTrue(trackBE2.Milliseconds == 1000);

            TrackBE trackBE3 = new TrackBE(cRUDTestDBContextProvider);
            trackBE3.Load(3);
            Assert.IsTrue(trackBE3.Id == 3);
            Assert.IsTrue(trackBE3.Name == "TestTrackName");
            Assert.IsTrue(trackBE3.Composer == "TestComposer");
            Assert.IsTrue(trackBE3.Milliseconds == 1000);
            Assert.IsTrue(trackBE3.AlbumTitle == "TestTitle");
        }

        /// <summary>
        /// Test for loading existing record via ID and saving it.
        /// </summary>
        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 1 };
            context.Add(track);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            trackBE.Name = "TestTrackName";
            trackBE.Composer = "TestComposer";
            trackBE.Milliseconds = 1000;
            trackBE.Save();

            TrackBE trackBE2 = new TrackBE(cRUDTestDBContextProvider);
            trackBE2.Load(1);
            Assert.IsTrue(trackBE2.Id == 1);
            Assert.IsTrue(trackBE2.Name == "TestTrackName");
            Assert.IsTrue(trackBE2.Composer == "TestComposer");
            Assert.IsTrue(trackBE2.Milliseconds == 1000);
        }

        /// <summary>
        /// Test for creating new record and saving it. 
        /// </summary>
        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.New();
            trackBE.Name = "TestTrackName";
            trackBE.Save();

            Assert.IsTrue(trackBE.Id != default);
        }

        /// <summary>
        /// Test for returning InvoiceLineBE objects related to record if relationship exists
        /// Test for returning no InvoiceLineBE objects related to record is relationships do not exist
        /// </summary>
        [TestMethod]
        public void GetInvoiceLinesTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 2 };
            var track2 = new Track { TrackId = 1 };
            var invoiceLine = new InvoiceLine { InvoiceLineId = 1, TrackId = 1, Quantity = 10 };
            context.Add(track);
            context.Add(track2);
            context.Add(invoiceLine);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            TrackBE trackBE2 = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            trackBE2.Load(2);
            var invoiceLineBECollection = trackBE.GetInvoiceLines();
            Assert.IsTrue(invoiceLineBECollection.First().GetType() == typeof(InvoiceLineBE));
            Assert.IsTrue(invoiceLineBECollection.First().Quantity == 10);
            Assert.IsTrue(invoiceLineBECollection.First().Id == 1);
            Assert.IsTrue(trackBE2.GetInvoiceLines().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for adding new InvoiceLine relationship
        /// </summary>
        [TestMethod]
        public void AddToInvoiceLineTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 1 };
            var invoiceLine = new InvoiceLine { InvoiceLineId = 1, Quantity = 20 };
            context.Add(track);
            context.Add(invoiceLine);
            context.SaveChanges();

            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            invoiceLineBE.Load(1);
            trackBE.AddToInvoiceLine(invoiceLineBE);
            invoiceLineBE.Save();

            trackBE.Load(1);
            var InvoiceLineBECollection = trackBE.GetInvoiceLines();
            Assert.IsTrue(InvoiceLineBECollection.First().Id == 1);
            Assert.IsTrue(InvoiceLineBECollection.First().TrackId == 1);
        }

        /// <summary>
        /// Test for accurate InvoiceLineCount
        /// </summary>
        [TestMethod]
        public void InvoiceLineCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 1 };
            var invoiceLine = new InvoiceLine { InvoiceLineId = 1, TrackId = 1 };
            context.Add(track);
            context.Add(invoiceLine);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            Assert.IsTrue(trackBE.InvoiceLineCount == 1);

            InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);
            invoiceLineBE.New();
            trackBE.AddToInvoiceLine(invoiceLineBE);
            invoiceLineBE.Save();

            TrackBE trackBE2 = new TrackBE(cRUDTestDBContextProvider);
            trackBE2.Load(1);
            Assert.IsTrue(trackBE2.InvoiceLineCount == 2);
        }

        /// <summary>
        /// Test for returning PlaylistTRackBE objects related to record if relationship exists
        /// Test for returning no PlaylistTRackBE objects related to record is relationships do not exist
        /// </summary>
        [TestMethod]
        public void GetPlaylistTracksTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 2 };
            var track2 = new Track { TrackId = 1 };
            var playlistTrack = new PlaylistTrack { PlaylistId = 1, TrackId = 1 };
            var playlist = new Playlist { PlaylistId = 1 };
            context.Add(track);
            context.Add(track2);
            context.Add(playlistTrack);
            context.Add(playlist);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            TrackBE trackBE2 = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            trackBE2.Load(2);
            var playlistTrackBECollection = trackBE.GetPlaylistTracks();
            Assert.IsTrue(playlistTrackBECollection.First().GetType() == typeof(PlaylistTrackBETests));
            Assert.IsTrue(playlistTrackBECollection.First().Id == (1,1));
            Assert.IsTrue(trackBE2.GetPlaylistTracks().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for adding new PlaylistTrack relationship
        /// </summary>
        [TestMethod]
        public void AddToPlaylistTrackTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 1 };
            var playlist = new Playlist { PlaylistId = 1 };
            context.Add(track);
            context.Add(playlist);
            context.SaveChanges();

            PlaylistTrackBE playlistTrackBE = new PlaylistTrackBE(cRUDTestDBContextProvider);
            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            playlistBE.Load(1);
            playlistTrackBE.New();
            trackBE.AddToPlaylistTrack(playlistTrackBE);
            playlistBE.AddToPlaylistTrack(playlistTrackBE);
            playlistTrackBE.Save();

            trackBE.Load(1);
            var playlistTrackBECollection = trackBE.GetPlaylistTracks();
            Assert.IsTrue(playlistTrackBECollection.First().PlaylistId == 1);
            Assert.IsTrue(playlistTrackBECollection.First().TrackId == 1);
        }

        /// <summary>
        /// Test for accurate PlaylistTrackCount
        /// </summary>
        [TestMethod]
        public void PlaylistTrackCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 1 };
            var playlist = new Playlist { PlaylistId = 1 };
            var playlist2 = new Playlist { PlaylistId = 2 };
            var playlistTrack = new PlaylistTrack { PlaylistId = 1, TrackId = 1 };
            context.Add(track);
            context.Add(playlist);
            context.Add(playlist2);
            context.Add(playlistTrack);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            Assert.IsTrue(trackBE.PlaylistTrackCount == 1);

            PlaylistTrackBE playlistTrackBE = new PlaylistTrackBE(cRUDTestDBContextProvider);
            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE.Load(2);
            playlistTrackBE.New();
            trackBE.AddToPlaylistTrack(playlistTrackBE);
            playlistBE.AddToPlaylistTrack(playlistTrackBE);
            playlistTrackBE.Save();

            TrackBE trackBE2 = new TrackBE(cRUDTestDBContextProvider);
            trackBE2.Load(1);
            Assert.IsTrue(trackBE2.PlaylistTrackCount == 2);
        }

        /// <summary>
        /// Test for accurate ToString method
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track { TrackId = 1, Name = "TestName" };
            context.Add(track);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.Load(1);
            Assert.IsTrue(trackBE.ToString().Equals("Title: TestName"));
        }
    }
}
