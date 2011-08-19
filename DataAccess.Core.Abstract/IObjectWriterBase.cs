using System.Collections.Generic;
using System.Data;

namespace DataAccess.Core.Abstract
{
    public interface IObjectWriterBase<T> : IObjectReaderBase<T> where T : new()
    {
        bool Add(T item);
        bool Add(IEnumerable<T> items);
        bool Update(T item);
        bool Update(IEnumerable<T> items);
        bool Delete(T item);
        bool Delete(IEnumerable<T> items);
        IUnitOfWork UnitOfWork { get; }
        bool ExecuteWrite(CommandType commandType, string commandText);
        bool ExecuteWrite(CommandType commandType, string commandText, ICollection<IDataParameter> parameters);
    }
}
