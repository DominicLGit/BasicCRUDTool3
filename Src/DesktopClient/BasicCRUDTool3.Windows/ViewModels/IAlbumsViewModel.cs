using BasicCRUDTool3.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public interface IAlbumsViewModel
    {
        public AlbumBE[] Albums { get; set; }
    }
}
