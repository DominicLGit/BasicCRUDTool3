using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BasicCRUDTool3.Business;
using BasicCRUDTool3.Data.Models;

namespace BasicCRUDTool3.Blazor.Server.Controllers
{
    //TODO: Add validation
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ICRUDTestDBContextProvider cRUDTestDBContextProvider;

        public AlbumsController(ICRUDTestDBContextProvider cRUDTestDBContextProvider)
        {
            this.cRUDTestDBContextProvider = cRUDTestDBContextProvider;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AlbumBE> GetAlbums()
        {
            return new Business.Business(cRUDTestDBContextProvider).GetAlbumBEs();
        }

        // GET: api/<controller>/5
        [HttpGet("detail/ {id}")]
        public AlbumBE GetAlbum(int id)
        {
            AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);
            albumBE.Load(id);
            return albumBE;
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
