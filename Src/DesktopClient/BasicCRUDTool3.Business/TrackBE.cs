using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
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
/*        public IEnumerable<TrackBE> GetPlaylistTracks()
        {
            //TODO: Add support for multiple primary key values
            var ids = Context.PlaylistTrack.Where(p => p.TrackId == Id).Select(p = > p.)
            var ids = Context.Track.Where(p => p.AlbumId == Id).Select(p => p.TrackId);

            foreach (var id in ids)
            {
                var item = new TrackBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }
        public IEnumerable<TrackBE> GetInvoiceLines()
        {
            var ids = Context.Track.Where(p => p.AlbumId == Id).Select(p => p.TrackId);
            var ids = Context.Track.Where(p => p.AlbumId == Id).Select(p => p.TrackId);

            foreach (var id in ids)
            {
                var item = new TrackBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }*/
        public void AssignTo(AlbumBE album)
        {
            Entity.AlbumId = album.Id;
        }

        public void AssignTo(MediaTypeBE mediaType)
        {
            Entity.MediaTypeId = mediaType.Id;
        }

        public void AssignTo(GenreBE businessEntity)
        {
            throw new NotImplementedException();
        }

        public override void Load(int id)
        {
            base.Load(id);

            Name = Entity.Name;
            AlbumTitle = Entity.Album.Title;
            MediaTypeName = Entity.MediaType.Name;
            GenreName = Entity.Genre.Name;
            PlaylistTrackCount = Entity.PlaylistTrack.Count;
            InvoiceLineCount = Entity.InvoiceLine.Count;
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
