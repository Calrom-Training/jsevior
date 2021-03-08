namespace API_template.Classes
{
    public class SqlMessage
    {
        public static string SqlMessageSelector(string databasetype, string table, string search_criteria, string search_criteria_value)
        {
            string sqlmessage;
            switch (databasetype)
            {
                case "sqlite":
                     sqlmessage = SqliteMessage.SelectMessageBuilder(table, search_criteria, search_criteria_value);
                     break;
                default:
                     sqlmessage = "failed to write sql message";
                     break;
            }

            return sqlmessage;
        }

        public static string SqlMessageSelector(string databasetype, string table, string set_criteria, string set_criteria_value, string search_criteria, string search_criteria_value)
        {
            string sqlmessage;
            switch (databasetype)
            {
                case "sqlite":
                    sqlmessage = SqliteMessage.UpdateMessageBuilder(table, set_criteria, set_criteria_value, search_criteria, search_criteria_value);
                    break;
                default:
                    sqlmessage = "failed to write sql message";
                    break;
            }

            return sqlmessage;
        }
    }
}
