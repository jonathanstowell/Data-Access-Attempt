using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using DataAccess.ColumnProvider.Abstract;
using DataAccess.Core.Abstract;
using DataAccess.Core.Concrete.Mapping;
using DataAccess.Entities.Concrete;

namespace DataAccess.Mapping.Concrete
{
    public class PersonMapper : MapperBase<Person>
    {
        private readonly IMapper<Post> _postMapper;
        private readonly IPersonColumnProvider _columnProvider;
        private readonly IPostColumnProvider _postColumnProvider;

        public PersonMapper(IPersonColumnProvider columnProvider)
        {
            _columnProvider = columnProvider;
        }

        public PersonMapper(IPersonColumnProvider columnProvider, IPostColumnProvider postColumnProvider, IMapper<Post> postMapper)
        {
            _columnProvider = columnProvider;
            _postColumnProvider = postColumnProvider;
            _postMapper = postMapper;
        }

        public override Person Map(IDataRecord record)
        {
            try
            {
                Person p = new Person();

                p.PersonId = (DBNull.Value == record[_columnProvider.PersonID]) ? 0 : (int)record[_columnProvider.PersonID];
                p.FirstName = (DBNull.Value == record[_columnProvider.FirstName]) ? string.Empty : (string)record[_columnProvider.FirstName];
                p.LastName = (DBNull.Value == record[_columnProvider.LastName]) ? string.Empty : (string)record[_columnProvider.LastName];
                p.Email = (DBNull.Value == record[_columnProvider.Email]) ? string.Empty : (string)record[_columnProvider.Email];

                return p;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override ICollection<Person> MapCollection(IDataReader reader)
        {
            ICollection<Person> collection = new Collection<Person>();

            while (reader.Read())
            {
                try
                {
                    if (collection.Where(x => x.PersonId == (int)reader[_columnProvider.PersonID]).Count() < 1)
                        collection.Add(Map(reader));

                    if (!(DBNull.Value == reader[_postColumnProvider.PostId]))
                    {
                        Person p = collection.SingleOrDefault(x => x.PersonId == (int)reader[_columnProvider.PersonID]);
                        p.AddPost(_postMapper.Map(reader));
                    }
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
