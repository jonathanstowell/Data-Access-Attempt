using System.Collections.Generic;
using System.Data;

namespace DataAccess.Core.Abstract
{
    public interface IObjectReaderBase<T> where T : new()
    {
        IDatabaseFactory DatabaseFactory { get; }
        IDbConnection Connection { get; }
        IMapper<T> Mapper { get; }
        ICollection<T> GetAll();
        T ExecuteSingle(CommandType commandType, string commandText);
        T ExecuteSingle(CommandType commandType, string commandText, ICollection<IDataParameter> parameters);
        ICollection<T> ExecuteCollection(CommandType commandType, string commandText);
        ICollection<T> ExecuteCollection(CommandType commandType, string commandText, ICollection<IDataParameter> parameters);
    }
}