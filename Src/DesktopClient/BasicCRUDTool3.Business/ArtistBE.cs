using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class ArtistBE : BusinessEntity<Artist, int>
    {
        #region Public Properties
        public string Name { get; private set; }
        public int AlbumCount { get; private set }
        #endregion
        #region Constructors
        public ArtistBE(ICRUDTestDBContextProvider cRUDTestDBContext) : base(cRUDTestDBContext)
        {
        }
        #endregion

        #region Public Methods
        public IEnumerable<AlbumBE> GetAlbums()
        {
            var ids = Context.Album.Where(p => p.ArtistId == Id).Select(p => p.AlbumId);

            foreach (var id in ids)
            {
                var item = new AlbumBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }

        public void AddAlbum(AlbumBE album)
        {
            album.AssignTo(this);
        }

        public override void Load(int id)
        {
            base.Load(id);
            Name = Entity.Name;
            AlbumCount = Entity.Album.Count;
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
