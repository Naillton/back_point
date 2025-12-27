namespace back_point.Controller
{
    using back_point.DTO;
    using back_point.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/enterprise")]
    public class EnterpriseController : Controller
    {
        private readonly IEnterprise  _enterpriseService;
        private readonly IToken _tokenService;

        public EnterpriseController(IEnterprise enterpriseService, IToken tokenService)
        {
            _enterpriseService = enterpriseService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterEnterprise([FromBody] CreateEnterpriseDTO createEnterpriseDTO)
        {
            try
            {
                var result = await _enterpriseService.CreateEnterprise(createEnterpriseDTO);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginEnterprise([FromBody] EnterpriseLoginDTO loginEnterpriseDTO)
        {
            try
            {
                var result = await _enterpriseService.AuthenticateEnterprise(loginEnterpriseDTO);
                if (result == null)
                {
                    return BadRequest(new { error = "Authentication failed" });
                }
                var token = _tokenService.GenerateToken(result.Id, result.Email, result.Cnpj);
                return Ok(new { token } );
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("{enterpriseId}")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO, [FromRoute] Guid enterpriseId)
        {
            try
            {
                var result = await _enterpriseService.CreateUser(enterpriseId, createUserDTO);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{enterpriseId}")]
        public async Task<IActionResult> GetUsersByEnterpriseId([FromRoute] Guid enterpriseId)
        {
            try
            {
                var result = await _enterpriseService.GetUsersByEnterpriseId(enterpriseId);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise([FromRoute] Guid id)
        {
            try
            {
                var result = await _enterpriseService.DeleteEnterprise(id);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("{enterpriseId}/update")]
        public async Task<IActionResult> UpdateEnterprise([FromBody] CreateEnterpriseDTO enterpriseDTO, [FromRoute] Guid enterpriseId)
        {
            try
            {
                var result = await _enterpriseService.UpdateEnterprise(enterpriseDTO, enterpriseId);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}