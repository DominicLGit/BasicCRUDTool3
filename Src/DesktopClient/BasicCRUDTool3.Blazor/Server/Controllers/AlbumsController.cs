using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BasicCRUDTool3.Business;
using BasicCRUDTool3.Data.Models;
using BasicCRUDTool3.Windows.DTO;
using AutoMapper;
using BasicCRUDTool3.Blazor.Server.Services;
using BasicCRUDTool3.Blazor.Server.Extensions;

namespace BasicCRUDTool3.Blazor.Server.Controllers
{
    //TODO: Add validation
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ICRUDTestDBContextProvider cRUDTestDBContextProvider;
        private readonly IMapper mapper;
        private readonly IAlbumsService albumsService;

        public AlbumsController(ICRUDTestDBContextProvider cRUDTestDBContextProvider, 
            IMapper mapper, 
            IAlbumsService albumsService)
        {
            this.cRUDTestDBContextProvider = cRUDTestDBContextProvider;
            this.mapper = mapper;
            this.albumsService = albumsService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AlbumBEDTO> GetAlbums()
        {
            try
            {
                IEnumerable<AlbumBE> albumBEs = new Business.Business(cRUDTestDBContextProvider).GetAlbumBEs();
                return mapper.Map<IEnumerable<AlbumBE>, IEnumerable<AlbumBEDTO>>(albumBEs);
            }
            catch
            {
                return new List<AlbumBEDTO>();
            }
            
        }

        // GET: api/<controller>/get/5
        [HttpGet("get/{num}")]
        public async Task<IActionResult> GetNumberOfAlbums(int num) => await albumsService.TryGetNumberOfAlbums(num).ToActionResult();

        // GET: api/<controller>/5
        [HttpGet("detail/ {id}")]
        public AlbumBEDTO GetAlbum(int id)
        {
            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(id);
            AlbumBEDTO albumBEDTO = mapper.Map<AlbumBE, AlbumBEDTO>(albumBE);
            return albumBEDTO;
        }

        // POST: api/<controller>
        [HttpGet("create")]
        public void Post([FromBody] AlbumBEDTO albumBEDTO)
        {
            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.New();
            mapper.Map<AlbumBEDTO, AlbumBE>(albumBEDTO, albumBE);
            if (ModelState.IsValid)
                albumBE.Save();
        }

        // PUT: api/<controller>/5
        [HttpGet("edit")]
        public void Put([FromBody] AlbumBEDTO albumBEDTO)
        {
            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(albumBEDTO.Id);
            mapper.Map<AlbumBEDTO, AlbumBE>(albumBEDTO, albumBE);
            if (ModelState.IsValid)
                albumBE.Save();
        }

        // DELETE: api/<controller>/5
        [HttpGet("delete/ {id}")]
        public void Delete(int id)
        {
            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(id);
            albumBE.Delete();
        }
    }
}
