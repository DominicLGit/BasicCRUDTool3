using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class MediaTypeBE : BusinessEntity<MediaType, int>
    {
        #region Public Properties
        [StringLength(120)]
        public string Name { get;  set; }
        public int TrackCount { get; private set; }
        #endregion

        #region Constructors
        public MediaTypeBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion

        #region Public Methods
        public IEnumerable<TrackBE> GetTracks()
        {
            var ids = Context.Track.Where(p => p.GenreId == Id).Select(p => p.TrackId);

            foreach (var id in ids)
            {
                var item = new TrackBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }

        public void AddTrack(TrackBE track)
        {
            track.AssignTo(this);
        }

        public override void Load(int id)
        {
            base.Load(id);

            Name = Entity.Name;
            TrackCount = Entity.Track.Count;
        }

        public override void Save()
        {
            Entity.Name = Name;
            base.Save();

            if (Id == default)
            {
                Id = Entity.MediaTypeId;
            }
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
