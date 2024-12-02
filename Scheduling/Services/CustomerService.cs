using Scheduling.Data.Repositories;
using Scheduling.DTOs;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduling.Services
{
    public class CustomerService
    {
        private IDatabaseHelper _databaseHelper;
        private ICustomerRepository _customerRepository;
        private CustomerMapper _customerMapper;
        public CustomerService(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
            _customerRepository = new CustomerRepository(_databaseHelper);
            _customerMapper = new CustomerMapper();
        }
        public List<CustomerDTO> GetAllCustomers()
        {
            return _customerMapper.MapToCustomerDTO(_customerRepository.GetAllCustomers());
        }
        public List<KeyValuePair<int, string>> GetCustomerIDAndName()
        {
            return _customerRepository.GetCustomerIdAndName();
        }

        public bool CreateCustomer(CustomerDTO customerDTO)
        {
            try
            {
                _customerRepository.AddCustomer(_customerMapper.MapToModel(customerDTO, GlobalUserInfo.CurrentLoggedInUser));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool DeleteCustomer(CustomerDTO customerDTO)
        {
            try
            {
                _customerRepository.DeleteCustomer(_customerMapper.MapToModel(customerDTO, GlobalUserInfo.CurrentLoggedInUser));
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void UpdateCustomer(CustomerDTO customerDTO)
        {
            _customerRepository.UpdateCustomer(_customerMapper.MapToModel(customerDTO, GlobalUserInfo.CurrentLoggedInUser));
        }
    }
}
