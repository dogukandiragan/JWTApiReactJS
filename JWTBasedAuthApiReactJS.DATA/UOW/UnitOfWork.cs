using JWTBasedAuthApiReactJS.CORE.UOW;

namespace JWTBasedAuthApiReactJS.DATA.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
