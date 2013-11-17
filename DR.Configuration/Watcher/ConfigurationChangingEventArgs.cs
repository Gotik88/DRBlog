//-----------------------------------------------------------------------
// <copyright file="ConfigurationChangingEventArgs.cs" company="The Frayman Group">
//     Copyright (c) The Frayman Group 2010. All rights reserved.
// </copyright>
// <author>Alexander Shargorodsky</author>
// <date>2010-05-27</date>
//-----------------------------------------------------------------------

namespace TFG.CompliGuard.Configuration
{
    using System.ComponentModel;

    /// <summary>
    /// The ConfigurationChangingEventArgs class.
    /// </summary>
    public class ConfigurationChangingEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationChangingEventArgs"/> class.
        /// </summary>
        /// <param name="configurationSource">
        /// The configuration source file, what should be changed.
        /// </param>
        /// <param name="sectionName">
        /// The section name, what should be changed.
        /// </param>
        public ConfigurationChangingEventArgs(string configurationSource, string sectionName)
        {
            ConfigurationSource = configurationSource;
            SectionName = sectionName;
        }

        /// <summary>
        /// Gets the configuration source file, what should be changed.
        /// </summary>
        public string ConfigurationSource { get; private set; }

        /// <summary>
        /// Gets the section name, what should be changed.
        /// </summary>
        public string SectionName { get; private set; }
    }
}