using System;
using System.Collections.Generic;
using Assets.Sources.Core.Infrastructure;

namespace Assets.Sources.Core.Factory
{
    /// <summary>
    /// 单例对象
    /// </summary>
    public class SingletonObjectFactory : IObjectFactory
    {
        /// <summary>
        /// 共享的字典，不会因为不同的SingletonObjectFactory对象返回不唯一的实例对象
        /// </summary>
        private static Dictionary<Type,object> _cachedObjects;
        private static readonly object _lock = new object();

        private static Dictionary<Type, object> CachedObjects
        {
            get
            {
                lock (_lock)
                {
                    return _cachedObjects ??= new Dictionary<Type, object>();
                }
            }
        }

        public object AcquireObject(string className)
        {
            return AcquireObject(TypeFinder.ResolveType(className));
        }

        public object AcquireObject(Type type)
        {
            if (CachedObjects.ContainsKey(type))
            {
                return CachedObjects[type];
            }

            lock (_lock)
            {
                CachedObjects.Add(type, Activator.CreateInstance(type,false));
                return CachedObjects[type];
            }
        }

        public object AcquireObject<TInstance>() where TInstance : class, new()
        {
            var type = typeof(TInstance);
            if (CachedObjects.ContainsKey(type))
            {
                return CachedObjects[type];
            }

            lock (_lock)
            {
                var instance=new TInstance();
                CachedObjects.Add(type, instance);
                return CachedObjects[type];
            }
        }

        public void ReleaseObject(object obj)
        {
        }
    }
}
