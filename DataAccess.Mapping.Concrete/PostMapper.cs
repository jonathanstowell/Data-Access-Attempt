using System;
using System.Data;
using DataAccess.ColumnProvider.Abstract;
using DataAccess.Core.Abstract;
using DataAccess.Core.Concrete.Mapping;
using DataAccess.Entities.Concrete;

namespace DataAccess.Mapping.Concrete
{
    public class PostMapper : MapperBase<Post>
    {
        private readonly IMapper<Person> _personMapper;
        private readonly IPostColumnProvider _columnProvider;

        public PostMapper(IPostColumnProvider columnProvider)
        {
            _columnProvider = columnProvider;
        }

        public PostMapper(IPostColumnProvider columnProvider, IMapper<Person> personMapper)
        {
            _columnProvider = columnProvider;
            _personMapper = personMapper;
        }

        public override Post Map(IDataRecord record)
        {
            try
            {
                Post p = new Post();

                p.PostId = (DBNull.Value == record[_columnProvider.PostId]) ? 0 : (int)record[_columnProvider.PostId];
                p.Content = (DBNull.Value == record[_columnProvider.Content]) ? string.Empty : (string)record[_columnProvider.Content];
                p.CreatedDateTime = (DBNull.Value == record[_columnProvider.CreatedDateTime]) ? new DateTime() : (DateTime)record[_columnProvider.CreatedDateTime];
                
                if (_personMapper != null)
                    p.Creator = _personMapper.Map(record);

                return p;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
