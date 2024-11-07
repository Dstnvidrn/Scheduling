using Scheduling.Interfaces;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.Repositories
{
    public class CustomerRepository
    {
        private IDbConnection _connection;
        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public Customer GetCustomerById(int customerId)
        {
            return null;
        }
    }
}
