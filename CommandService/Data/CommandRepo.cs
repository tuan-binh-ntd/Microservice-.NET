using CommandService.Models;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(
            AppDbContext context
            )
        {
            _context = context;
        }

        public void CreateCommand(int platformId, Command input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            input.PlatformId = platformId;
            _context.Commands.Add(input);
        }

        public void CreatePlatform(Platform input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            _context.Platforms.Add(input);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault()!;
        }

        public IEnumerable<Command> GetAllCommandsForPlatform(int platformId)
        {
            return _context.Commands.Where(c => c.PlatformId == platformId).OrderBy(c => c.Platform!.Name).ToList();
        }

        public bool PlatformExits(int platformId)
        {
            return _context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ExternalPlatformExits(int externalPlatformId)
        {
            return _context.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }
    }
}
