using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class PlaylistBE : BusinessEntity<Playlist, int>
    {
        #region Constructors
        public PlaylistBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion
    }
}
