using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Games;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ProducerViewModel> Producer()
        {
            var producer = new Producer("Everton", DateTime.Now, "www.evertonrps.net");
            var ret = _mapper.Map<ProducerViewModel>(producer);
            return new ActionResult<ProducerViewModel>(ret);
        }
        // GET api/values
        //[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
