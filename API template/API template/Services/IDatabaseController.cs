// <copyright file="IDatabaseController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template.Services
{
    /// <summary>
    /// interface for the DatabaseController class.
    /// </summary>
    public interface IDatabaseController
    {
        /// <summary>
        /// function to try and log on a user using strings.
        /// </summary>
        /// <param name="userName">username.</param>
        /// <param name="password">password.</param>
        /// <returns>a users info.</returns>
        UserMessages LogOnAttempt(string userName, string password);

        /// <summary>
        /// function to try and log on a user using a User object.
        /// </summary>
        /// <param name="log_on_attempt">user object.</param>
        /// <returns>a users info.</returns>
        UserMessages LogOnAttempt(User log_on_attempt);

        /// <summary>
        /// function to try and change a user's password using a PasswordChange object.
        /// </summary>.
        /// <param name="password_Change">PasswordChange object.</param>
        /// <returns>a string that contains the result of the password change attempt.</returns>
        string PasswordChangeAttempt(PasswordChange password_Change);
    }
}