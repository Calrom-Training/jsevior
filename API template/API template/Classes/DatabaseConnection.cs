// <copyright file="DatabaseConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template
{
    using API_template.Services;
    using API_template.Classes;

    /// <summary>
    /// code implementing the IDatabaseConnection interface.
    /// </summary>
    public class DatabaseConnection : IDatabaseConnection
    {
    /// <summary>
    /// Gets the database connection.
    /// </summary>
        public DBconnection Database
        {
            get { return new DBconnection(); }
        }

        public DatabaseControllerDefinitions Definitions
        {
            get { return new DatabaseControllerDefinitions(); }
        }
    }
}
