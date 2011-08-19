using System;
using System.Data;
using DataAccess.ColumnProvider.Abstract;
using DataAccess.Core.Concrete.Mapping;
using DataAccess.Entities;

namespace DataAccess.Mapping.Mappers
{
    public class PersonMapper : MapperBase<Person>
    {
        private readonly IPersonColumnProvider _columnProvider;

        public PersonMapper(IPersonColumnProvider columnProvider)
        {
            _columnProvider = columnProvider;
        }

        protected override Person Map(IDataRecord record)
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
    }
}
