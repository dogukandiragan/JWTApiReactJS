
using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Repositories;

namespace JWTBasedAuthApiReactJS.DATA.Repositories
{

    public class CustomerRepository : GenericRepository<CustomerApp>, ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context =  context;
        }


 
 
    }
}
