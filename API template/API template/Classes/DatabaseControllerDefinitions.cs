namespace API_template.Classes
{
    public class DatabaseControllerDefinitions
    {
        public DatabaseControllerDefinitions()
        {

        }

        public UserMessages LogOnAttempt(User log_on_attempt, DBconnection database)
        {
            User databaseDetails = new User();
            UserMessages requestedMessages = new UserMessages();
            databaseDetails = database.LogOnAttempt(log_on_attempt);
            if (databaseDetails.IsSuccess)
            {
                if (database.Password_Checker(log_on_attempt.Password, databaseDetails.Password))
                {
                    requestedMessages = database.GetMessages(databaseDetails.UserId);
                }
            }

            requestedMessages.Username = log_on_attempt.Username;
            return requestedMessages;
        }

        public string PasswordChangeAttempt(PasswordChange password_Change, DBconnection database)
        {
            string result;
            DBconnection db = new DBconnection();
            User databaseDetails = new User();
            UserMessages requestedMessages = new UserMessages();
            databaseDetails = database.LogOnAttempt(password_Change.UserDetails);
            if (databaseDetails.IsSuccess)
            {
                if (database.Password_Checker(password_Change.UserDetails.Password, databaseDetails.Password))
                {
                    database.ChangePassword(password_Change);
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

        public UserMessages LogOnAttempt(string userName, string password, DBconnection database)
        {
            User getUser = new User();
            getUser.Password = password;
            getUser.Username = userName;
            User databaseDetails = new User();
            UserMessages requestedMessages = new UserMessages();
            databaseDetails = database.LogOnAttempt(getUser);
            if (databaseDetails.IsSuccess)
            {
                if (database.Password_Checker(getUser.Password, databaseDetails.Password))
                {
                    requestedMessages = database.GetMessages(databaseDetails.UserId);
                }
            }

            requestedMessages.Username = getUser.Username;
            return requestedMessages;
        }

    }

}