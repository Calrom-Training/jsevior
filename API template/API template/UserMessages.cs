using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_template
{
    public class UserMessages
    {
        public UserMessages()
        {
            this.ListUserMessages = new List<UserMessage>();
        }

        public bool IsSuccess { get; set; }

        public string Username { get; set; }

        public List<UserMessage> ListUserMessages { get; set; }
    }
}
