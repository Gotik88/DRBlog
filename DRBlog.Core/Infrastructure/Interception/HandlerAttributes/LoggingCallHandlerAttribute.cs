using DRBlog.Core.Infrastructure.Interception.CallHandlers;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DRBlog.Core.Infrastructure.Interception.HandlerAttributes
{
    class LoggingCallHandlerAttribute : HandlerAttribute
    {
        private readonly int order;
        public LoggingCallHandlerAttribute(int order)
        {
            this.order = order;
        }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LoggingCallHandler() { Order = order };
        }
    }
}
