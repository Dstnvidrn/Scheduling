using Mysqlx.Resultset;
using Scheduling.DTOs;
using Scheduling.Interfaces;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduling.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDatabaseHelper _databaseHelper;
        private readonly ICustomerRepository _customerRepository;
        public AppointmentRepository(IDatabaseHelper databaseHelper) 
        {
            _databaseHelper = databaseHelper;
            _customerRepository = new CustomerRepository(_databaseHelper);
        }

        public void CreateAppointment(Appointment appointment)
        {
            string query = @"
                INSERT INTO appointment
                (customerId, userId, title, description, type, start, end, createDate, createdBy, lastUpdate, lastUpdateBy, location, url, contact)
                VALUES
                (@customerId, @userId, @title, @description, @type, @start, @end, NOW(), @createdBy, NOW(), @lastUpdateBy, @location, @url, @contact)";

            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@customerId", appointment.CustomerId),
                _databaseHelper.CreateParameter("@userId", appointment.UserId),
                _databaseHelper.CreateParameter("@title", appointment.Title),
                _databaseHelper.CreateParameter("@description", appointment.Description),
                _databaseHelper.CreateParameter("@type", appointment.Type),
                _databaseHelper.CreateParameter("@start", appointment.Start),
                _databaseHelper.CreateParameter("@end", appointment.End),
                _databaseHelper.CreateParameter("@createdBy", appointment.CreatedBy.Username),
                _databaseHelper.CreateParameter("@lastUpdateBy", appointment.LastUpdatedBy.Username),
                _databaseHelper.CreateParameter("@location", appointment.Location),
                _databaseHelper.CreateParameter("@url", appointment.URL),
                _databaseHelper.CreateParameter("@contact", appointment.Contact)
        };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }

        public void DeleteAppointment(int id)
        {
            string query = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@appointmentId", id)
            };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }


        public List<Appointment> GetAppointments()
        {

            string query = @"
            SELECT 
                appointment.appointmentId,
                appointment.customerId,
                customer.customerName,
                appointment.userId,
                appointment.title,
                appointment.description,
                appointment.location,
                appointment.contact,
                appointment.type,
                appointment.url,
                appointment.start,
                appointment.end,
                appointment.createDate,
                createdByUser.userName AS CreatedByUserName,
                appointment.lastUpdate,
                lastUpdatedByUser.userName AS LastUpdatedByUserName
            FROM 
                appointment
            INNER JOIN 
                customer ON appointment.customerId = customer.customerId
            LEFT JOIN 
                user AS createdByUser ON appointment.createdBy = createdByUser.userId
            LEFT JOIN 
                user AS lastUpdatedByUser ON appointment.lastUpdateBy = lastUpdatedByUser.userId;
            ";

            DataTable dataTable = _databaseHelper.ExecuteSelectQuery(query);

            // map DataTable to List<>
            var appointments = new List<Appointment>();
            foreach(DataRow row in dataTable.Rows)
            {
                
                var appointment = new Appointment
                {
                    AppointmentId = Convert.ToInt32(row["appointmentId"]),
                    CustomerId = Convert.ToInt32(row["customerId"]),
                    CustomerName = row["customerName"].ToString(),
                    Description = row["Description"].ToString(),
                    Title = row["title"].ToString(),
                    Type = row["type"].ToString(),
                    Start = Convert.ToDateTime(row["start"]),
                    End = Convert.ToDateTime(row["end"]),
                    URL = row["URL"].ToString(),
                    Location = row["location"].ToString(),
                    Contact = row["contact"].ToString(),
                    CreateDate = Convert.ToDateTime(row["createDate"]),
                    CreatedBy = new User { Username = row["createdByUserName"] != null ? row["createdByUserName"].ToString() : null},
                    LastUpdate = Convert.ToDateTime(row["lastUpdate"]),
                    LastUpdatedBy = new User { Username = row["LastUpdatedByUserName"].ToString() }
                };
                appointments.Add(appointment);        
            }
            return appointments;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            string query = @"
                UPDATE appointment
                SET 
                    customerId = @customerId,
                    title = @title,
                    description = @description,
                    type = @type,
                    start = @start,
                    end = @end,
                    lastUpdate = NOW(),
                    lastUpdateBy = @lastUpdateBy,
                    contact = @contact,
                    url = @url,
                    location = @location,
                    userId = @userId,
                    createDate = @createDate,
                    createdBy = @createdBy
                WHERE appointmentId = @appointmentId";

            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@customerId", appointment.CustomerId),
                _databaseHelper.CreateParameter("@title", appointment.Title),
                _databaseHelper.CreateParameter("@description", appointment.Description),
                _databaseHelper.CreateParameter("@type", appointment.Type),
                _databaseHelper.CreateParameter("@start", appointment.Start),
                _databaseHelper.CreateParameter("@end", appointment.End),
                _databaseHelper.CreateParameter("@lastUpdateBy", appointment.LastUpdatedBy.Username),
                _databaseHelper.CreateParameter("@appointmentId", appointment.AppointmentId),
                _databaseHelper.CreateParameter("@contact", appointment.Contact),
                _databaseHelper.CreateParameter("@url", appointment.URL),
                _databaseHelper.CreateParameter("@location", appointment.Location),
                _databaseHelper.CreateParameter("@createDate", appointment.CreateDate),
                _databaseHelper.CreateParameter("@createdBy", appointment.CreatedBy.Username),
                _databaseHelper.CreateParameter("@userId", appointment.UserId),
    };

            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        public bool IsOverlappingAppointment(int customerId, DateTime start, DateTime end, int? appointmentId = null)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM appointment 
                WHERE customerId = @customerId 
                AND ((@start BETWEEN start AND end) OR (@end BETWEEN start AND end))
                AND (@start < end AND @end > start)
                AND (@appointmentId IS NULL OR appointmentId != @appointmentId)";
            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@customerId", customerId),
                _databaseHelper.CreateParameter("@start", start),
                _databaseHelper.CreateParameter("@end", end),
                _databaseHelper.CreateParameter("@appointmentId", appointmentId ?? (object)DBNull.Value)
            };

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }

        public List<AppointmentDTO> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsByUser(int userId)
        {
            string query = @"
                SELECT 
                    a.appointmentId,
                    a.customerId,
                    c.customerName,
                    a.userId,
                    a.title,
                    a.description,
                    a.type,
                    a.start,
                    a.end,
                    a.location,
                    a.contact,
                    a.url,
                    a.createDate,
                    a.createdBy,
                    a.lastUpdate,
                    a.lastUpdateBy
                FROM 
                    appointment a
                INNER JOIN 
                    customer c ON a.customerId = c.customerId
                WHERE 
                    a.userId = @userId;";

            var parameters = new[]
            {
                _databaseHelper.CreateParameter("@userId", userId)
            };

            var appointments = new List<Appointment>();

            var dataTable = _databaseHelper.ExecuteSelectQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                var appointment = new Appointment
                {
                    AppointmentId = Convert.ToInt32(row["appointmentId"]),
                    CustomerId = Convert.ToInt32(row["customerId"]),
                    CustomerName = row["customerName"].ToString(),
                    //UserId = Convert.ToInt32(row["userId"]),
                    Title = row["title"].ToString(),
                    Description = row["Description"].ToString(),
                    Type = row["type"].ToString(),
                    Start = Convert.ToDateTime(row["start"]),
                    End = Convert.ToDateTime(row["end"]),
                    Location = row["location"].ToString(),
                    Contact = row["contact"].ToString(),
                    URL = row["URL"].ToString(),
                    CreateDate = Convert.ToDateTime(row["createDate"]),
                    CreatedBy = new User { Username = row["createdBy"] != null ? row["createdBy"].ToString() : null },
                    LastUpdate = Convert.ToDateTime(row["lastUpdate"]),
                    LastUpdatedBy = new User { Username = row["lastUpdateBy"].ToString() }


                };
                appointments.Add(appointment);
            }

            return appointments;
        }

    }
}
