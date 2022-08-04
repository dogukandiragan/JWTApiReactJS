using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Repositories;
using JWTBasedAuthApiReactJS.CORE.Services;
using JWTBasedAuthApiReactJS.CORE.UOW;

namespace JWTBasedAuthApiReactJS.SERVICE.Services
{
    public class CustomerService : Service<CustomerApp>, ICustomerService
    {

        public CustomerService(IGenericRepository<CustomerApp> repository, IUnitOfWork unitOfWork, ICustomerRepository _customerRepository) : base(repository, unitOfWork)
        {
      
        }


    }
}