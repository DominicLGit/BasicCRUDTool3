using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class TrackBE : BusinessEntity<Track, int>,
        IAssignToBusinessEntity<AlbumBE>,
        IAssignToBusinessEntity<MediaTypeBE>,
        IAssignToBusinessEntity<GenreBE>
    {
        public TrackBE(ICRUDTestDBContextProvider cRUDTestDBContext) : base (cRUDTestDBContext)
        {
        }

        #region Public Methods
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
        #endregion
    }
}
