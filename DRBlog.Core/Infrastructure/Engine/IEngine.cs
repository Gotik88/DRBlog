using System;
using DRBlog.Core.Infrastructure.Engine.Managers;
using DRBlog.Core.Infrastructure.DependencyInjection;

namespace DRBlog.Core.Infrastructure.Engine
{
    public interface IEngine
    {
        IoCContainerManager ContainerManager { get; }
        DataBaseManager DataBaseManager { get; }
        ConfigurationManager ConfigurationManager { get; }

        void Initialize();
    }
}
