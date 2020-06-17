using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class PlaylistTrackBE : BusinessEntity<PlaylistTrack, (int, int)>,
        IAssignToBusinessEntity<TrackBE>,
        IAssignToBusinessEntity<PlaylistBE>
    {
        #region Public Properties
        public string TrackName { get; private set; }
        public string PlaylistName { get; private set; }
        #endregion
        #region Constructors
        public PlaylistTrackBE(ICRUDTestDBContextProvider cRUDTestDBContext) : base(cRUDTestDBContext)
        {
        }
        #endregion

        #region Public Methods
        public void AssignTo(TrackBE trackBE)
        {
            Entity.TrackId = trackBE.Id;
        }

        public void AssignTo(PlaylistBE playlistBE)
        {
            Entity.PlaylistId = playlistBE.Id;
        }
        public override void Load((int, int) id)
        {

            base.Load(id);

            TrackName = Entity.Track.Name;
            PlaylistName = Entity.Playlist.Name;
        }

        public override void Save()
        {
            base.Save();

            if (Id == default)
            {
                Id = (Entity.PlaylistId, Entity.TrackId);
            }
        }

        public override string ToString()
        {
            return $"Playlist Name: {PlaylistName} Track Name: {TrackName}";
        }
        #endregion
    }
}
