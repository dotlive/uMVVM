using System.Reflection;

namespace Assets.Sources.Core.Proxy
{
    public interface IInvocationHandler
    {
        void PreProcess();
        object Invoke(object proxy, MethodInfo method, object[] args);
        void PostProcess();
    }
}
