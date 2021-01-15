// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace API_template
{
    /// <summary>
    /// class to store user info.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsSuccess is true or false.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the string Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the string Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the int UserId.
        /// </summary>
        public int UserId { get; set; }
    }
}
