// <copyright file="DatabaseController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        [HttpPost]
        public UserMessages LogOnAttempt(User log_on_attempt)
        {
            DBconnection db = new DBconnection();
            User DatabaseDetails = new User();
            UserMessages RequestedMessages = new UserMessages();
            DatabaseDetails = db.LogOnAttempt(log_on_attempt);
            if (DatabaseDetails.IsSuccess)
            {
                if(db.Password_Checker(log_on_attempt.Password, DatabaseDetails.Password))
                {
                    RequestedMessages = db.GetMessages(DatabaseDetails.UserId);
                }
            }

            RequestedMessages.Username = log_on_attempt.Username;
            return RequestedMessages;
        }

        [HttpGet]
        public UserMessages LogOnAttempt(string userName, string password)
        {
            User getUser = new User();
            getUser.Password = password;
            getUser.Username = userName;
            return LogOnAttempt(getUser);
        }
    }
}
