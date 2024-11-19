using Scheduling.DTOs;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Models;
using Scheduling.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDatabaseHelper _databaseHelper;
        public CustomerRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public Customer GetCustomerById(int customerId)
        {
            return null;
        }
        

        public void AddCustomer(Customer customer)
        {
            
            int addressId = GetOrCreateAddressId(customer);
            string query = @"
            INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@Name, @AddressId,@Active, @createDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            IDataParameter[] parameters = new IDataParameter[]
            {
                _databaseHelper.CreateParameter("@Name", customer.CustomerName),
                _databaseHelper.CreateParameter("@AddressId", addressId),
                _databaseHelper.CreateParameter("@Active", customer.IsActive ? 1 : 0), // tinyint as boolean
                _databaseHelper.CreateParameter("@CreateDate", customer.CreateDate),
                _databaseHelper.CreateParameter("@CreatedBy", customer.CreatedBy.Username),
                _databaseHelper.CreateParameter("@LastUpdate", customer.LastUpdate),
                _databaseHelper.CreateParameter("@LastUpdatedBy", customer.UpdatedBy.Username)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
            
        }

        public int GetOrCreateCityId(Address address)
        {
            String query = @"
                SELECT cityId FROM city WHERE city= @cityName";
            var parameters = new[] {
                _databaseHelper.CreateParameter("@cityName", address.City.CityName)
            };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["cityId"]);
            }

            query = @"
                INSERT INTO city (city, createDate, createdBy, lastUpdate, lastUpdateBy, countryId)
                VALUES (@city, @createDate, @createdBy, @lastUpdate, @lastUpdateBy, @countryId)";
            parameters = new[] {
                _databaseHelper.CreateParameter("@city", address.City.CityName),
                _databaseHelper.CreateParameter("@createDate",address.CreateDate),
                _databaseHelper.CreateParameter("@createdBy", address.CreatedBy.Username),
                _databaseHelper.CreateParameter("@lastUpdate", address.LastUpdate),
                _databaseHelper.CreateParameter("@lastUpdateBy", address.LastUpdatedBy.Username),
                _databaseHelper.CreateParameter("@countryId", GetOrCreateCountryId(address.City))
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
            return GetLastInsertId();
        }
        

        public int GetOrCreateAddressId(Customer customer)
        {
            string query = @"
                SELECT addressId FROM address WHERE address = @address";
            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@address", customer.Address.Street1),
               
            };
            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            if(result.Rows.Count < 0)
            {
                return Convert.ToInt32(result.Rows[0]["addressId"]);
            }

            query = @"
                INSERT INTO address (address, address2, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy, cityId)
                VALUES (@address1, @address2, @postal, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy, @cityId)";
             parameters = new[]
            {
                _databaseHelper.CreateParameter("@address1", customer.Address.Street1),
                _databaseHelper.CreateParameter("@address2", customer.Address.Street2),
                _databaseHelper.CreateParameter("@postal", customer.Address.PostalCode),
                _databaseHelper.CreateParameter("@phone", customer.Address.PhoneNumber),
                _databaseHelper.CreateParameter("@createDate", customer.CreateDate),
                _databaseHelper.CreateParameter("@createdBy", customer.CreatedBy.Username),
                _databaseHelper.CreateParameter("@lastUpdate", customer.LastUpdate),
                _databaseHelper.CreateParameter("@lastUpdateBy", customer.UpdatedBy.Username),
                _databaseHelper.CreateParameter("@cityId", GetOrCreateCityId(customer.Address)),
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
            return GetLastInsertId();
        }

        public int GetLastInsertId()
        {
            DataTable result = _databaseHelper.ExecuteSelectQuery("SELECT LAST_INSERT_ID()");
            return Convert.ToInt32(result.Rows[0][0]);
        }

        public int GetOrCreateCountryId(City city)
        {
            string query = @"
                SELECT countryId FROM country WHERE country = @countryName";
            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@countryName", city.Country.CountryName)
            };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            if(result.Rows.Count < 0 )
            {
                return Convert.ToInt32(result.Rows[0]["countryId"]);

            }
            parameters = new[]
            {
                _databaseHelper.CreateParameter("@countryName", city.Country.CountryName),
                _databaseHelper.CreateParameter("@createDate", city.CreateDate),
                _databaseHelper.CreateParameter("@createdBy", city.CreatedBy.Username),
                _databaseHelper.CreateParameter("@lastUpdate", city.LastUpdate),
                _databaseHelper.CreateParameter("@lastUpdateBy", city.LastUpdateBy.Username)
            };
            query = @"
                INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@countryName, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            _databaseHelper.ExecuteSelectQuery(query, parameters);
            return GetLastInsertId();
        }

        
    }
}
