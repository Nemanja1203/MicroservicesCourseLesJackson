using System;
using System.Collections.Generic;
using System.Linq;
using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _dbContext;

        public CommandRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformId;
            _dbContext.Commands.Add(command);
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _dbContext.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _dbContext.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId)
                .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _dbContext.Commands
                .Where(c => c.PlatformId == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public bool PlatformsExists(int platformId)
        {
            return _dbContext.Platforms.Any(p => p.Id == platformId);
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return _dbContext.Platforms.Any(p => p.ExternalId == externalPlatformId);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() >= 0;
        }
    }
}
