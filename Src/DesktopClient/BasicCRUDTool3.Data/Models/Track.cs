using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BasicCRUDTool3.Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Track
    {
        public Track()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        [Key]
        public int TrackId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        [StringLength(220)]
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        [Column(TypeName = "numeric(10,2)")]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty("Track")]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Track")]
        public virtual Genre Genre { get; set; }
        [ForeignKey(nameof(MediaTypeId))]
        [InverseProperty("Track")]
        public virtual MediaType MediaType { get; set; }
        [InverseProperty("Track")]
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        [InverseProperty("Track")]
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
