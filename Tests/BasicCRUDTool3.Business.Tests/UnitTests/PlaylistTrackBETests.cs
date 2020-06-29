using BasicCRUDTool3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business.Tests.UnitTests
{
    [TestClass]
    public class PlaylistTrackBETests
    {
        /// <summary>
        /// Test for loading existing object from database with all attributes
        /// Test for loading existing object from database with missing non-required attributes from relationships
        /// </summary>
        [TestMethod]
        public void LoadValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var playlistTrack = new PlaylistTrack
            {
                PlaylistId = 1,
                TrackId = 1
            };
            var playlist = new Playlist
            {
                Name = "TestPlaylistName",
                PlaylistId = 1
            };
            var track = new Track
            {
                TrackId = 1,
                Name = "TestTrackName"
            };
            var playlistTrack2 = new PlaylistTrack
            {
                PlaylistId = 2,
                TrackId = 2
            };
            var playlist2 = new Playlist
            {
                PlaylistId = 2
            };
            var track2 = new Track
            {
                TrackId = 2,
                Name = "TestTrackName"
            };
            context.Add(playlistTrack);
            context.Add(playlist);
            context.Add(track);
            context.Add(playlistTrack2);
            context.Add(playlist2);
            context.Add(track2);
            context.SaveChanges();

            PlaylistTrackBE playlistTrackBE = new PlaylistTrackBE(cRUDTestDBContextProvider);
            playlistTrackBE.Load((1,1), 1, 1);
            Assert.IsTrue(playlistTrackBE.Id == (1,1));
            Assert.IsTrue(playlistTrackBE.PlaylistName == "TestPlaylistName");
            Assert.IsTrue(playlistTrackBE.TrackName == "TestTrackName");

            PlaylistTrackBE playlistTrackBE2 = new PlaylistTrackBE(cRUDTestDBContextProvider);
            playlistTrackBE2.Load((2, 2), 2, 2);
            Assert.IsTrue(playlistTrackBE2.Id == (2,2));
            Assert.IsTrue(playlistTrackBE2.TrackName == "TestTrackName");
        }
    }
}
