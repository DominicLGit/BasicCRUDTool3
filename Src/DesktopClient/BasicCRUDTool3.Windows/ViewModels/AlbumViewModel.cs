using BasicCRUDTool3.Windows.DTO;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public class AlbumViewModel : ReactiveObject
    {
        #region Private Members
        private readonly AlbumBEDTO albumBEDTO;
        #endregion

        #region Public Properties
        public int Id => albumBEDTO.Id;
        [Required]
        [StringLength(160)]
        public string Title => albumBEDTO.Title;
        public int ArtistId => albumBEDTO.ArtistId;
        public string ArtistName => albumBEDTO.ArtistName;
        public int TrackCount => albumBEDTO.TrackCount;
        #endregion

        #region Constructors
        public AlbumViewModel(AlbumBEDTO albumBEDTO)
        {
            this.albumBEDTO = albumBEDTO;

        }
        #endregion

    }
}
