﻿using CommandLine.Models;

namespace CommandLine.Data
{
    public interface ICommandAPIRepo
    {
        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommandById(int id);
        Task CreateCommand(Command command);
        Task UpdateCommand(Command command);
        void DeleteCommand(Command command);
        public Task<bool> SaveChangesAsync();

    }
}
