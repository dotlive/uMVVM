using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Sources.Core.Infrastructure;
using UnityEngine;

namespace Assets.Sources.Core.Repository
{
    public class UnityResourcesRepository<T> : IRepository<T> where T : class, new()
    {
        public string DataDirectory { get; private set; }
        private ISerializer Serializer { get; set; }

        public UnityResourcesRepository(string repositoryPath, ISerializer serializer = null)
        {
            DataDirectory = Path.Combine(repositoryPath, typeof(T).Name);
            Serializer = (serializer ?? SerializerXml.Instance);
        }

        public void Insert(T instance)
        {
            throw new NotImplementedException();
        }

        public void Delete(T instance)
        {
            throw new NotImplementedException();
        }

        public void Update(T instance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select(Func<T, bool> func)
        {
            var items = new List<T>();
            try
            {
                var textAssets = Resources.LoadAll<TextAsset>(DataDirectory);
                for (var i = 0; i < textAssets.Length; i++)
                {
                    var textAsset = textAssets[i];
                    var item = Serializer.Deserialize<T>(textAsset.text);
                    items.Add(item);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return items.Where(func);
        }
    }
}
