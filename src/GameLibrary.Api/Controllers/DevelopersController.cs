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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<DeveloperViewModel>>(_developerRepository.GetAll());                
                return Ok(list);
            }
            catch (Exception ex)
            {                
                return BadRequest(new List<DeveloperViewModel>());
            }

        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {

            return Ok(_mapper.Map<DeveloperViewModel>(_developerRepository.GetById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Developers
        //[HttpPost]
        //public Result<DeveloperViewModel> Post([FromBody] DeveloperViewModel value)
        //{
        //    var result = new Result<DeveloperViewModel>();
        //    //Just for test :)
        //    try
        //    {
        //        var dev = _mapper.Map<Developer>(value);
        //        if (dev.IsValid())
        //        {
        //            var added = _developerRepository.Add(dev);
        //            if (_uow.Commit().Result > 0)
        //            {
        //                result.Item = _mapper.Map<DeveloperViewModel>(added);
        //                result.StatusCode = HttpStatusCode.Created;
        //                return result;
        //            }
        //            else
        //            {
        //                throw new Exception("Falha ao inserir");
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Falha ao inserir");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        value.Id = 0;
        //        result.StatusCode = HttpStatusCode.BadRequest;
        //        result.Item = value;
        //        result.Message = ex.Message;
        //        return result;
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] DeveloperViewModel value)
        {            
            try
            {
                var dev = _mapper.Map<Developer>(value);
                if (dev.IsValid())
                {
                    var added = _developerRepository.Add(dev);
                    if (_uow.Commit().Result > 0)
                    {
                        var ret = _mapper.Map<DeveloperViewModel>(added);                        
                        return Ok(ret);
                    }
                    else
                    {
                        throw new Exception("Falha ao inserir");
                    }
                }
                else
                {
                    throw new Exception("Falha ao inserir");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new DeveloperViewModel());
            }
        }
        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DeveloperViewModel value)
        {
            try
            {
                var dev = _mapper.Map<Developer>(value);
                _developerRepository.Update(dev);
                if (_uow.Commit().Result > 0)
                {
                    var ret = _mapper.Map<DeveloperViewModel>(dev);
                    return Ok(ret);
                }
                else
                {
                    throw new Exception("Falha ao inserir");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               _developerRepository.Delete(id);
                if (_uow.Commit().Result > 0)
                {                    
                    return Ok();
                }
                else
                {
                    return BadRequest("Falha ao inserir");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
