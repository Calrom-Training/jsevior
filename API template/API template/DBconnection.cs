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

        public UserMessages GetMessages(int rowid)
        {
            UserMessages result = new UserMessages();
            using (var connection = new SqliteConnection("Data Source=" + this.DBConPath))
            {
                string MessageTable = "UserMessages";
                string MessageCriteria = "UserId";
                connection.Open();
                var command = connection.CreateCommand();
                string UserId = rowid.ToString();
                command.CommandText = SqlMessage.Message_builder(MessageTable, MessageCriteria, UserId);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    bool MoreResults = true;
                    while (MoreResults)
                    {
                        result.IsSuccess = true;
                        while (reader.Read())
                        {
                            result.ListUserMessages.Add(new UserMessage(reader.GetString(reader.GetOrdinal("Message")), reader.GetInt32(reader.GetOrdinal("Messageid")).ToString()));
                            MoreResults = reader.NextResult();
                        }
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

        public bool Password_Checker(string FromUI, string FromDB)
        {
            bool result = false;
            if (FromDB == FromUI)
            {
                result = true;
            }

            return result;
        }

    }
}
