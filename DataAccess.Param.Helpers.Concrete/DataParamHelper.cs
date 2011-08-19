using System;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Param.Helpers.Abstract;

namespace DataAccess.Param.Helpers.Concrete
{
    public class DataParamHelper : IDataParamHelper
    {
        public IDataParameter BuildDataParameter(DbType dataType, string parameterName, object value)
        {
            IDataParameter param = new SqlParameter();
            param.DbType = dataType;
            param.Value = value ?? DBNull.Value;
            param.ParameterName = parameterName;
            return param;
        }
    }
}
