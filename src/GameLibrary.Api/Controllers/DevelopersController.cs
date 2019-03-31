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
        public IEnumerable<DeveloperViewModel> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<DeveloperViewModel>>(_developerRepository.GetAll());
                Response.StatusCode = (int)HttpStatusCode.OK;
                return list;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new List<DeveloperViewModel>();
            }

        }

        // GET: api/Developers
        //[HttpGet]
        //public Result<IEnumerable<DeveloperViewModel>> Get()
        //{
        //    var result = new Result<IEnumerable<DeveloperViewModel>>();

        //    try
        //    {
        //        result.Item = _mapper.Map<IEnumerable<DeveloperViewModel>>(_developerRepository.GetAll());
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        result.Message = ex.Message;
        //        result.StatusCode = HttpStatusCode.BadRequest;
        //        return result;
        //    }

        //}

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public DeveloperViewModel Get(int id)
        {

            return _mapper.Map<DeveloperViewModel>(_developerRepository.GetById(id));
            //return "value";
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
        public DeveloperViewModel Post([FromBody] DeveloperViewModel value)
        {
            //Just for test :)
            try
            {
                var dev = _mapper.Map<Developer>(value);
                if (dev.IsValid())
                {
                    var added = _developerRepository.Add(dev);
                    if (_uow.Commit().Result > 0)
                    {
                        var ret = _mapper.Map<DeveloperViewModel>(added);
                        //result.StatusCode = HttpStatusCode.Created;
                        return ret;
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
                return new DeveloperViewModel();
                //Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //value.Id = 0;
                //result.StatusCode = HttpStatusCode.BadRequest;
                //result.Item = value;
                //result.Message = ex.Message;
                //return result;
            }
        }
        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DeveloperViewModel value)
        {
            return Ok();
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
