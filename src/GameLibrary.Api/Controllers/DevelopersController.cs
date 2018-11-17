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

        public DevelopersController(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }
        // GET: api/Developers
        [HttpGet]
        public  IEnumerable<DeveloperViewModel> Get()
        {
           // var result = new Result<IEnumerable<DeveloperViewModel>>();            
            
            var lista = new List<DeveloperViewModel>
            {
                new DeveloperViewModel { Name = "Nintendo", Founded = new DateTime(1889, 09, 23), WebSite = "http://nintendo.com" },
                new DeveloperViewModel { Name = "Sega", Founded = new DateTime(1989, 08, 5), WebSite = "http://sega.com" }
            };
            return lista;
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
                var added =_developerRepository.Add(dev);               
                result.Item = _mapper.Map<DeveloperViewModel>(added);

                result.StatusCode = HttpStatusCode.OK;
                return result;
            }
            catch (Exception ex)
            {
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
