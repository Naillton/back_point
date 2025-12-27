namespace back_point.Controller
{
    using back_point.Interfaces;
    using back_point.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/point")]
    public class PointController : Controller
    {
        private readonly IPoint  _pointService;

        public PointController(IPoint pointService)
        {
            _pointService = pointService;
        }

        [Authorize]
        [HttpPost("register/{userId}")]
        public async Task<IActionResult> RegisterPoint([FromRoute] Guid userId)
        {
            try
            {
                var result = await _pointService.CreatePoint(userId);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPointById([FromRoute] Guid id)
        {
            try
            {
                var result = await _pointService.GetPointById(id);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPointsByUserId([FromRoute] Guid userId)
        {
            try
            {
                var result = await _pointService.GetPointsByUserId(userId);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoint([FromRoute] Guid id)
        {
            try
            {
                var result = await _pointService.DeletePoint(id);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}