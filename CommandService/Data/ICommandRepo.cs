using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        //Platforms
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform input);
        bool PlatformExits(int platformId);
        bool ExternalPlatformExits(int externalPlatformId);

        //Commands
        IEnumerable<Command> GetAllCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command input);
    }
}
