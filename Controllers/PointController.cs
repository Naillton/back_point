namespace back_point.Controller
{
    using back_point.Interfaces;
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
        [HttpPost("register/{code}")]
        public async Task<IActionResult> RegisterPoint([FromRoute] string code)
        {
            try
            {
                var result = await _pointService.CreatePoint(code);
                return Ok(new
                {
                    success = true,
                    message = "Ponto registrado com sucesso",
                    value = result
                });
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
                return Ok(new
                {
                    success = true,
                    value = result
                });
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("user/{code}")]
        public async Task<IActionResult> GetPointsByUserId([FromRoute] string code)
        {
            try
            {
                var result = await _pointService.GetPointsByUserCode(code);
                return Ok(new
                {
                    success = true,
                    value = result
                });
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
                return Ok(new
                {
                    success = true,
                    message = "Ponto deletado com sucesso",
                    value = result
                });
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}