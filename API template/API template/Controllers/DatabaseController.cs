// <copyright file="DatabaseController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template.Controllers
{
    using API_template.Classes;
    using API_template.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// controller for the api.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase, IDatabaseController
    {
        private readonly DatabaseConnection database;
        private readonly DatabaseControllerDefinitions definitions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseController"/> class.
        /// </summary>
        /// <param name="database">dependency injected database connection.</param>
        public DatabaseController(IDatabaseConnection database, IDatabaseConnection definitions)
        {
            this.database = (DatabaseConnection)database;
            this.definitions = definitions.Definitions;
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
            return this.definitions.LogOnAttempt(log_on_attempt, this.database.Database);
        }

        /// <summary>
        /// changes a users password after checking they have the correct information.
        /// </summary>
        /// <param name="password_Change">an object that contains a user's details and their new password.</param>
        /// <returns>a string that lets the user know the status of their request.</returns>
        [HttpPut]
        public string PasswordChangeAttempt(PasswordChange password_Change)
        {
            return this.definitions.PasswordChangeAttempt(password_Change, this.database.Database);
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
           return this.definitions.LogOnAttempt(userName, password, this.database.Database);
        }
    }
}
