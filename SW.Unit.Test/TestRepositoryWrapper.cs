using Microsoft.EntityFrameworkCore;
using SW.Business;
using SW.Data;

namespace SW.Unit.Test
{
    public class TestRepositoryWrapper
    {
        public RepositoryWrapper RepoWraper;

        public TestRepositoryWrapper()
        {
            DbContextOptions<ApplicationDbContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase();
            options = builder.Options;
            ApplicationDbContext context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            RepoWraper = new RepositoryWrapper(context);
        }
    }
}
