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

    /// <summary>
    /// controller for the api.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
/// <summary>
/// using the object posted from the user, the username and password are taken. These details are then passed to the database function LogOnAttempt. The resulting passwords are then compared
/// and if they match then the GetMessages function is called and the user's messages are grabbed passed back to where the post request came from.
/// </summary>
/// <param name="log_on_attempt">object from front that contains the username and password.</param>
/// <returns>a UserMessages object, either containing the users messages on success or a parameter labeled flase is the details weren't matched.</returns>
        [HttpPost]
        public UserMessages LogOnAttempt(User log_on_attempt)
        {
            DBconnection db = new DBconnection();
            User databaseDetails = new User();
            UserMessages requestedMessages = new UserMessages();
            databaseDetails = db.LogOnAttempt(log_on_attempt);
            if (databaseDetails.IsSuccess)
            {
                if (db.Password_Checker(log_on_attempt.Password, databaseDetails.Password))
                {
                    requestedMessages = db.GetMessages(databaseDetails.UserId);
                }
            }

            requestedMessages.Username = log_on_attempt.Username;
            return requestedMessages;
        }

        /// <summary>
        /// HTTP get version of the HttpPost LogOnAttempt. uses the values from a get request to form an object and then passes it through the HTTP post LogOnAttempt above.
        /// </summary>
        /// <param name="userName">username.</param>
        /// <param name="password">password.</param>
        /// <returns>user messages.</returns>
        [HttpGet]
        public UserMessages LogOnAttempt(string userName, string password)
        {
            User getUser = new User();
            getUser.Password = password;
            getUser.Username = userName;
            return this.LogOnAttempt(getUser);
        }
    }
}
