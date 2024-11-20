﻿using Scheduling.DTOs;
using Scheduling.Models;
using System;
using System.Collections.Generic;

namespace Scheduling.Services.Mappers
{
    public class CustomerMapper
    {
        public Customer MapToModel(CustomerDTO customerDTO, UserDTO loggedInUser)
        {
            UserMapper userMapper = new UserMapper();
            User user = userMapper.MapToModel(loggedInUser);
            Customer newCustomer = new Customer
            {
                CustomerId = customerDTO.Id,
                CustomerName = customerDTO.Name,
                CreateDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                IsActive = customerDTO.Active,
                UpdatedBy = user,
                CreatedBy = user,
                
                Address = new Address 
                { 
                    Street1 = customerDTO.Street1,
                    Street2 = customerDTO.Street2,
                    PhoneNumber = customerDTO.PhoneNumber,
                    PostalCode = customerDTO.Postal,
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = user,
                    CreatedBy= user,
                    
                    City = new City 
                    {
                        CityName = customerDTO.CityName,
                        LastUpdate = DateTime.Now,
                        LastUpdateBy = user,
                        CreatedBy = user,
                        Country = new Country
                        {
                            CountryName = customerDTO.CountryName,
                            CreatedBy = user
                        }
                    },
                },
            };
            return newCustomer;
        }
        public List<CustomerDTO> MapToCustomerDTO(List<Customer> customers)
        {
            var customerDTOs = new List<CustomerDTO>();

            foreach (var customer in customers)
            {
                var customerDTO = new CustomerDTO
                {
                    Id = customer.CustomerId,
                    Name = customer.CustomerName,
                    Street1 = customer.Address?.Street1,
                    Street2 = customer.Address?.Street2,
                    CityName = customer.Address?.City?.CityName,
                    CountryName = customer.Address?.City?.Country?.CountryName,
                    Active = customer.IsActive
                };

                customerDTOs.Add(customerDTO);
            }

            return customerDTOs;
        }
    }
}
