using BasicCRUDTool3.Windows.Services;
using static LanguageExt.Prelude;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCRUDTool3.Windows.DTO;
using AutoMapper;
using BasicCRUDTool3.Data.Models;
using BasicCRUDTool3.Business;
using LanguageExt;

namespace BasicCRUDTool3.Blazor.Server.Services
{
    public interface IAlbumsService
    {
        TryAsync<IEnumerable<AlbumBEDTO>> TryGetNumberOfAlbums(int num);
    }
    public class AlbumsService : IAlbumsService
    {
        private readonly IMapper mapper;
        private readonly ICRUDTestDBContextProvider cRUDTestDBContextProvider;

        public AlbumsService(IMapper mapper, ICRUDTestDBContextProvider cRUDTestDBContextProvider)
        {
            this.mapper = mapper;
            this.cRUDTestDBContextProvider = cRUDTestDBContextProvider;
        }

        public TryAsync<IEnumerable<AlbumBEDTO>> TryGetNumberOfAlbums(int num)
        {
            return TryAsync(GetNumberOfAlbums(num));
        }

        public Task<IEnumerable<AlbumBEDTO>> GetNumberOfAlbums(int num)
        {

            return Task.Run(() => AsDtos(new Business.Business(cRUDTestDBContextProvider).GetAlbumBEs()).Take(num));
        }

        private IEnumerable<AlbumBEDTO> AsDtos(IEnumerable<AlbumBE> albumBEs)
        {
            return !albumBEs.Any() ? new List<AlbumBEDTO>() : mapper.Map<IEnumerable<AlbumBE>, IEnumerable<AlbumBEDTO>>(albumBEs);
        }

        private AlbumBEDTO AsDtos(AlbumBE albumBE)
        {
            return mapper.Map<AlbumBE, AlbumBEDTO>(albumBE);
        }
    }
}
