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
    public class PlaylistBETests
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
            var playlist = new Playlist
            {
                Name = "TestPlaylistName",
                PlaylistId = 1
            };
            var playlist2 = new Playlist
            {
                PlaylistId = 2
            };
            context.Add(playlist);
            context.Add(playlist2);
            context.SaveChanges();

            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE.Load(1);
            Assert.IsTrue(playlistBE.Id == 1);
            Assert.IsTrue(playlistBE.Name == "TestPlaylistName");

            PlaylistBE playlistBE2 = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE2.Load(2);
            Assert.IsTrue(playlistBE2.Id == 2);
        }

        /// <summary>
        /// Test for loading existing record via ID and saving it.
        /// </summary>
        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var playlist = new Playlist
            {
                PlaylistId = 1
            };
            context.Add(playlist);
            context.SaveChanges();

            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE.Load(1);
            playlistBE.Name = "TestPlaylistName";
            playlistBE.Save();

            PlaylistBE playlistBE2 = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE2.Load(1);
            Assert.IsTrue(playlistBE2.Id == 1);
            Assert.IsTrue(playlistBE2.Name == "TestPlaylistName");
        }

        /// <summary>
        /// Test for creating new record and saving it. 
        /// </summary>
        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE.New();
            playlistBE.Name = "TestPlaylistName";
            playlistBE.Save();

            Assert.IsTrue(playlistBE.Id != default);
        }

        /// <summary>
        /// Test for returning PlaylistTrackBE objects related to record if relationship exists
        /// Test for returning no PlaylistTrackBE objects related to record is relationships do not exist
        /// </summary>
        [TestMethod]
        public void GetPlaylistTracksTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var playlist = new Playlist
            {
                PlaylistId = 1
            };
            var playlist2 = new Playlist
            {
                PlaylistId = 2
            };
            var track = new Track
            {
                TrackId = 1,
                Name = "TestTrackName"
            };
            var playlistTrack = new PlaylistTrack { PlaylistId = 1, TrackId = 1 };
            context.Add(playlist);
            context.Add(playlist2);
            context.Add(playlistTrack);
            context.Add(track);
            context.SaveChanges();

            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE.Load(1);
            PlaylistBE playlistBE2 = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE2.Load(2);
            var playlistTrackCollection = playlistBE.GetPlaylistTracks();
            Assert.IsTrue(playlistTrackCollection.First().GetType() == typeof(PlaylistTrackBE));
            Assert.IsTrue(playlistTrackCollection.First().Id == (1,1));
            Assert.IsTrue(playlistBE2.GetPlaylistTracks().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for adding new PlaylistTrack relationship
        /// </summary>
        [TestMethod]
        public void AddToAlbumTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var playlist = new Playlist
            {
                PlaylistId = 1,
                Name = "TestPlaylistName"
            };
            var track = new Track
            {
                TrackId = 1,
                Name = "TestTrackName"
            };
            context.Add(playlist);
            context.Add(track);
            context.SaveChanges();

            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            PlaylistTrackBE playlistTrackBE = new PlaylistTrackBE(cRUDTestDBContextProvider);
            playlistBE.Load(1);
            trackBE.Load(1);
            playlistTrackBE.New();
            playlistBE.AddToPlaylistTrack(playlistTrackBE);
            trackBE.AddToPlaylistTrack(playlistTrackBE);
            playlistTrackBE.Save();

            playlistBE.Load(1);
            var playlistTrackCollection = playlistBE.GetPlaylistTracks();
            Assert.IsTrue(playlistTrackCollection.First().Id == (1,1));
            Assert.IsTrue(playlistTrackCollection.First().PlaylistName == "TestPlaylistName");
        }

        /// <summary>
        /// Test for accurate PlaylistTrackCount
        /// </summary>
        [TestMethod]
        public void PlaylistTrackCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var playlist = new Playlist
            {
                PlaylistId = 1,
                Name = "TestPlaylistName"
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
            var playlistTrack = new PlaylistTrack
            {
                PlaylistId = 1,
                TrackId = 1
            };
            context.Add(playlist);
            context.Add(track);
            context.Add(track2);
            context.Add(playlistTrack);
            context.SaveChanges();

            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE.Load(1);
            Assert.IsTrue(playlistBE.PlaylistTrackCount == 1);

            PlaylistTrackBE playlistTrackBE = new PlaylistTrackBE(cRUDTestDBContextProvider);
            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            playlistTrackBE.New();
            trackBE.Load(2);
            playlistBE.AddToPlaylistTrack(playlistTrackBE);
            trackBE.AddToPlaylistTrack(playlistTrackBE);
            playlistTrackBE.Save();

            PlaylistBE playlistBE3 = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE3.Load(1);
            Assert.IsTrue(playlistBE3.PlaylistTrackCount == 2);
        }

        /// <summary>
        /// Test for accurate ToString method
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();

            var playlist = new Playlist
            {
                PlaylistId = 1,
                Name = "TestPlaylistName"
            };
            context.Add(playlist);
            context.SaveChanges();

            PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);
            playlistBE.Load(1);
            Assert.IsTrue(playlistBE.ToString().Equals("Playlist Name: TestPlaylistName"));
        }
    }
}
