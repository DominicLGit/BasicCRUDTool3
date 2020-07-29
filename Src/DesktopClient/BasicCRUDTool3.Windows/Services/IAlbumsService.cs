using System;
using System.Collections.Generic;
using System.Text;
using BasicCRUDTool3.Business;
using Refit;
using BasicCRUDTool3.Windows.DTO;
using System.Threading.Tasks;

namespace BasicCRUDTool3.Windows.Services
{
    public interface IAlbumsService
    {
        [Get("/Albums/get/{num}")]
        Task<IEnumerable<AlbumBEDTO>> GetNumberOfAlbums(int num);
    }
}
