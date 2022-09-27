using System;
using System.Collections.Generic;
using Assets.Sources.Core.Infrastructure;
using UnityEngine;

namespace Assets.Sources.Core.Repository
{
    public class PlayerPrefsRepository<T> : IRepository<T> where T : class, new()
    {
        protected ISerializer Serializer { get; set; }
        protected string KeysIndexName { get; set; }

        private List<object> keysIndex;
        private List<object> KeysIndex => keysIndex ?? (keysIndex = LoadIndex());

        public PlayerPrefsRepository(ISerializer serializer = null)
        {
            KeysIndexName = GetKeyPath("KeysIndex");
            Serializer = serializer ?? SerializerXml.Instance;
        }

        public void Insert(T instance)
        {
            try
            {
                var serializedObject = Serializer.Serialize<T>(instance, true);
                PlayerPrefs.SetString(KeysIndexName, serializedObject);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
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
            throw new NotImplementedException();
        }

        private static string GetKeyPath(object key)
        {
            return $"{typeof(T).Name}/{key.ToString()}";
        }

        private List<object> LoadIndex()
        {
            if (PlayerPrefs.HasKey(KeysIndexName))
            {
                var serializeObject = PlayerPrefs.GetString(KeysIndexName);
                return Serializer.Deserialize<List<object>>(serializeObject);
            }
            else
            {
                return new List<object>();
            }
        }

        private void SaveIndex()
        {
            var serializedObject = Serializer.Serialize<List<object>>(KeysIndex, true);
            PlayerPrefs.SetString(KeysIndexName, serializedObject);
        }
    }
}
