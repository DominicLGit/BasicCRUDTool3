using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BasicCRUDTool3.Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class PlaylistTrack
    {
        [Key]
        public int PlaylistId { get; set; }
        [Key]
        public int TrackId { get; set; }

        [ForeignKey(nameof(PlaylistId))]
        [InverseProperty("PlaylistTrack")]
        public virtual Playlist Playlist { get; set; }
        [ForeignKey(nameof(TrackId))]
        [InverseProperty("PlaylistTrack")]
        public virtual Track Track { get; set; }
    }
}
