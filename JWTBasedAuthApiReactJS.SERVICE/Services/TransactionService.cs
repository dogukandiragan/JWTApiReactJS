
using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Repositories;
using JWTBasedAuthApiReactJS.CORE.Services;
using JWTBasedAuthApiReactJS.CORE.UOW;

namespace JWTBasedAuthApiReactJS.SERVICE.Services
{
    public class TransactionService : Service<TransactionApp>, ITransactionService
    {

        public TransactionService(IGenericRepository<TransactionApp> repository, IUnitOfWork unitOfWork, ITransactionRepository _transactionRepository) : base(repository, unitOfWork)
        {

        }




    }
}