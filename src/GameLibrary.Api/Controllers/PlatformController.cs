using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
        public IEnumerable<PlatformViewModel> Get()
        {
            var result = new List<PlatformViewModel>();
            try
            {
                result = _mapper.Map<IEnumerable<PlatformViewModel>>(_platformRepository.GetAll()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
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