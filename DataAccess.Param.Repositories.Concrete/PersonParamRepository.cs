using System.Data;
using DataAccess.ColumnProvider.Abstract;
using DataAccess.Param.Helpers.Abstract;
using DataAccess.Param.Repositories.Abstract;

namespace DataAccess.Param.Repositories.Concrete
{
    public class PersonParamRepository : IPersonParamRepository
    {
        private readonly IPersonColumnProvider _columnProvider;
        private readonly IDataParamHelper _dataParamHelper;

        public PersonParamRepository(IPersonColumnProvider columnProvider, IDataParamHelper dataParamHelper)
        {
            _columnProvider = columnProvider;
            _dataParamHelper = dataParamHelper;
        }

        public IDataParameter GetPersonIdParam(int id)
        {
            return _dataParamHelper.BuildDataParameter(DbType.Int32, _columnProvider.PersonID, id);
        }

        public IDataParameter GetFirstNameParam(string firstName)
        {
            return _dataParamHelper.BuildDataParameter(DbType.String, _columnProvider.FirstName, firstName);
        }

        public IDataParameter GetLastNameParam(string lastName)
        {
            return _dataParamHelper.BuildDataParameter(DbType.String, _columnProvider.LastName, lastName);
        }

        public IDataParameter GetEmailParam(string email)
        {
            return _dataParamHelper.BuildDataParameter(DbType.String, _columnProvider.Email, email);
        }
    }
}
