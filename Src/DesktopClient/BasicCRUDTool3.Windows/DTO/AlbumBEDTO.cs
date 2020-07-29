using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Windows.DTO
{
    public class AlbumBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        [Required]
        [StringLength(160)]
        public string Title { get; set; }
        public int ArtistId { get;  set; }
        public string ArtistName { get;  set; }
        public int TrackCount { get;  set; }
        #endregion
    }
}
