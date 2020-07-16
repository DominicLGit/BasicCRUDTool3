using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Blazor.Shared.DTO
{
    public class PlaylistTrackBEDTO
    {
        #region Public Properties
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string PlaylistName { get; set; }
        #endregion
    }
}
