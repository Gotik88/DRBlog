namespace DR.Configuration.Events
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Security.Permissions;
    using System.Threading;

    /// <summary>
    /// The watcher class is assumed to be used for observing
    /// the changes being made in the configuration.
    /// </summary>
    /// <remarks>
    /// The <see cref="IConfigurationService"/> implementation should provide
    /// a caching mechanism for quick config access. This may be a potential source
    /// of exception, if one will change the config file outside of the service.
    /// To avoid this, the service should be reset be call the <see cref="IConfigurationService.Reset"/>.
    /// So, in addition to this method, a config file watcher could be used
    /// to notify about changes being made outside the service.
    /// </remarks>
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class ConfigurationChangesWatcher : IDisposable
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        private FileSystemWatcher _watcher = new FileSystemWatcher();

        public ConfigurationChangesWatcher()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (configuration.HasFile)
            {
                Initialize(configuration.FilePath);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationChangesWatcher"/> class.
        /// </summary>
        /// <param name="fileName">
        /// The configuraion file name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// The file name is null or empty, or file not exists.
        /// </exception>
        public ConfigurationChangesWatcher(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("fileName");
            }

            if (!File.Exists(fileName))
            {
                throw new ArgumentException("fileName");
            }

            Initialize(fileName);
        }

        public event EventHandler<ConfigurationChangedEventArgs> ConfigurationChanged;

        public string FileName { get; private set; }

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// Starts the file observing.
        /// </summary>
        public void Start()
        {
            if (FileName != null)
            {
                _lock.EnterWriteLock();
                try
                {
                    if (_watcher.EnableRaisingEvents)
                    {
                        return;
                    }

                    _watcher.Path = Path.GetDirectoryName(Path.GetFullPath(FileName));
                    _watcher.Filter = Path.GetFileName(FileName);
                    _watcher.EnableRaisingEvents = true;
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
        }

        /// <summary>
        /// Stops the file observing.
        /// </summary>
        public void Stop()
        {
            if (FileName != null)
            {
                _lock.EnterWriteLock();
                try
                {
                    if (_watcher.EnableRaisingEvents)
                    {
                        _watcher.EnableRaisingEvents = false;
                    }
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="ConfigurationChanged"/> event.
        /// </summary>
        /// <param name="fileName">The configuration file name.</param>
        protected virtual void OnConfigurationChanged(string fileName)
        {
            var handler = ConfigurationChanged;
            if (handler != null)
            {
                handler(this, new ConfigurationChangedEventArgs(fileName));
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Indicates if the managed objects should be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_watcher != null)
                {
                    _watcher.Dispose();
                    _watcher = null;
                }
            }
        }

        /// <summary>
        /// Initializes the watcher for the file specified.
        /// </summary>
        /// <param name="fileName">The configuration file name.</param>
        private void Initialize(string fileName)
        {
            FileName = fileName;

            _watcher.IncludeSubdirectories = false;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Changed += (sender, args) => OnConfigurationChanged(FileName);
        }
    }
}