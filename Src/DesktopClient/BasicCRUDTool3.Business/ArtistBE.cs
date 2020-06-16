using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class ArtistBE : BusinessEntity<Artist, int>
    {
        public ArtistBE(ICRUDTestDBContextProvider cRUDTestDBContext) : base(cRUDTestDBContext)
        {
        }
    }
}
