using System;

namespace DRBlog.Core.Infrastructure.DependencyInjection.CastleWindsor
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
