using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers
{
    [Route("api/developers")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public DevelopersController(IDeveloperRepository developerRepository, IMapper mapper, IUnitOfWork uow)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
            _uow = uow;
        }
        // GET: api/Developers
        [HttpGet]
        public Result<IEnumerable<DeveloperViewModel>> Get()
        {
            var result = new Result<IEnumerable<DeveloperViewModel>>();

            try
            {
                result.Item = _mapper.Map<IEnumerable<DeveloperViewModel>>(_developerRepository.GetAll());
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

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Developers
        [HttpPost]
        public Result<DeveloperViewModel> Post([FromBody] DeveloperViewModel value)
        {
            var result = new Result<DeveloperViewModel>();
            //Just for test :)
            try
            {
                var dev = _mapper.Map<Developer>(value);
                var added = _developerRepository.Add(dev);

                if (_uow.Commit().Result > 0)
                {
                    result.Item = _mapper.Map<DeveloperViewModel>(added);
                    result.StatusCode = HttpStatusCode.Created;
                    return result;
                }
                else
                {
                    throw new Exception("Falha ao inserir");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                value.Id = 1;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Item = value;
                result.Message = ex.Message;
                return result;
            }
        }

        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
