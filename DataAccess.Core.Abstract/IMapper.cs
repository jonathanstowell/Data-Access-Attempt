using System.Collections.Generic;
using System.Data;

namespace DataAccess.Core.Abstract
{
    public interface IMapper<T> where T : new()
    {
        T MapSingle(IDataReader reader);
        ICollection<T> MapCollection(IDataReader reader);
    }
}
