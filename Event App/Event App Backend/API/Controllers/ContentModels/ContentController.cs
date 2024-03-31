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
    public class ContentController : ControllerBase
    {
        public IContentService _service;
        private IMapper _mapper;

        public ContentController(IMapper mapper)
        {
            _service = new ContentManager();
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ContentDto>> GetAll()
        {
            return Ok(_service.GetAllContents().Select(content => _mapper.Map<ContentDto>(content)));
        }

        [HttpGet("{id}")]
        public ActionResult<List<ContentDto>> GetById(int id)
        {
            return Ok(_service.GetContentById(id).Select(content => _mapper.Map<ContentDto>(content)));
        }

        [HttpPost]
        public ActionResult<ContentDto> Post([FromBody] ContentDto newContent)
        {
            Content content = _mapper.Map<Content>(newContent);

            _service.CreateContent(content);
            return StatusCode(201, newContent);

        }

        [HttpPut]
        public ActionResult<ContentDto> Put([FromBody] ContentDto newContent)
        {
            Content content = _mapper.Map<Content>(newContent);

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                _service.UpdateContent(content);
                return StatusCode(200, newContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.DeleteContent(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("increase-like/{id}")]
        public ActionResult IncreaseLikeUpdate(int id)
        {
            _service.IncreaseLike(id);
            return StatusCode(200);
        }

        [HttpPut("discrease-like/{id}")]
        public ActionResult DiscreaseLikeUpdate(int id)
        {
            _service.DiscreaseLike(id);
            return StatusCode(200);
        }

        [HttpPut("increase-comment/{id}")]
        public ActionResult IncreaseCommentUpdate(int id)
        {
            _service.IncreaseComment(id);
            return StatusCode(200);
        }

        [HttpPut("discrease-comment/{id}")]
        public ActionResult DiscreaseCommentUpdate(int id)
        {
            _service.DiscreaseComment(id);
            return StatusCode(200);
        }

        [HttpPut("increase-share/{id}")]
        public ActionResult IncreaseShareUpdate(int id)
        {
            _service.IncreaseShare(id);
            return StatusCode(200);
        }

        [HttpPut("discrease-share/{id}")]
        public ActionResult DiscreaseShareUpdate(int id)
        {
            _service.DiscreaseShare(id);
            return StatusCode(200);
        }

        [HttpPut("increase-join/{id}")]
        public ActionResult IncreaseJoiningUpdate(int id)
        {
            _service.IncreaseJoining(id);
            return StatusCode(200);
        }

        [HttpPut("discrease-join/{id}")]
        public ActionResult DiscreaseJoiningUpdate(int id)
        {
            _service.DiscreaseJoining(id);
            return StatusCode(200);
        }
    }
}
