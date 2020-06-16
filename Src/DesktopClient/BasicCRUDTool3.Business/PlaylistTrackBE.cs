using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class PlaylistTrackBE : BusinessEntity<PlaylistTrack, int>
    {
        #region Public Properties
        public string TrackName { get; private set; }
        public string PlaylistName { get; private set; }
        #endregion
        #region Constructors
        public PlaylistTrackBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion


    }
}
