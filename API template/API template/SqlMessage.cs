// <copyright file="SqlMessage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_template
{
    /// <summary>
    /// class for holding parameter and then building the needed sql messages.
    /// </summary>
    public class SqlMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlMessage"/> class.
        /// </summary>
        public SqlMessage()
        {
        }

        /// <summary>
        /// gets or sets the Search Criteria of the sql message.
        /// </summary>
        public string Search_criteria { get; set; }

        /// <summary>
        /// gets or sets the Search Criteria Value of the sql message.
        /// </summary>
        public string Search_criteria_value { get; set; }

        /// <summary>
        /// gets or sets the table of the sql request.
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// uses the input to build a SQL request string.
        /// </summary>
        /// <returns>string</returns>
        public static string Message_builder(string table, string search_criteria, string search_criteria_value)
        {
            string built_message;

            built_message =$"select * from {table} where {search_criteria}='{search_criteria_value}'";

            return built_message;
        }

    }
}
