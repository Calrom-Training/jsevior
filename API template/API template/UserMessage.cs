using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_template
{
    public class UserMessage
    {
        public UserMessage()
        {
        }

        public UserMessage(string message, string messageId)
        {
            this.Message = message;
            this.MessageID = messageId;
        }

        public string Message { get; set; }

        public string MessageID { get; set; }
    }
}
