﻿using System;
using System.Collections.Generic;
using SQLite4Unity3d;

namespace Assets.Sources.Core.Repository
{
    public class DbRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly SQLiteConnection _connection;

        public void Insert(T instance)
        {
            try
            {
                _connection.Insert(instance);
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
    }
}
