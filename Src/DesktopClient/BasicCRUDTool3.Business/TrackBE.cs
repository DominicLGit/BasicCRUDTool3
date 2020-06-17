using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class TrackBE : BusinessEntity<Track, int>,
        IAssignToBusinessEntity<AlbumBE>,
        IAssignToBusinessEntity<MediaTypeBE>,
        IAssignToBusinessEntity<GenreBE>
    {
        #region Public Properties
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(220)]
        public string Composer { get; set; }
        [Range(0, int.MaxValue)]
        public int Milliseconds { get; set; }
        public string AlbumTitle { get; private set; }
        public string MediaTypeName { get; private set; }
        public string GenreName { get; private set; }
        public int PlaylistTrackCount { get; private set; }
        public int InvoiceLineCount { get; private set; }
        #endregion

        #region Constructors
        public TrackBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion

        #region Public Methods
       public IEnumerable<PlaylistTrackBE> GetPlaylistTracks()
        {
            var ids = Context.PlaylistTrack.Where(p => p.TrackId == Id)
                .Select(p => new { p.PlaylistId, p.TrackId})
                .ToList()
                .Select(p => (p.PlaylistId, p.TrackId));

            foreach (var id in ids)
            {
                var item = new PlaylistTrackBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }
        public IEnumerable<InvoiceLineBE> GetInvoiceLines()
        {
            var ids = Context.InvoiceLine.Where(p => p.TrackId == Id).Select(p => p.InvoiceLineId);

            foreach (var id in ids)
            {
                var item = new InvoiceLineBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }
        public void AddTPlaylistTrack(PlaylistTrackBE playlistTrack)
        {
            playlistTrack.AssignTo(this);
        }

        public void AssignTo(AlbumBE album)
        {
            Entity.AlbumId = album.Id;
        }

        public void AssignTo(MediaTypeBE mediaType)
        {
            Entity.MediaTypeId = mediaType.Id;
        }

        public void AssignTo(GenreBE genreBE)
        {
            Entity.GenreId = genreBE.Id;
        }

        public override void Load(int id)
        {
            base.Load(id);

            Name = Entity.Name;
            Composer = Entity.Composer;
            Milliseconds = Entity.Milliseconds;
            AlbumTitle = Entity.Album.Title;
            MediaTypeName = Entity.MediaType.Name;
            GenreName = Entity.Genre.Name;
            PlaylistTrackCount = Entity.PlaylistTrack.Count;
            InvoiceLineCount = Entity.InvoiceLine.Count;
        }

        public override void Save()
        {
            Entity.Name = Name;
            Entity.Composer = Composer;
            Entity.Milliseconds = Milliseconds;
            base.Save();

            if (Id == default)
            {
                Id = Entity.TrackId;
            }
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
