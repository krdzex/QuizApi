namespace Repository
{
    internal sealed class UnitOfWork
    {
        private readonly RepositoryContext _context;

        public UnitOfWork(RepositoryContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
