// <copyright file="DatabaseConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template
{
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
    }
}
