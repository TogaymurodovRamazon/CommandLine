using AutoMapper;
using CommandLine.Data;
using CommandLine.Dtos;
using CommandLine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandLine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandAPIRepo repo;
        private readonly IMapper _mapper;
        public CommandController(ICommandAPIRepo aPIRepo, IMapper mapper)
        {
            repo = aPIRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommand(CommandCreatedDto commandCreatedDto)
        {
            var res = _mapper.Map<Command>(commandCreatedDto);
            await repo.CreateCommand(res);
            await repo.SaveChangesAsync();

            var commandRead = _mapper.Map<CommandReadDto>(res);
            return Created("", res);
        }
        [HttpGet]
        public async Task<IActionResult> GetCommands()
        {
            var commands = await repo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommandById(int id)
        {
            var comman=await repo.GetCommandById(id);
            if(comman == null)
                return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(comman));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommand(int id)
        {
            var res = await repo.GetCommandById(id);
            if(res == null)
                return NotFound();
             repo.DeleteCommand(res);
            await repo.SaveChangesAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommand(int id, CommandUpdateDto updateDto)
        {
            var res=await repo.GetCommandById(id);
            if (res == null)
                return NotFound();
            _mapper.Map(updateDto, res);
            await repo.UpdateCommand(res);
            await repo.SaveChangesAsync();
            return NoContent();
        }
       
    }
}
