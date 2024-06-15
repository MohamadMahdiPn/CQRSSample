using MediatR;
using WebApplicationCQRS.Data;
using WebApplicationCQRS.Models;

namespace WebApplicationCQRS.Features.Players.GetPlayer
{
    public record GetAllPlayersQuery : IRequest<List<Player>>;

    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, List<Player>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllPlayersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<List<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
           var players = _context.Players.ToList();

            return players;
        }
    }

}
