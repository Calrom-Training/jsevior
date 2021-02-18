// <copyright file="DatabaseController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// controller for the api.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase, IDatabaseController
    {
        private readonly DatabaseConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseController"/> class.
        /// </summary>
        /// <param name="database">dependency injected database connection.</param>
        public DatabaseController(IDatabaseConnection database)
        {
            this.database = (DatabaseConnection)database;
        }

        /// <summary>
        /// using the object posted from the user, the username and password are taken. These details are then passed to the database function LogOnAttempt. The resulting passwords are then compared
        /// and if they match then the GetMessages function is called and the user's messages are grabbed passed back to where the post request came from.
        /// </summary>
        /// <param name="log_on_attempt">object from front that contains the username and password.</param>
        /// <returns>a UserMessages object, either containing the users messages on success or a parameter labeled flase is the details weren't matched.</returns>
        [HttpPost]
        public UserMessages LogOnAttempt(User log_on_attempt)
        {
            User databaseDetails = new User();
            UserMessages requestedMessages = new UserMessages();
            databaseDetails = this.database.Database.LogOnAttempt(log_on_attempt);
            if (databaseDetails.IsSuccess)
            {
                if (this.database.Database.Password_Checker(log_on_attempt.Password, databaseDetails.Password))
                {
                    requestedMessages = this.database.Database.GetMessages(databaseDetails.UserId);
                }
            }

            requestedMessages.Username = log_on_attempt.Username;
            return requestedMessages;
        }

        /// <summary>
        /// changes a users password after checking they have the correct information.
        /// </summary>
        /// <param name="password_Change">an object that contains a user's details and their new password.</param>
        /// <returns>a string that lets the user know the status of their request.</returns>
        [HttpPut]
        public string PasswordChangeAttempt(PasswordChange password_Change)
        {
            string result;
            DBconnection db = new DBconnection();
            User databaseDetails = new User();
            UserMessages requestedMessages = new UserMessages();
            databaseDetails = this.database.Database.LogOnAttempt(password_Change.UserDetails);
            if (databaseDetails.IsSuccess)
            {
                if (this.database.Database.Password_Checker(password_Change.UserDetails.Password, databaseDetails.Password))
                {
                    this.database.Database.ChangePassword(password_Change);
                    result = "Your new password has been successfully changed.";
                }
                else
                {
                    result = "Password was incorrect.";
                }
            }
            else
            {
                result = "User could not be found.";
            }

            return result;
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
