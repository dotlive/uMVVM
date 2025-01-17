﻿using System;
using System.Collections.Generic;
using Assets.Sources.Core.Factory;

namespace Assets.Sources.Core.Inject
{
    public class ServiceLocator
    {
        private static readonly SingletonObjectFactory _singletonObjectFactory=new SingletonObjectFactory();
        private static readonly TransientObjectFactory _transientObjectFactory=new TransientObjectFactory();
        private static readonly Dictionary<Type, Func<object>> Container = new Dictionary<Type, Func<object>>();

        /// <summary>
        /// 对每一次请求，只返回唯一的实例
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TInstance"></typeparam>
        public static void RegisterSingleton<TInterface, TInstance>() where TInstance : class, new()
        {
            Container.Add(typeof(TInterface), Lazy<TInstance>(FactoryType.Singleton));
        }

        /// <summary>
        /// 对每一次请求，只返回唯一的实例
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        public static void RegisterSingleton<TInstance>() where TInstance : class, new()
        {
            Container.Add(typeof(TInstance), Lazy<TInstance>(FactoryType.Singleton));
        }

        /// <summary>
        /// 对每一次请求，返回不同的实例
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TInstance"></typeparam>
        public static void RegisterTransient<TInterface, TInstance>() where TInstance : class, new()
        {
            Container.Add(typeof(TInterface),Lazy<TInstance>(FactoryType.Transient));
        }

        /// <summary>
        /// 对每一次请求，返回不同的实例
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        public static void RegisterTransient<TInstance>() where TInstance : class, new()
        {
            Container.Add(typeof(TInstance),Lazy<TInstance>(FactoryType.Transient));
        }

        /// <summary>
        /// 清空容器
        /// </summary>
        public static void Clear()
        {
            Container.Clear();
        }

        /// <summary>
        /// 从容器中获取一个实例
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public static TInterface Resolve<TInterface>() where TInterface : class
        {
            return Resolve(typeof(TInterface)) as TInterface;
        }

        /// <summary>
        /// 从容器中获取一个实例
        /// </summary>
        /// <returns></returns>
        private static object Resolve(Type type)
        {
            return !Container.ContainsKey(type) ? null : Container[type]();
        }

        private static Func<object> Lazy<TInstance>(FactoryType factoryType) where TInstance : class, new()
        {
            return () =>
            {
                switch (factoryType)
                {
                    case FactoryType.Singleton:
                        return _singletonObjectFactory.AcquireObject<TInstance>();
                    default:
                        return _transientObjectFactory.AcquireObject<TInstance>();
                }
            };
        }
    }
}
