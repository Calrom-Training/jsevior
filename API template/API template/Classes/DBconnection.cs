// <copyright file="DBconnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Data.Sqlite;

    /// <summary>
    /// Class for interacting with the database.
    /// </summary>
    public class DBconnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBconnection"/> class.
        /// </summary>
        public DBconnection()
        {
            this.DBConPath = Environment.CurrentDirectory + "/sqlite_database/firstuser.db";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBconnection"/> class.
        /// Overloaded constructor for testing purposes. Allows testing solution to access the database from a differenct directory.
        /// </summary>
        /// <param name="databasePath">Database path specific to the pc which the tests are being run on.</param>
        public DBconnection(string databasePath)
        {
            this.DBConPath = databasePath;
        }

        private string DBConPath { get; }

        /// <summary>
        /// searches the user details for an entry with the same user name. if there is one then entry is turned into a User object and returned.
        /// </summary>
        /// <param name="logondetails">User object.</param>
        /// <returns>A user object made from the infomation in the database.</returns>
        public User LogOnAttempt(User logondetails)
        {
            using (var connection = new SqliteConnection("Data Source=" + this.DBConPath))
            {
                User result = new User();
                string logOnTable = "UserDetails";
                string logOnCriteria = "Username";
                connection.Open();
                var command = connection.CreateCommand();
                string username = logondetails.Username;
                command.CommandText = SqlMessage.SqlMessageSelector("sqlite", logOnTable, logOnCriteria, logondetails.Username);
                SqliteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.IsSuccess = true;

                        result.UserId = reader.GetInt32(reader.GetOrdinal("UserID"));
                        result.Username = reader.GetString(reader.GetOrdinal("Username"));
                        result.Password = reader.GetString(reader.GetOrdinal("Password"));
                    }
                }
                else
                {
                    result.IsSuccess = false;
                }

                reader.Close();
                connection.Close();
                return result;
            }
        }

        /// <summary>
        /// changes the password of a user in the database.
        /// </summary>
        /// <param name="password_Change">object containing a user's information and their new password.</param>
        public void ChangePassword(PasswordChange password_Change)
        {
            using (var connection = new SqliteConnection("Data Source=" + this.DBConPath))
            {
                string logOnTable = "UserDetails";
                string logOnCriteria = "Username";
                string setCriteria = "Password";
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = SqlMessage.SqlMessageSelector("sqlite", logOnTable, setCriteria, password_Change.NewPassword, logOnCriteria, password_Change.UserDetails.Username);
                SqliteDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
            }
        }

        /// <summary>
        /// uses the primary key of the user to find all of their messages.
        /// </summary>
        /// <param name="userid">unique identifer of a user.</param>
        /// <returns>UserMessages object which contains the user name, a success key and a list of all of the messages for the user.</returns>
        public UserMessages GetMessages(int userid)
        {
            UserMessages result = new UserMessages();
            using (var connection = new SqliteConnection("Data Source=" + this.DBConPath))
            {
                string messageTable = "UserMessages";
                string messageCriteria = "UserId";
                connection.Open();
                var command = connection.CreateCommand();
                string userId = userid.ToString();
                command.CommandText = SqlMessage.SqlMessageSelector("sqlite", messageTable, messageCriteria, userId);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    result.IsSuccess = true;
                    while (reader.Read())
                    {
                        result.ListUserMessages.Add(new UserMessage(reader.GetString(reader.GetOrdinal("Message")), reader.GetInt32(reader.GetOrdinal("Messageid")).ToString()));
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.ListUserMessages.Add(new UserMessage("No messages found", "1"));
                }

                reader.Close();
                connection.Close();
            }

            return result;
        }

        /// <summary>
        /// compares the given password to the password that is found in the database provides.
        /// </summary>
        /// <param name="fromUI">password from the user.</param>
        /// <param name="fromDB">password from the databse.</param>
        /// <returns>bool.</returns>
        public bool Password_Checker(string fromUI, string fromDB)
        {
            bool result = false;
            if (fromDB == fromUI)
            {
                result = true;
            }

            return result;
        }
    }
}
