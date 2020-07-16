using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Blazor.Shared.DTO
{
    public class ArtistBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumCount { get; private set; }
        #endregion
    }
}
