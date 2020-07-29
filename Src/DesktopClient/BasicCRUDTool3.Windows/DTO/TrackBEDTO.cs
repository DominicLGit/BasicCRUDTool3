using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Windows.DTO
{
    public class TrackBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(220)]
        public string Composer { get; set; }
        [Range(0, int.MaxValue)]
        public int Milliseconds { get; set; }
        public int? AlbumId { get; set; }
        public int? MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string AlbumTitle { get; set; }
        public string MediaTypeName { get; set; }
        public string GenreName { get; set; }
        public int PlaylistTrackCount { get; set; }
        public int InvoiceLineCount { get; set; }
        #endregion
    }
}
