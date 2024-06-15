using MediatR;
using WebApplicationCQRS.Data;
using WebApplicationCQRS.Models;

namespace WebApplicationCQRS.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand(string Name,int Level):IRequest<int>;


    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly ApplicationDbContext _context;
        public CreatePlayerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player()
            {
                Level = request.Level,
                Name = request.Name,
            };
            var insert = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();  

            return insert.Entity.Id;
        }
    }
}
