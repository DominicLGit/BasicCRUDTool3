using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BasicCRUDTool3.Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        [Key]
        public int AlbumId { get; set; }
        [Required]
        [StringLength(160)]
        public string Title { get; set; }
        public int ArtistId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("Album")]
        public virtual Artist Artist { get; set; }
        [InverseProperty("Album")]
        public virtual ICollection<Track> Track { get; set; }
    }
}
