using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BasicCRUDTool3.Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        [Key]
        public int ArtistId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

        [InverseProperty("Artist")]
        public virtual ICollection<Album> Album { get; set; }
    }
}
