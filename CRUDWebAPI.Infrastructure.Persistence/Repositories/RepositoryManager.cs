using CEUDWebAPI.Domain.Repositories;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(AppDbContext ctx)
        {
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(ctx));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(ctx));
        }

        public IProductRepository ProductRepository => _lazyProductRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
