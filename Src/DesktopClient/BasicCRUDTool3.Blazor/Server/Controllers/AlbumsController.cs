using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BasicCRUDTool3.Business;
using BasicCRUDTool3.Data.Models;
using BasicCRUDTool3.Blazor.Shared.DTO;
using AutoMapper;

namespace BasicCRUDTool3.Blazor.Server.Controllers
{
    //TODO: Add validation
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ICRUDTestDBContextProvider cRUDTestDBContextProvider;
        private readonly IMapper mapper;

        public AlbumsController(ICRUDTestDBContextProvider cRUDTestDBContextProvider, IMapper mapper)
        {
            this.cRUDTestDBContextProvider = cRUDTestDBContextProvider;
            this.mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AlbumBEDTO> GetAlbums()
        {
            IEnumerable<AlbumBE> AlbumBEs = new Business.Business(cRUDTestDBContextProvider).GetAlbumBEs();
            return mapper.Map<IEnumerable<AlbumBE>, IEnumerable<AlbumBEDTO>>(AlbumBEs);
        }

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
        public void Post([FromBody] AlbumBE albumBE)
        {
            if (ModelState.IsValid)
                albumBE.Save();
        }

        // PUT: api/<controller>/5
        [HttpGet("edit")]
        public void Put([FromBody] AlbumBE albumBE)
        {
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
