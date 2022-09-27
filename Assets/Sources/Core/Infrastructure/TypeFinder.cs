using System;
using System.Linq;
using System.Reflection;

namespace Assets.Sources.Core.Infrastructure
{
    public class TypeFinder
    {
        /// <summary>
        /// 根据class name反射获取Type
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static Type ResolveType(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == className);
            if (type == null)
            {
                throw new Exception($"Can't find Class by class name:'{className}'");
            }

            return type;
        }
    }
}
