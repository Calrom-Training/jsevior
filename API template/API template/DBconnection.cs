using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace API_template
{
    public class DBconnection
    {
        private string DBConPath { get; }

        public DBconnection()
        {
            this.DBConPath = Environment.CurrentDirectory + "/sqlite database/firstuser.db";
        }

        public User LogOnAttempt(User logondetails)
        {
            using( var connection = new SqliteConnection("Data Source=" + this.DBConPath))
            {
                User result = new User();
                string LogOnTable = "UserDetails";
                string LogOnCriteria = "Username";
                connection.Open();
                var command = connection.CreateCommand();
                string username = logondetails.Username;
                command.CommandText = SqlMessage.Message_builder(LogOnTable, LogOnCriteria, logondetails.Username);
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
                command.CommandText = SqlMessage.Message_builder(messageTable, messageCriteria, userId);
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
                }

                reader.Close();
                connection.Close();
            }

            return result;
        }

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
