using Scheduling.DTOs;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        int GetOrCreateCityId(Address address);
        int GetOrCreateCountryId(City city);
        int GetOrCreateAddressId(Customer customer);
        int GetLastInsertId();
        void DeleteCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        void UpdateCustomer(Customer customer);


    }
}
