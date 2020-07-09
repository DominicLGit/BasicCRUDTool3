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

        /// <summary>
        /// Test for returning all ArtistBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetArtistBEsFullTest()
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
                Name = "TestArtistName",
                ArtistId = 2
            };
            context.Add(artist);
            context.Add(artist2);
            context.SaveChanges();

            var artists = new Business(cRUDTestDBContextProvider).GetArtistBEs();
            Assert.IsTrue(artists.First().GetType() == typeof(ArtistBE));
            Assert.IsTrue(artists.First().Name == "TestArtistName");
            Assert.IsTrue(artists.Count() == 2);
        }

        /// <summary>
        /// Test for returning no ArtistBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetArtistBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetArtistBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all CustomerBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetCustomerBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var customer = new Customer
            {
                FirstName = "TestFirstName",
                CustomerId = 1
            };
            var customer2 = new Customer
            {
                FirstName = "TestFirstName",
                CustomerId = 2
            };
            context.Add(customer);
            context.Add(customer2);
            context.SaveChanges();

            var customers = new Business(cRUDTestDBContextProvider).GetCustomerBEs();
            Assert.IsTrue(customers.First().GetType() == typeof(CustomerBE));
            Assert.IsTrue(customers.First().FirstName == "TestFirstName");
            Assert.IsTrue(customers.Count() == 2);
        }

        /// <summary>
        /// Test for returning no CustomerBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetCustomerBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetCustomerBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all EmployeeBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetEmployeeBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var employee = new Employee
            {
                FirstName = "TestFirstName",
                EmployeeId = 1
            };
            var employee2 = new Employee
            {
                FirstName = "TestFirstName",
                EmployeeId = 2
            };
            context.Add(employee);
            context.Add(employee2);
            context.SaveChanges();

            var employees = new Business(cRUDTestDBContextProvider).GetEmployeeBEs();
            Assert.IsTrue(employees.First().GetType() == typeof(EmployeeBE));
            Assert.IsTrue(employees.First().FirstName == "TestFirstName");
            Assert.IsTrue(employees.Count() == 2);
        }

        /// <summary>
        /// Test for returning no EmployeeBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetEmployeeBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetEmployeeBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all GenreBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetGenreBEsFullTest()
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
                Name = "TestGenreName",
                GenreId = 2
            };
            context.Add(genre);
            context.Add(genre2);
            context.SaveChanges();

            var genres = new Business(cRUDTestDBContextProvider).GetGenreBEs();
            Assert.IsTrue(genres.First().GetType() == typeof(GenreBE));
            Assert.IsTrue(genres.First().Name == "TestGenreName");
            Assert.IsTrue(genres.Count() == 2);
        }

        /// <summary>
        /// Test for returning no GenreBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetGenreBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetGenreBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all InvoiceBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetInvoiceBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoice = new Invoice
            {
                BillingAddress = "TestAddress",
                InvoiceId = 1
            };
            var invoice2 = new Invoice
            {
                BillingAddress = "TestAddress",
                InvoiceId = 2
            };
            context.Add(invoice);
            context.Add(invoice2);
            context.SaveChanges();

            var invoices = new Business(cRUDTestDBContextProvider).GetInvoiceBEs();
            Assert.IsTrue(invoices.First().GetType() == typeof(InvoiceBE));
            Assert.IsTrue(invoices.First().BillingAddress == "TestAddress");
            Assert.IsTrue(invoices.Count() == 2);
        }

        /// <summary>
        /// Test for returning no InvoiceBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetInvoiceBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetInvoiceBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all InvoiceLineBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetInvoiceLineBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var invoiceLine = new InvoiceLine
            {
                Quantity = 10,
                InvoiceLineId = 1
            };
            var invoiceLine2 = new InvoiceLine
            {
                Quantity = 10,
                InvoiceLineId = 2
            };
            context.Add(invoiceLine);
            context.Add(invoiceLine2);
            context.SaveChanges();

            var invoiceLines = new Business(cRUDTestDBContextProvider).GetInvoiceLineBEs();
            Assert.IsTrue(invoiceLines.First().GetType() == typeof(InvoiceLineBE));
            Assert.IsTrue(invoiceLines.First().Quantity == 10);
            Assert.IsTrue(invoiceLines.Count() == 2);
        }

        /// <summary>
        /// Test for returning no InvoiceLineBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetInvoiceLineBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetInvoiceLineBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all MediaTypeBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetMediaTypeBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var mediaType = new MediaType
            {
                Name = "TestMediaTypeName",
                MediaTypeId = 1
            };
            var mediaType2 = new MediaType
            {
                Name = "TestMediaTypeName",
                MediaTypeId = 2
            };
            context.Add(mediaType);
            context.Add(mediaType2);
            context.SaveChanges();

            var mediaTypes = new Business(cRUDTestDBContextProvider).GetMediaTypeBEs();
            Assert.IsTrue(mediaTypes.First().GetType() == typeof(MediaTypeBE));
            Assert.IsTrue(mediaTypes.First().Name == "TestMediaTypeName");
            Assert.IsTrue(mediaTypes.Count() == 2);
        }

        /// <summary>
        /// Test for returning no MediaTypeBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetMediaTypeBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetMediaTypeBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all PlaylistBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetPlaylistBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var playlist = new Playlist
            {
                Name = "TestPlaylistName",
                PlaylistId = 1
            };
            var playlist2 = new Playlist
            {
                Name = "TestPlaylistName",
                PlaylistId = 2
            };
            context.Add(playlist);
            context.Add(playlist2);
            context.SaveChanges();

            var playlists = new Business(cRUDTestDBContextProvider).GetPlaylistBEs();
            Assert.IsTrue(playlists.First().GetType() == typeof(PlaylistBE));
            Assert.IsTrue(playlists.First().Name == "TestPlaylistName");
            Assert.IsTrue(playlists.Count() == 2);
        }

        /// <summary>
        /// Test for returning no PlaylistBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetPlaylistBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetPlaylistBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all PlaylistTrackBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetPlaylistTrackBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var playlistTrack = new PlaylistTrack
            {
                TrackId = 1,
                PlaylistId = 1
            };
            var playlistTrack2 = new PlaylistTrack
            {
                TrackId = 2,
                PlaylistId = 1
            };
            var track = new Track
            {
                TrackId = 1,
                Name = "TestTrackName"
            };
            var track2 = new Track
            {
                TrackId = 2,
                Name = "TestTrackName"
            };
            var playlist = new Playlist
            {
                PlaylistId = 1,
                Name = "TestPlaylistName"
            };
            context.Add(playlistTrack);
            context.Add(playlistTrack2);
            context.Add(track);
            context.Add(track2);
            context.Add(playlist);
            context.SaveChanges();

            var playlistTracks = new Business(cRUDTestDBContextProvider).GetPlaylistTrackBEs();
            Assert.IsTrue(playlistTracks.First().GetType() == typeof(PlaylistTrackBE));
            Assert.IsTrue(playlistTracks.Count() == 2);
        }

        /// <summary>
        /// Test for returning no PlaylistTrackBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetPlaylistTrackBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetPlaylistTrackBEs().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for returning all TrackBE objects if any exists
        /// </summary>
        [TestMethod]
        public void GetTrackBEsFullTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var track = new Track
            {
                Name = "TestTrackName",
                TrackId = 1
            };
            var track2 = new Track
            {
                Name = "TestTrackName",
                TrackId = 2
            };
            context.Add(track);
            context.Add(track2);
            context.SaveChanges();

            var tracks = new Business(cRUDTestDBContextProvider).GetTrackBEs();
            Assert.IsTrue(tracks.First().GetType() == typeof(TrackBE));
            Assert.IsTrue(tracks.First().Name == "TestTrackName");
            Assert.IsTrue(tracks.Count() == 2);
        }

        /// <summary>
        /// Test for returning no TrackBE objects if none exist
        /// </summary>
        [TestMethod]
        public void GetTrackBEsEmptyTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            Assert.IsTrue(new Business(cRUDTestDBContextProvider).GetTrackBEs().IsNullOrEmpty());
        }
    }
}
