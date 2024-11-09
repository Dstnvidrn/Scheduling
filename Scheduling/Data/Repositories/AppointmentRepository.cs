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
                appointment.createdBy,
                createdByUser.userName AS createdByUserName,
                appointment.lastUpdate,
                user.userName AS LastUpdatedByUserName
            FROM
                appointment
            INNER JOIN
                customer ON appointment.customerId = customer.customerId
            LEFT JOIN
                user AS createdByUser ON appointment.createdBy = createdByUser.userId
            LEFT JOIN
                user ON appointment.lastUpdateBy = user.userId;";

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
                    CreatedBy = new User { Username = row["createdBy"].ToString(), UserId = Convert.ToInt32(row["createdByUser.userid"])},
                    LastUpdate = Convert.ToDateTime(row["lastUpdate"]),
                    LastUpdatedBy = new User { Username = row["lastUpdateBy"].ToString() }
                };
                appointments.Add(appointment);        
            }
            return appointments;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        
    }
}
