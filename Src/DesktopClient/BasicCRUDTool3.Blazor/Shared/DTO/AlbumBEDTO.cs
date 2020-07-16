using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Blazor.Shared.DTO
{
    public class AlbumBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get;  set; }
        public string ArtistName { get;  set; }
        public int TrackCount { get;  set; }
        #endregion
    }
}
