// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnectionConfiguration.cs" company="Dmytro Romanii Corporation">
//   Copyright (c) Dmytro Romanii Corporation 2013. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DR.Data
{
    internal interface IConnectionConfiguration
    {
        string ConnectionString { get; }

        IDbProviderFactory ProviderFactory { get; }
    }
}
