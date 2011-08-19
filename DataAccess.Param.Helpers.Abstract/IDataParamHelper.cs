using System.Data;

namespace DataAccess.Param.Helpers.Abstract
{
    public interface IDataParamHelper
    {
        IDataParameter BuildDataParameter(DbType dataType, string parameterName, object value);
    }
}
