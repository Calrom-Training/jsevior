using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_template
{
    public class UserMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessage"/> class.
        /// </summary>
        public UserMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessage"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageId"></param>
        public UserMessage(string message, string messageId)
        {
            this.Message = message;
            this.MessageID = messageId;
        }

        public string Message { get; set; }

        public string MessageID { get; set; }
    }
}
