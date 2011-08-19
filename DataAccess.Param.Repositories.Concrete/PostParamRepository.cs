using System;
using System.Data;
using System.Data.SqlClient;
using DataAccess.ColumnProvider.Abstract;
using DataAccess.Param.Helpers.Abstract;
using DataAccess.Param.Repositories.Abstract;

namespace DataAccess.Param.Repositories.Concrete
{
    public class PostParamRepository : IPostParamRepository
    {
        private readonly IPostColumnProvider _columnProvider;
        private readonly IDataParamHelper _dataParamHelper;

        public PostParamRepository(IPostColumnProvider columnProvider, IDataParamHelper dataParamHelper)
        {
            _columnProvider = columnProvider;
            _dataParamHelper = dataParamHelper;
        }

        public IDataParameter GetPostIdParam(int id)
        {
            return _dataParamHelper.BuildDataParameter(DbType.Int32, _columnProvider.PostId, id);
        }

        public IDataParameter GetCreatorIdParam(int id)
        {
            return _dataParamHelper.BuildDataParameter(DbType.Int32, _columnProvider.CreatorId, id);
        }

        public IDataParameter GetContentParam(string content)
        {
            return _dataParamHelper.BuildDataParameter(DbType.String, _columnProvider.Content, content);
        }

        public IDataParameter GetCreatedDateTimeParam(DateTime createdDateTime)
        {
            return _dataParamHelper.BuildDataParameter(DbType.DateTime, _columnProvider.CreatedDateTime, createdDateTime);
        }
    }
}
