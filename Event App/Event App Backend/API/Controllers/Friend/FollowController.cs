using Business.Abstract.Friend;
using Business.Concrete.Friend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Friend;

namespace API.Controllers.Friend
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private IFollowingService _service;

        public FollowController()
        {
            _service = new FollowingManager();
        }

        [HttpPost]
        public ActionResult<Follow> CreateFollowing([FromBody] Follow follow)
        {
            return StatusCode(201, _service.CreateFollowing(follow));
        }

        [HttpGet]
        public ActionResult<List<Follow>> GetAllFollows()
        {
            return Ok(_service.GetAllFollows());
        }

        [HttpGet("requester/{requesterId}/responser/{responserId}")]
        public ActionResult<List<Follow>> GetFollowingById(int requesterId, int responserId)
        {
            return Ok(_service.GetFollowingById(requesterId, responserId));
        }

        [HttpPut]
        public ActionResult<Follow> UpdateFollowing([FromBody] Follow follow)
        {
            return Ok(_service.UpdateFollowing(follow));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFollowing(int id)
        {
            try
            {
                _service.DeleteFollowing(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<List<Follow>> GetAllFollowsForNotification(int id)
        {
            return Ok(_service.GetAllFollowsForNotification(id));
        }
    }
}
