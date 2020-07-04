using BasicCRUDTool3.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Windows.VIewModels
{
    public interface IAlbumViewModel
    {
        public AlbumBE[] Albums { get; set; }
    }
}
