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
        public AppointmentRepository(IDatabaseHelper databaseHelper) 
        {
            _databaseHelper = databaseHelper;
        }

        public void CreateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public AppointmentsForm GetAppointmentById(int id)
        {
            throw new NotImplementedException();
            
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
            throw new NotImplementedException();
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

    }
}
