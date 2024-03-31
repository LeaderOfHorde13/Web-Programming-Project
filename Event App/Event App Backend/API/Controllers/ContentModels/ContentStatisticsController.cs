using AutoMapper;
using Business.Abstract.ContentModels;
using Business.Concrete.ContentModels;
using DTO.ContentModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ContentModels;

namespace API.Controllers.ContentModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentStatisticsController : ControllerBase
    {
        private IContentStatisticsService _service;
        private IMapper _mapper;

        public ContentStatisticsController(IMapper mapper)
        {
            _service = new ContentStatisticsManager();
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ContentStatisticsDto>> GetAll()
        {
            return Ok(_service.GetAllContentStatistics().Select(contentStatistics => _mapper.Map<ContentStatisticsDto>(contentStatistics)));
        }

        [HttpGet("{id}")]
        public ActionResult<List<ContentStatisticsDto>> GetById(int id)
        {
            return Ok(_service.GetContentStatisticsById(id).Select(contentStatistics => _mapper.Map<ContentStatisticsDto>(contentStatistics)));
        }

        [HttpPost]
        public ActionResult<ContentStatisticsDto> Post([FromBody] ContentStatisticsDto newContentStatistics)
        {
            ContentStatistics contentStatistics = _mapper.Map<ContentStatistics>(newContentStatistics);
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                _service.CreateContentStatistics(contentStatistics);
                return StatusCode(201, newContentStatistics);
            }

        }

        [HttpPut]
        public ActionResult<ContentStatisticsDto> Put([FromBody] ContentStatisticsDto newContentStatistics)
        {
            ContentStatistics contentStatistics = _mapper.Map<ContentStatistics>(newContentStatistics);

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                _service.UpdateContentStatistics(contentStatistics);
                return StatusCode(200, newContentStatistics);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.DeleteContentStatistics(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("contents/{id}")]
        public ActionResult<List<CommentDto>> GetAllComments(int id)
        {
            return _service.GetAllComments(id);
        }

        [HttpGet("comments/{id}")]
        public ActionResult<List<ContentComment>> GetAllContentComments(int id)
        {
            return _service.GetAllContentComments(id);
        }

        [HttpPost("comments")]
        public ContentComment CreateComment([FromBody] ContentComment contentComment)
        {
            return _service.CreateComment(contentComment);
        }
    }
}
