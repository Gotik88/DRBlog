using System.Runtime.CompilerServices;

namespace DRBlog.Core.Infrastructure.Engine
{
    public class EngineContext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Singleton<IEngine>.Instance = CreateInstance();
                Singleton<IEngine>.Instance.Initialize();
            }

            return Singleton<IEngine>.Instance;
        }

        public static IEngine CreateInstance()
        {
            return new Engine();
        }

        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize();
                }

                return Singleton<IEngine>.Instance;
            }
        }
    }
}
