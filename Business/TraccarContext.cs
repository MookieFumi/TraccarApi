using Microsoft.EntityFrameworkCore;
using TraccarApi.Business.Entities;
using System.Configuration;

namespace TraccarApi.Business
{
    public class TraccarContext : DbContext
    {
        public TraccarContext(DbContextOptions<TraccarContext> options)
        : base(options)
    { }

        public DbSet<Event> Events { get; set; }
    }
}
