using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BasicCRUDTool3.Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class MediaType
    {
        public MediaType()
        {
            Track = new HashSet<Track>();
        }

        [Key]
        public int MediaTypeId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

        [InverseProperty("MediaType")]
        public virtual ICollection<Track> Track { get; set; }
    }
}
