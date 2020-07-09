using BasicCRUDTool3.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public class AlbumsViewModel : ViewModel
    {
        #region Public Properties
        public AlbumBE[] Albums { get; set; }
        #endregion

        public AlbumsViewModel()
        {
            //Albums = new Business.Business().GetAlbumBEs();
        }
    }
}
