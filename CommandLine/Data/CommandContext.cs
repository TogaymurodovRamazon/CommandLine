﻿using CommandLine.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLine.Data
{
    public class CommandContext :DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options) { }
        //Madelni elon qilish
        public DbSet<Command> Commands { get; set; }

    }
}
