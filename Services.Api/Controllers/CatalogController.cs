using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Catalog.Api.Infrastructure;
using Services.Catalog.Api.Model;
using Services.Catalog.Api.ViewModel;

namespace Services.Catalog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class CatalogController : Controller
    {
        private readonly MvcMusicStoreContext _musicStoreContext;
        public CatalogController(MvcMusicStoreContext context)
        {
            this._musicStoreContext = context;
        }

        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Infrastructure.Album>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)

        {
            var totalItems = await _musicStoreContext.Album
                .LongCountAsync();

            var itemsOnPage = await _musicStoreContext.Album
                .OrderBy(c => c.Artist)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            itemsOnPage = ChangeUriPlaceholder(itemsOnPage);

            var model = new PaginatedItemsViewModel<Infrastructure.Album>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<Infrastructure.Album>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> genreTypes()
        {
            var items = await _musicStoreContext.Genre
                .ToListAsync();

            return Ok(items);
        }
        // GET api/v1/[controller]/CatalogBrands
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<Infrastructure.Album>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> artistBrands()
        {
            var items = await _musicStoreContext.Artist
                .ToListAsync();

            return Ok(items);
        }
        private List<Infrastructure.Album> ChangeUriPlaceholder(List<Infrastructure.Album> items)
        {
           // var baseUri = _settings.PicBaseUrl;

            items.ForEach(catalogItem =>
            {
                catalogItem.AlbumArtUrl = "~/images/placeholder.png";//"http://lorempixel.com/400/200/";// ;
            });

            return items;
        }
    }
}