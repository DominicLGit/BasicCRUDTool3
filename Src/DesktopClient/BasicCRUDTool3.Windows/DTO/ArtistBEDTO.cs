using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Windows.DTO
{
    public class ArtistBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        [StringLength(120)]
        public string Name { get; set; }
        public int AlbumCount { get; set; }
        #endregion
    }
}
