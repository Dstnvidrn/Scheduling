﻿using Scheduling.Interfaces;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduling.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseHelper _databaseHelper;


        public UserRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public List<User> GetAllUsers()
        {
            string query = @"SELECT userId, username FROM user";

            DataTable results = _databaseHelper.ExecuteSelectQuery(query);
            List<User> users = new List<User>();
            foreach (DataRow row in results.Rows)
            {
                var user = new User
                {
                    UserId = Convert.ToInt32(row["userId"]),
                    Username = row["userName"].ToString(),

                };
                users.Add(user);
            }
            return users;
        }

        public User GetUser(string username)
        {
            string query = "SELECT userId, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy FROM user WHERE userName = @username";

            IDataParameter[] parameters = new IDataParameter[]
            {
                _databaseHelper.CreateParameter("@username", username)
            };
            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                return new User
                {
                    UserId = Convert.ToInt32(result.Rows[0]["userId"]),
                    Username = result.Rows[0]["userName"].ToString(),
                    Password = result.Rows[0]["Password"].ToString(),
                    isActive = Convert.ToBoolean(result.Rows[0]["active"]),
                    CreateDate = Convert.ToDateTime(result.Rows[0]["createDate"]),
                    CreatedBy = new User { Username = result.Rows[0]["createdBy"].ToString() },
                    LastUpdate = Convert.ToDateTime(result.Rows[0]["lastUpdate"]),
                    UpdatedBy = new User { Username = result.Rows[0]["lastUpdateBy"].ToString() },

                };
            }
            return null;
        }
    }
}
