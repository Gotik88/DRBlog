//-----------------------------------------------------------------------
// <copyright file="ConfigurationChangedEventArgs.cs" company="The Frayman Group">
//     Copyright (c) The Frayman Group 2010. All rights reserved.
namespace DR.Configuration.Events
{
    using System;

    public class ConfigurationChangedEventArgs : EventArgs
    {
        public ConfigurationChangedEventArgs(string configurationSource)
        {
            ConfigurationSource = configurationSource;
        }

        public ConfigurationChangedEventArgs(string configurationSource, string sectionName)
        {
            ConfigurationSource = configurationSource;
            SectionName = sectionName;
        }

        public string ConfigurationSource { get; private set; }

        public string SectionName { get; private set; }
    }
}