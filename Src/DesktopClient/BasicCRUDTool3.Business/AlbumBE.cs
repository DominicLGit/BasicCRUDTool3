using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class AlbumBE : BusinessEntity<Album, int>, IAssignToBusinessEntity<ArtistBE>
    {
        #region Public Properties
        public string Title { get; private set; }
        public string ArtistName { get; private set; }
        public int TrackCount { get; private set;  }
        #endregion

        #region Constructors
        public AlbumBE(ICRUDTestDBContextProvider contextProvider) : base (contextProvider)
        {
        }
        #endregion

        #region Public Methods
        public IEnumerable<TrackBE> GetTracks()
        {
            var ids = Context.Track.Where(p => p.AlbumId == Id).Select(p => p.TrackId);

            foreach (var id in ids)
            {
                var item = new TrackBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }

        public void AddTrack(TrackBE track)
        {
            track.AssignTo(this);
        }

        public void AssignTo(ArtistBE artist)
        {
            Entity.ArtistId = artist.Id;
        }

        public override void Load(int id)
        {
            base.Load(id);

            Title = Entity.Title;
            ArtistName = Entity.Artist.Name;
            TrackCount = Entity.Track.Count();
        }

        public override string ToString()
        {
            return Title;
        }
        #endregion
    }
}
