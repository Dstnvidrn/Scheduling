using Scheduling.DTOs;
using Scheduling.Interfaces;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.Repositories
{
    public class AppointmentRepository
    {
        private readonly IDatabase _database;
        public AppointmentRepository(IDatabase database) 
        {
            _database = database;
        }

        public List<AppointmentDTO> GetAppointments()
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
                createdByUser.userName AS CreatedByUserName,
                appointment.lastUpdate,
                lastUpdateBy.userName AS lastUpdateBy
            FROM
                appointment
            INNER JOIN
                customer ON appointment.customerId = customer.customerId
            LEFT JOIN
                user AS createdByUser ON appointment.createdBy = createdByUser.userId
            LEFT JOIN
                user AS lastUpdateBy ON appointment.lastUpdateBy = lastUpdateBy.userId";

            DataTable dataTable = _database.ExecuteSelectQuery(query);

            // map DataTable to List<>
            var appointments = new List<AppointmentDTO>();
            foreach(DataRow row in dataTable.Rows)
            {
                var appointment = new AppointmentDTO
                {

                    CustomerName = row["customerName"].ToString(),
                    Description = row["Description"].ToString(),
                    Title = row["title"].ToString(),
                    Type = row["type"].ToString(),
                    Start = Convert.ToDateTime(row["start"]),
                    End = Convert.ToDateTime(row["end"]),
                    Location = row["location"].ToString(),
                    Contact = row["contact"].ToString(),
                    CreateDate = Convert.ToDateTime(row["createDate"]),
                    CreatedBy = row["createdBy"].ToString(),
                    LastUpdate = Convert.ToDateTime(row["lastUpdate"]),
                    UpdatedBy = row["lastUpdateBy"].ToString()
                };
                appointments.Add(appointment);        
            }
            return appointments;
        }

    }
}
