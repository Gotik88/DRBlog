using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DRBlog.Core.Infrastructure.Interception.Behaviors
{
    class CachingInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input,
        GetNextInterceptionBehaviorDelegate getNext)
        {
            // Before invoking the method on the original target.
            if (input.MethodBase.Name == "GetTenant")
            {
                var tenantName = input.Arguments["tenant"].ToString();
                if (IsInCache(tenantName))
                {
                    return input.CreateMethodReturn(
                    FetchFromCache(tenantName));
                }
            }
            IMethodReturn result = getNext()(input, getNext);
            // After invoking the method on the original target.
            if (input.MethodBase.Name == "SaveTenant")
            {
                AddToCache(input.Arguments["tenant"]);
            }
            return result;
        }
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public bool WillExecute
        {
            get { return true; }
        }
        private bool IsInCache(string key)
        {
            return true;
        }
        private object FetchFromCache(string key)
        {
            return null;
        }

        private void AddToCache(object item)
        {

        }
    }
}
