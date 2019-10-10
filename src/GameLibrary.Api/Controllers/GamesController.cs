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
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IPlatformRepository _platformRepository;
        private readonly IGamePlatformRepository _gamePlatformRepository;

        public GamesController(IGameRepository gameRepository, IPlatformRepository platformRepository, IGamePlatformRepository gamePlatformRepository, IMapper mapper, IUnitOfWork uow)
        {
            _gameRepository = gameRepository;
            _platformRepository = platformRepository;
            _gamePlatformRepository = gamePlatformRepository;
            _mapper = mapper;
            _uow = uow;
        }
        // GET: api/Games
        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<GameViewModel>();

            try
            {
                var resultado = _gameRepository.GetAll();
                var rx = resultado.Select(c => new GameViewModel { Id = c.Id, Description = c.Description, DeveloperId = c.DeveloperId, Title = c.Title });
                result = rx.ToList();

                foreach (var item in result)
                {
                    var plataformas = _platformRepository.GetAll(item.Id);
                    item.Platform = new List<PlatformViewModel>(_mapper.Map<List<PlatformViewModel>>(plataformas));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {                
                return BadRequest(ex.Message);
            }
        }


        // GET: api/Games/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var gameEntity = _gameRepository.ObterGameCompletoPorID(id);
                return Ok(gameEntity);
            }
                catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Games
        [HttpPost]
        public IActionResult Post([FromBody] GameViewModel value)
        {
            var result = new GameViewModel();
            try
            {
                var dev = _mapper.Map<Game>(value);
                var added = _gameRepository.Add(dev);

                if (_uow.Commit().Result > 0)
                {
                    result = _mapper.Map<GameViewModel>(added);
                    //result.StatusCode = HttpStatusCode.Created;
                    return Ok(result);
                }
                else
                {
                    throw new Exception("Falha ao inserir");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(result);
            }
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  GameViewModel value)
        {
            var result = new GameViewModel();
            try
            {
                foreach (var item in value.GamePlatform)
                {
                    item.GameId = id;
                }
                _gamePlatformRepository.DeleteByGameID(id);
                var dev = _mapper.Map<Game>(value);
                _gamePlatformRepository.AddList(dev.GamePlatform);                
                _gameRepository.Update(dev);
                if (_uow.Commit().Result > 0)
                {
                    result = _mapper.Map<GameViewModel>(dev);                    
                    return Ok(result);
                }
                else
                {
                    throw new Exception("Falha ao inserir");
                }
            }
            catch (Exception ex)
            {
                value.Id = 0;
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
