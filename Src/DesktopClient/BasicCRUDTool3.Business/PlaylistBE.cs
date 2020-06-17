using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class PlaylistBE : BusinessEntity<Playlist, int>
    {
        #region Public Properties
        [StringLength(120)]
        public string Name { get; set; }
        public int PlaylistTrackCount { get; private set; }
        #endregion

        #region Constructors
        public PlaylistBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion

       #region Public Methods
       public IEnumerable<PlaylistTrackBE> GetPlaylistTracks()
        {
            var ids = Context.PlaylistTrack.Where(p=> p.PlaylistId == Id)
                .Select(p => new { p.PlaylistId, p.TrackId})
                .ToList()
                .Select(p => (p.PlaylistId, p.TrackId));

            foreach (var id in ids)
            {
                var item = new PlaylistTrackBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }

        public void AddTPlaylistTrack(PlaylistTrackBE playlistTrack)
        {
            playlistTrack.AssignTo(this);
        }

        public override void Load(int id)
        {
            base.Load(id);

            Name = Entity.Name;
            PlaylistTrackCount = Entity.PlaylistTrack.Count;
        }

        public override void Save()
        {
            Entity.Name = Name;
            base.Save();

            if (Id == default)
            {
                Id = Entity.PlaylistId;
            }
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
