using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Context
{
    public class ProjectContextDbFactory : IDesignTimeDbContextFactory<ProjectContext>
    {
        public ProjectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B77ITTF;Database=HizliGeliyoDB;Trusted_Connection=true");
            
            return new ProjectContext(optionsBuilder.Options);
        }
    }
}
