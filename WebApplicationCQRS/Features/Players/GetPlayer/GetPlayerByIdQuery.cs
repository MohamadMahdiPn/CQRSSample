using MediatR;
using WebApplicationCQRS.Data;
using WebApplicationCQRS.Models;

namespace WebApplicationCQRS.Features.Players.GetPlayer
{
    public record GetPlayerByIdQuery(int id):IRequest<Player>;


    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player?>
    {
        private readonly ApplicationDbContext _context;
        public GetPlayerByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.id);
            return player;
        }
    }
}
