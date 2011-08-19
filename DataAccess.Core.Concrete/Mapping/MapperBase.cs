using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using DataAccess.Core.Abstract;

namespace DataAccess.Core.Concrete.Mapping
{
    public abstract class MapperBase<T> : IMapper<T> where T : class, new() 
    {
        public abstract T Map(IDataRecord record);

        public T MapSingle(IDataReader reader)
        {
            T item = new T();

            while (reader.Read())
            {
                item = Map(reader);
            }

            return item;
        }

        public ICollection<T> MapCollection(IDataReader reader)
        {
            ICollection<T> collection = new Collection<T>();

            while (reader.Read())
            {
                try
                {
                    collection.Add(Map(reader));
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            return collection;
        }
    }
}
