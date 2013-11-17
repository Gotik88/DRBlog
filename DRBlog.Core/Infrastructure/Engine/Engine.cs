namespace DRBlog.Core.Infrastructure.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DRBlog.Core.Infrastructure.DependencyInjection;
    using DRBlog.Core.Infrastructure.Engine.Managers;

    public class Engine : IEngine
    {
        private IoCContainerManager _containerManager;
        private ConfigurationManager _configurationManager;
        private DataBaseManager _dataBaseManager;

        #region Properties

        public IoCContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        public ConfigurationManager ConfigurationManager
        {
            get { return _configurationManager; }
        }

        public DataBaseManager DataBaseManager
        {
            get { return _dataBaseManager; }
        }

        #endregion

        public void Initialize()
        {
            InitializeConfigurations();
            InitializeContainer();
        }

        private void InitializeConfigurations()
        {
        }

        private void InitializeContainer()
        {
            var container = IoCContainerFactory.CreateContainer(IoCContainerType.Autofac);
            _containerManager = new IoCContainerManager(container);
        }      
    }
}
