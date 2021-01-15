// <copyright file="UserMessage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace API_template
{
    /// <summary>
    /// Class for hold an individual user message.
    /// </summary>
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
        /// <param name="message">the text of the message.</param>
        /// <param name="messageId">the message id.</param>
        public UserMessage(string message, string messageId)
        {
            this.Message = message;
            this.MessageID = messageId;
        }

        /// <summary>
        /// Gets or sets the string message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the string messageid.
        /// </summary>
        public string MessageID { get; set; }
    }
}
