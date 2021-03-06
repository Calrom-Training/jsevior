﻿// <copyright file="IDatabaseConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace API_template.Services
{
    using API_template.Classes;
    /// <summary>
    /// interface for the DataConnection allowing for dependency injection.
    /// </summary>
    public interface IDatabaseConnection
    {
        /// <summary>
        /// gets am instance of DBconnection().
        /// </summary>
        DBconnection Database { get; }

        DatabaseControllerDefinitions Definitions { get; }
    }
}
