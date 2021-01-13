// <copyright file="UserMessages.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template
{
    using System.Collections.Generic;

    /// <summary>
    /// the class for holding all of a users messages.
    /// </summary>
    public class UserMessages
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessages"/> class.
        /// </summary>
        public UserMessages()
        {
            this.ListUserMessages = new List<UserMessage>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether there are any messages for this user.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// gets or sets the Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// gets or sets the list of user messages.
        /// </summary>
        public List<UserMessage> ListUserMessages { get; set; }
    }
}
