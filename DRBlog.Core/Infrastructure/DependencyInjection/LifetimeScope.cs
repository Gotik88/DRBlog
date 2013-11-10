using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRBlog.Core.Infrastructure.DependencyInjection.CastleWindsor;

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public class LifetimeScope<TContext> : IDisposable
    {
        public LifetimeScope()
        {
            LifetimeScopeStore.Get<TContext>().OpenScope();
        }

        public void Dispose()
        {
            LifetimeScopeStore.Get<TContext>().CloseScope();
        }
    }
}
