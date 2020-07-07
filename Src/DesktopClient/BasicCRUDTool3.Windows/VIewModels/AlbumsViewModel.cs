using BasicCRUDTool3.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public class AlbumsViewModel : ViewModel
    {
        #region Public Properties
        public AlbumBE[] Albums { get; set; }
        public int AlbumID { get; set; } = 1;
        public int ArtistID { get; set; } = 1;
        public int TrackCount { get; set; } = 1;
        public string Title { get; set; } = "TestAlumTitle";
        public string ArtistName { get; set; } = "TestArtistName";
        #endregion
    }
}
