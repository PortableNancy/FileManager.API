using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Infrastructure
{
    public class FileManagerDbContext : DbContext
    {
     
        public FileManagerDbContext(DbContextOptions<FileManagerDbContext> options) : base(options)
        {

        }
        public DbSet<FolderClass> FolderClasses { get; set; }
        public DbSet<FileClass> FileClasses { get; set; }

       
    }

}
