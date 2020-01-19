using System.Threading.Tasks;
using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Token;
using GameLibrary.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public TokenController(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccessCredentialsViewModel model)
        {
            var credentials = _mapper.Map<AccessTokenCredentials>(model);

            if (await _tokenService.ValidateCredentials(credentials))
            {
                return Ok(_tokenService.GenerateToken(credentials));                
            }
            else
            {
                return Unauthorized(new
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                });
            }            
        }
    }
}