﻿using System;
using System.Collections.Generic;
using System.IO;
using Assets.Sources.Core.Infrastructure;

namespace Assets.Sources.Core.Repository
{
    public class FileSystemRepository<T> : IRepository<T> where T : class, new()
    {
        public string DataDirectory { get; private set; }
        protected ISerializer Serializer { get; set; }

        public FileSystemRepository(string pathToDataDirectory, ISerializer serializer = null)
        {
            DataDirectory = Path.Combine(pathToDataDirectory, typeof(T).Name);
            Serializer = serializer ?? SerializerXml.Instance;
            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }
        }

        public void Insert(T instance)
        {
            try
            {
                var filename = GetFilename(Guid.NewGuid());
                if (File.Exists(filename))
                {
                    throw new Exception("Attempting to insert an object which already exists. Filename=" + filename);
                }

                var serializedObject = Serializer.Serialize<T>(instance, true);
                using (var stream = new StreamWriter(filename))
                {
                    stream.Write(serializedObject);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
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

        private string GetFilename(object key)
        {
            return Path.Combine(DataDirectory, $"{key.ToString()}.{".xml"}");
        }
    }
}
