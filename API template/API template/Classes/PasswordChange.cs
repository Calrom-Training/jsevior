// <copyright file="PasswordChange.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template
{
    /// <summary>
    /// object to contain both a user's details and the new password they wish.
    /// </summary>
    public class PasswordChange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordChange"/> class.
        /// </summary>
        public PasswordChange()
        {
        }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the user's details.
        /// </summary>
        public User UserDetails { get; set; }
    }
}
