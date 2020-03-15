using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Api.Controllers
{
    //[Authorize]
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
                var lista = _mapper.Map<List<GameViewModel>>(resultado.ToList());
                return Ok(lista);
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
                var gameEntity = _gameRepository.FindAll(c=> c.Id == id, "Developer,GamePlatform").FirstOrDefault();                
                return Ok(_mapper.Map<GameViewModel>(gameEntity));
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