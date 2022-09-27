using Assets.Sources.Core.Infrastructure;

namespace Assets.Sources.Core.HTTP
{
    public class HttpTool : Singleton<HttpTool>
    {
        // 无法在外界使用构造函数，确保Singleton
        protected HttpTool() { }
    }
}
