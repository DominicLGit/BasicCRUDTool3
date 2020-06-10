﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCRUDTool3.Data.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        [Key]
        public int PlaylistId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

        [InverseProperty("Playlist")]
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
