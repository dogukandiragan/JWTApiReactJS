
using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Repositories;

namespace JWTBasedAuthApiReactJS.DATA.Repositories
{

    public class TransactionRepository : GenericRepository<TransactionApp>, ITransactionRepository
    {
        
        public TransactionRepository(AppDbContext context) : base(context)
        {
     
        }

    }
}
