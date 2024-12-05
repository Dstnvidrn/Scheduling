using Scheduling.Interfaces;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Scheduling.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDatabaseHelper _databaseHelper;
        public CustomerRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
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

        public Customer GetCustomerById(int customerId)
        {

            string query = @"
        SELECT 
            * FROM customer WHERE customerId = @customerId";

            var parameters = new[]
            {
                    _databaseHelper.CreateParameter("@customerId", customerId),
                };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query);

            var customer = new Customer
            {
                CustomerId = Convert.ToInt32(result.Rows[0]["customerId"]),
                CustomerName = result.Rows[0]["customerName"].ToString(),
                Address = new Address
                {
                    Street1 = result.Rows[0]["AddressStreet"].ToString(),
                    Street2 = result.Rows[0]["AddressStreet2"].ToString(),
                    PostalCode = result.Rows[0]["Postal"].ToString(),
                    PhoneNumber = result.Rows[0]["phone"].ToString(),
                    City = new City
                    {
                        Id = Convert.ToInt32(result.Rows[0]["cityId"]),
                        CityName = result.Rows[0]["CityName"].ToString(),
                        Country = new Country
                        {
                            Id = Convert.ToInt32(result.Rows[0]["countryId"]),
                            CountryName = result.Rows[0]["CountryName"].ToString()
                        }
                    }
                },
                IsActive = Convert.ToBoolean(result.Rows[0]["active"]),
                CreateDate = Convert.ToDateTime(result.Rows[0]["createDate"]),
                CreatedBy = new User { Username = result.Rows[0]["createdBy"].ToString() },
                LastUpdate = Convert.ToDateTime(result.Rows[0]["lastUpdate"]),
                UpdatedBy = new User { Username = result.Rows[0]["Updated By"].ToString() }
            };



            MessageBox.Show(customer.Address.PhoneNumber);
            return customer;

        }
        public void DeleteCustomer(Customer customer)
        {
            DeleteAppointmentsByCustomerId(customer.CustomerId);

            int addressId = GetAddressIdByCustomerId(customer.CustomerId);
            if (addressId == 0)
            {
                throw new Exception("Customer not found or already deleted.");
            }

            var cityCountryIds = GetCityAndCountryIdsByAddressId(addressId);

            DeleteCustomerRecord(customer.CustomerId);

            DeleteAddress(addressId);

            if (!IsCityReferenced(cityCountryIds.CityId))
            {
                DeleteCity(cityCountryIds.CityId);
            }

            if (!IsCountryReferenced(cityCountryIds.CountryId))
            {
                DeleteCountry(cityCountryIds.CountryId);
            }
        }


        private (int CityId, int CountryId) GetCityAndCountryIdsByAddressId(int addressId)
        {
            string query = @"SELECT city.cityId, city.countryId 
                     FROM address 
                     INNER JOIN city ON address.cityId = city.cityId 
                     WHERE address.addressId = @addressId";
            var parameters = new[] { _databaseHelper.CreateParameter("@addressId", addressId) };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                return (
                    CityId: Convert.ToInt32(result.Rows[0]["cityId"]),
                    CountryId: Convert.ToInt32(result.Rows[0]["countryId"])
                );
            }
            throw new Exception("Address not found.");
        }

        private void DeleteCustomerRecord(int customerId)
        {
            string query = "DELETE FROM customer WHERE customerId = @customerId";
            var parameters = new[] { _databaseHelper.CreateParameter("@customerId", customerId) };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        private void DeleteAppointmentsByCustomerId(int customerId)
        {
            string query = "DELETE FROM appointment WHERE customerId = @customerId";
            var parameters = new[] { _databaseHelper.CreateParameter("@customerId", customerId) };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }


        private void DeleteAddress(int addressId)
        {
            string query = "DELETE FROM address WHERE addressId = @addressId";
            var parameters = new[] { _databaseHelper.CreateParameter("@addressId", addressId) };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }

        private bool IsCityReferenced(int cityId)
        {
            string query = "SELECT COUNT(*) FROM address WHERE cityId = @cityId";
            var parameters = new[] { _databaseHelper.CreateParameter("@cityId", cityId) };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }

        private void DeleteCity(int cityId)
        {
            string query = "DELETE FROM city WHERE cityId = @cityId";
            var parameters = new[] { _databaseHelper.CreateParameter("@cityId", cityId) };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }

        private bool IsCountryReferenced(int countryId)
        {
            string query = "SELECT COUNT(*) FROM city WHERE countryId = @countryId";
            var parameters = new[] { _databaseHelper.CreateParameter("@countryId", countryId) };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }

        private void DeleteCountry(int countryId)
        {
            string query = "DELETE FROM country WHERE countryId = @countryId";
            var parameters = new[] { _databaseHelper.CreateParameter("@countryId", countryId) };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        private int GetAddressIdByCustomerId(int customerId)
        {
            string query = "SELECT addressId FROM customer WHERE customerId = @customerId";
            var parameters = new[] { _databaseHelper.CreateParameter("@customerId", customerId) };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            return result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0]["addressId"]) : 0;
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
            if (result.Rows.Count < 0)
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
            if (result.Rows.Count < 0)
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

        public List<Customer> GetAllCustomers()
        {
            string query = @"
        SELECT 
            customer.customerId,
            customer.customerName,
            customer.addressId,
            customer.active,
            customer.createDate,
            customer.createdBy,
            customer.lastUpdate,
            customer.lastUpdateBy AS 'Updated By',
            address.address AS AddressStreet,
            address.address2 AS AddressStreet2,
            address.postalCode AS Postal,
            address.phone,
            city.cityId,
            city.city AS CityName,
            country.countryId,
            country.country AS CountryName
        FROM 
            customer
        INNER JOIN 
            address ON customer.addressId = address.addressId
        INNER JOIN 
            city ON address.cityId = city.cityId
        INNER JOIN 
            country ON city.countryId = country.countryId";

            var customers = new List<Customer>();
            DataTable result = _databaseHelper.ExecuteSelectQuery(query);
            foreach (DataRow row in result.Rows)
            {
                var customer = new Customer
                {
                    CustomerId = Convert.ToInt32(row["customerId"]),
                    CustomerName = row["customerName"].ToString(),
                    Address = new Address
                    {
                        Street1 = row["AddressStreet"].ToString(),
                        Street2 = row["AddressStreet2"].ToString(),
                        PostalCode = row["Postal"].ToString(),
                        PhoneNumber = row["phone"].ToString(),
                        City = new City
                        {
                            Id = Convert.ToInt32(row["cityId"]),
                            CityName = row["CityName"].ToString(),
                            Country = new Country
                            {
                                Id = Convert.ToInt32(row["countryId"]),
                                CountryName = row["CountryName"].ToString()
                            }
                        }
                    },
                    IsActive = Convert.ToBoolean(row["active"]),
                    CreateDate = Convert.ToDateTime(row["createDate"]),
                    CreatedBy = new User { Username = row["createdBy"].ToString() },
                    LastUpdate = Convert.ToDateTime(row["lastUpdate"]),
                    UpdatedBy = new User { Username = row["Updated By"].ToString() }
                };

                customers.Add(customer);
            }

            return customers;
        }
        public void UpdateCustomer(Customer customer)
        {
            string query = @"
                UPDATE customer
                SET 
                    customerName = @customerName,
                    active = @active,
                    lastUpdate = @lastUpdate,
                    lastUpdateBy = @lastUpdateBy
                WHERE customerId = @customerId";

            var parameters = new[]
            {
            _databaseHelper.CreateParameter("@customerName", customer.CustomerName),
            _databaseHelper.CreateParameter("@active", customer.IsActive ? 1 : 0),
            _databaseHelper.CreateParameter("@lastUpdateBy", customer.UpdatedBy.Username),
            _databaseHelper.CreateParameter("@lastUpdate", DateTime.Now),
            _databaseHelper.CreateParameter("@customerId", customer.CustomerId)
            };

            _databaseHelper.ExecuteNonQuery(query, parameters);

            // Update related tables
            UpdateAddress(customer);
            UpdateCity(customer);
            UpdateCountry(customer);
        }

        private void UpdateAddress(Customer customer)
        {
            string query = @"
            UPDATE address
            SET 
                address = @street1,
                address2 = @street2,
                phone = @phone,
                postalCode = @postal,
                lastUpdateBy = @updateBy,
                lastUpdate = @lastUpdate
            WHERE addressId = (
                SELECT addressId FROM customer WHERE customerId = @customerId
            )";

            var parameters = new[]
            {
            _databaseHelper.CreateParameter("@street1", customer.Address.Street1),
            _databaseHelper.CreateParameter("@street2", customer.Address.Street2),
            _databaseHelper.CreateParameter("@phone", customer.Address.PhoneNumber),
            _databaseHelper.CreateParameter("@postal", customer.Address.PostalCode),
            _databaseHelper.CreateParameter("@updateBy", customer.UpdatedBy.Username),
            _databaseHelper.CreateParameter("@lastUpdate", customer.LastUpdate),
            _databaseHelper.CreateParameter("@customerId", customer.CustomerId)
        };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        private void UpdateCity(Customer customer)
        {
            string query = @"
                UPDATE city
                SET 
                    city = @cityName,
                    lastUpdate = @lastUpdate,
                    lastUpdateBy = @lastUpdateBy
                WHERE cityId = (
                    SELECT cityId 
                    FROM address
                    WHERE addressId = (SELECT addressId FROM customer WHERE customerId = @customerId))";

            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@cityName", customer.Address.City.CityName),
                _databaseHelper.CreateParameter("@customerId", customer.CustomerId),
                _databaseHelper.CreateParameter("@lastUpdate", customer.LastUpdate),
                _databaseHelper.CreateParameter("@lastUpdateBy", customer.UpdatedBy.Username)
            };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }

        private void UpdateCountry(Customer customer)
        {
            string query = @"
                UPDATE country
                SET 
                    country = @countryName
                WHERE countryId = (
                    SELECT countryId 
                    FROM city
                    WHERE cityId = (
                        SELECT cityId 
                        FROM address
                        WHERE addressId = (
                            SELECT addressId FROM customer WHERE customerId = @customerId
                        )
                    )
                )";

            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@countryName", customer.Address.City.Country.CountryName),
                _databaseHelper.CreateParameter("@customerId", customer.CustomerId)
            };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }

        public List<KeyValuePair<int, string>> GetCustomerIdAndName()
        {
            string query = @"SELECT customerId, customerName FROM customer";
            var result = _databaseHelper.ExecuteSelectQuery(query);

            var customers = new List<KeyValuePair<int, string>>();
            foreach (DataRow row in result.Rows)
            {
                customers.Add(new KeyValuePair<int, string>(
                    Convert.ToInt32(row["customerId"]),
                    row["customerName"].ToString()
                ));
            }

            return customers;
        }

    }
}
