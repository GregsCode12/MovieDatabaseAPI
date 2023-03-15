﻿using Microsoft.AspNetCore.Mvc;
using MovieDatabaseAPI.Data.Models;
using MovieDatabaseAPI.Services;

namespace MovieDatabaseAPI.Controllers
{
    
    [ApiController]
    public class ActorController : ControllerBase
    {
        public ActorService _actorService;

        private readonly ILogger<ActorController> _logger;

        public ActorController(ILogger<ActorController> logger, ActorService actorService)
        {
            _logger = logger;
            _actorService= actorService;
        }

        [HttpGet("get-all-actors")]
        [ResponseCache(VaryByHeader ="User-Agent", Duration =100)]
        public IActionResult Get()
        {
            var allActors = _actorService.FetchActors();
            if(allActors == null)
            {
                return NotFound();
            } else
            {
                return Ok(allActors);
            }
        }
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 40)]
        [HttpGet("get-all-actors/{page}/{pageSize}")]
        public IActionResult Get(int page, int pageSize)
        {
            var actors = _actorService.FetchActorsPagination(page, pageSize);
            if(actors == null)
            {
                return NotFound();

            } else
            {
                return Ok(actors);
            }
        }

        [HttpGet("get-single-actor/{actorId}")]
        public IActionResult Get(int actorId) {
            var result = _actorService.GetActorById(actorId);
            if (result == null)
            {
                return NotFound();
            } else
            {
                return Ok(result);
            }
        }
        [HttpPost("create-actor")]
        public IActionResult AddActor([FromBody] Actor actor)
        {
            _actorService.AddActor(actor);
            return Ok();
        }
        [HttpPut("edit-actor-by-id/{actorId}")]
        public IActionResult EditActor(int actorId, [FromBody] Actor actor)
        {
            var updatedActor = _actorService.EditActorById(actorId, actor);
            if (updatedActor != null)
            {
                return Ok(updatedActor);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("delete-actor-by-id/{actorId}")]
        public IActionResult DeleteActorById(int actorId)
        {
            var deletedActor = _actorService.DeleteActorById(actorId);
            if(deletedActor == null)
            {
                return NotFound();
            } else
            {
                return Ok(deletedActor);
            }
        }
    }
}
