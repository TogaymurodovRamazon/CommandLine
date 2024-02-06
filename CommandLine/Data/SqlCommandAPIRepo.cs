using CommandLine.Dtos;
using CommandLine.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLine.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;
        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context; 
        }
        public async Task CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            await _context.Commands.AddAsync(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Remove(command);
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
           var res= await _context.Commands.ToListAsync();
            return res;
        }

        public async Task<Command> GetCommandById(int id)
        {
           var ges= await _context.Commands.FirstOrDefaultAsync(x => x.Id == id);
            return ges;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync()>=0;
            
        }

        public Task UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
