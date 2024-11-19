using Scheduling.DTOs;
using Scheduling.Models;
using System;

namespace Scheduling.Services.Mappers
{
    public class CustomerMapper
    {
        public Customer MapToModel(CustomerDTO customerDTO, UserDTO loggedInUser)
        {
            UserMapper userMapper = new UserMapper();
            User user = userMapper.MapToModel(loggedInUser);
            Customer newCustomer =  new Customer
            {
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
    }
}
