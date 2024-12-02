using Scheduling.Models;
using System.Collections.Generic;

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
        List<KeyValuePair<int, string>> GetCustomerIdAndName();
        Customer GetCustomerById(int customerId);

    }
}
