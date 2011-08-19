using System;
using System.Data;

namespace DataAccess.Param.Repositories.Abstract
{
    public interface IPostParamRepository
    {
        IDataParameter GetPostIdParam(int id);
        IDataParameter GetCreatorIdParam(int id);
        IDataParameter GetContentParam(string content);
        IDataParameter GetCreatedDateTimeParam(DateTime createdDateTime);
    }
}
