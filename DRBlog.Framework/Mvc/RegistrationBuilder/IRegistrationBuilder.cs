using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRBlog.Core.Infrastructure.DependencyInjection.Module;

namespace DRBlog.Core.Infrastructure.DependencyInjection.RegistrationBuilder
{
    public interface IRegistrationBuilder
    {
        void RegisterModule(IIoCModule module);

        IoCContainer GetContainer { get; }
    }
}
