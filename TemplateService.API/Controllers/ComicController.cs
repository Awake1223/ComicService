using Microsoft.AspNetCore.Mvc;
using TemplateService.API.Contracts;
using TemplateService.Application.Services;
using TemplateService.Domain.Models;

namespace TemplateService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComicController : ControllerBase
    {
        private readonly IComicService _comicService;

        public ComicController(IComicService comicService )
        {
            _comicService = comicService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ComicResponse>>> GetComic()
        {
            var comics = await _comicService.GetAllComic();

            var response = comics.Select(c => new ComicResponse(c.Id, c.Title, c.Description, c.Publisher, c.Authors));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateComic([FromBody] ComicRequest request)
        {
            (ComicModel? comicModel, string error) = ComicModel.Create(
                Guid.NewGuid(),
                request.title,
                request.description,
                request.publisher,
                request.authors
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _comicService.CreateComic(comicModel);

            return Ok(comicModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateComic(Guid id, [FromBody] ComicRequest request)
        {
            var comicId = await _comicService.UpdateComic(id, request.title, request.description, request.publisher, request.authors);
            
            return Ok(comicId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return (await _comicService.DeleteComic(id));
        }
    }
}
