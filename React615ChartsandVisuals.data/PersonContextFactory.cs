using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace React615ChartsandVisuals.data
{
    public class PersonContextFactory : IDesignTimeDbContextFactory<PersonContext>
    {
        public PersonContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}React615ChartsandVisuals.web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            var constr = new PersonContext(config.GetConnectionString("ConStr"));
            return new PersonContext(config.GetConnectionString("ConStr"));
        }

    }
}
