using CEUDWebAPI.Domain.Repositories;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;

        public UnitOfWork(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }
    }
}
