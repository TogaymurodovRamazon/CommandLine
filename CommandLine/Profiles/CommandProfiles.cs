using AutoMapper;
using CommandLine.Dtos;
using CommandLine.Models;

namespace CommandLine.Profiles
{
    public class CommandProfiles : Profile
    {
        public CommandProfiles()
        {
            CreateMap<CommandCreatedDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
