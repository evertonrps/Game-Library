using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers
{
    [Route("api/platform")]
    [ApiController]
    public class PlatformController : ControllerBase
    {

        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;


        public PlatformController(IPlatformRepository platformRepository, IMapper mapper, IUnitOfWork uow)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            _uow = uow;
        }
        // GET: api/Platform
        [HttpGet]
        public Result<IEnumerable<PlatformViewModel>> Get()
        {
            var result = new Result<IEnumerable<PlatformViewModel>>();
            try
            {
                result.Item = _mapper.Map<IEnumerable<PlatformViewModel>>(_platformRepository.GetAll());
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                return result;
            }
        }

        // GET: api/Platform/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/Platform
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Platform/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
