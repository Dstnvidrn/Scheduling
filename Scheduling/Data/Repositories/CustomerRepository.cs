using Scheduling.DTOs;
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
        private IDatabase _database;
        public CustomerRepository(IDatabase database)
        {
            _database = database;
        }
        public Customer GetCustomerById(int customerId)
        {
            return null;
        }

        public void AddCustomer(CustomerDTO customer)
        {
            string query = @"
            INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@Name, @AddressId, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            IDataParameter[] parameters = new IDataParameter[]
            {
                 _database.CreateParameter("@Name", customer.Name),
                _database.CreateParameter("@AddressId", customer.AddressId),
                _database.CreateParameter("@Active", customer.Active ? 1 : 0), // tinyint as boolean
                _database.CreateParameter("@CreateDate", customer.CreateDate),
                _database.CreateParameter("@CreatedBy", customer.CreatedBy),
                _database.CreateParameter("@LastUpdate", customer.LastUpdate),
                _database.CreateParameter("@LastUpdatedBy", customer.LastUpdatedBy)
            };
            _database.ExecuteNonQuery(query, parameters);
        }
    }
}
