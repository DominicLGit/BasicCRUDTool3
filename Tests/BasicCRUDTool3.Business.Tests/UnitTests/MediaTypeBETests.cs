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
    public class MediaTypeBETests
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
            var mediaType = new MediaType
            {
                Name = "TestMediaTypeName",
                MediaTypeId = 1
            };
            var mediaType2 = new MediaType
            {
                MediaTypeId = 2
            };
            context.Add(mediaType);
            context.Add(mediaType2);
            context.SaveChanges();

            MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE.Load(1);
            Assert.IsTrue(mediaTypeBE.Id == 1);
            Assert.IsTrue(mediaTypeBE.Name == "TestMediaTypeName");

            MediaTypeBE mediaTypeBE2 = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE2.Load(2);
            Assert.IsTrue(mediaTypeBE2.Id == 2);
        }

        /// <summary>
        /// Test for loading existing record via ID and saving it.
        /// </summary>
        [TestMethod]
        public void SaveValidIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var mediaType = new MediaType
            {
                MediaTypeId = 1
            };
            context.Add(mediaType);
            context.SaveChanges();

            MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE.Load(1);
            mediaTypeBE.Name = "TestMediaTypeName";
            mediaTypeBE.Save();

            MediaTypeBE mediaTypeBE2 = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE2.Load(1);
            Assert.IsTrue(mediaTypeBE2.Id == 1);
            Assert.IsTrue(mediaTypeBE2.Name == "TestMediaTypeName");
        }

        /// <summary>
        /// Test for creating new record and saving it. 
        /// </summary>
        [TestMethod]
        public void SaveWithoutIdTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE.New();
            mediaTypeBE.Name = "TestMediaTypeName";
            mediaTypeBE.Save();

            Assert.IsTrue(mediaTypeBE.Id != default);
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
            var mediaType = new MediaType
            {
                MediaTypeId = 1
            };
            var mediaType2 = new MediaType
            {
                MediaTypeId = 2
            };
            var track = new Track { TrackId = 1, MediaTypeId = 1, Name = "TestTrackName" };
            context.Add(mediaType);
            context.Add(mediaType2);
            context.Add(track);
            context.SaveChanges();

            MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE.Load(1);
            MediaTypeBE mediaTypeBE2 = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE2.Load(2);
            var TrackBECollection = mediaTypeBE.GetTracks();
            Assert.IsTrue(TrackBECollection.First().GetType() == typeof(TrackBE));
            Assert.IsTrue(TrackBECollection.First().Name == "TestTrackName");
            Assert.IsTrue(TrackBECollection.First().Id == 1);
            Assert.IsTrue(mediaTypeBE2.GetTracks().IsNullOrEmpty());
        }

        /// <summary>
        /// Test for adding new Track relationship
        /// </summary>
        [TestMethod]
        public void AddToTrackTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var mediaType = new MediaType
            {
                MediaTypeId = 1
            };
            var track = new Track { TrackId = 1, Name = "TestTrackName" };
            context.Add(mediaType);
            context.Add(track);
            context.SaveChanges();

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE.Load(1);
            trackBE.Load(1);
            mediaTypeBE.AddToTrack(trackBE);
            trackBE.Save();

            mediaTypeBE.Load(1);
            var InvoiceLineBECollection = mediaTypeBE.GetTracks();
            Assert.IsTrue(InvoiceLineBECollection.First().Id == 1);
            Assert.IsTrue(InvoiceLineBECollection.First().MediaTypeId == 1);
        }

        /// <summary>
        /// Test for accurate TrackCount
        /// </summary>
        [TestMethod]
        public void TrackCountTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();
            var mediaType = new MediaType
            {
                MediaTypeId = 1
            };
            var track = new Track { TrackId = 1, MediaTypeId = 1, Name = "TestTrackName" };
            context.Add(mediaType);
            context.Add(track);
            context.SaveChanges();

            MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE.Load(1);
            Assert.IsTrue(mediaTypeBE.TrackCount == 1);

            TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);
            trackBE.New();
            trackBE.Name = "TestName";
            mediaTypeBE.AddToTrack(trackBE);
            trackBE.Save();

            MediaTypeBE mediaTypeBE2 = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE2.Load(1);
            Assert.IsTrue(mediaTypeBE2.TrackCount == 2);
        }

        /// <summary>
        /// Test for accurate ToString method
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            ICRUDTestDBContextProvider cRUDTestDBContextProvider = new CRUDTestDBContextProvider(Guid.NewGuid().ToString());
            var context = cRUDTestDBContextProvider.GetContext();

            var mediaType = new MediaType
            {
                MediaTypeId = 1,
                Name = "TestMediaTypeName"
            };
            context.Add(mediaType);
            context.SaveChanges();

            MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);
            mediaTypeBE.Load(1);
            Assert.IsTrue(mediaTypeBE.ToString().Equals("MediaType Name: TestMediaTypeName"));
        }
    }
}
