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
    [Route("api/platformTypes")]
    [ApiController]
    public class PlatformTypeController : ControllerBase
    {
        private readonly IPlatformTypeRepository _platformTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PlatformTypeController(IPlatformTypeRepository platformTypeRepository, IMapper mapper, IUnitOfWork uow)
        {
            _platformTypeRepository = platformTypeRepository;
            _mapper = mapper;
            _uow = uow;
        }

        // GET: api/PlatformType
        [HttpGet]
        public IEnumerable<PlatformTypeViewModel> Get()
        {
            var result = new List<PlatformTypeViewModel>();

            try
            {
                result = _mapper.Map<IEnumerable<PlatformTypeViewModel>>(_platformTypeRepository.GetAll()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return result;
            }
        }

        // GET: api/PlatformType/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/PlatformType
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/PlatformType/5
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
