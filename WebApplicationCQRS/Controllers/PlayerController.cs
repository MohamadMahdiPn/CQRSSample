using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCQRS.Features.Players.CreatePlayer;
using WebApplicationCQRS.Features.Players.GetPlayer;
using WebApplicationCQRS.Models;

namespace WebApplicationCQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly ISender _sender;

        public PlayerController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerCommand player)
        {
            var playerId = await _sender.Send(player);
            return Ok(playerId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerId(int id)
        {
            var player = await _sender.Send(new GetPlayerByIdQuery(id));
            if (player is null)
                return NotFound();
            return Ok(player);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _sender.Send(new GetAllPlayersQuery());
            
            return Ok(players);
        }
    }
}
