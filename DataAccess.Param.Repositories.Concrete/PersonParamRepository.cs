using System.Data;
using System.Data.SqlClient;
using DataAccess.ColumnProvider.Abstract;
using DataAccess.Param.Repositories.Abstract;

namespace DataAccess.Param.Repositories.Concrete
{
    public class PersonParamRepository : IPersonParamRepository
    {
        private readonly IPersonColumnProvider _columnProvider;

        public PersonParamRepository(IPersonColumnProvider columnProvider)
        {
            _columnProvider = columnProvider;
        }

        public IDataParameter GetPersonIdParam(int id)
        {
            IDataParameter dataParameter = new SqlParameter();
            dataParameter.ParameterName = _columnProvider.PersonID;
            dataParameter.Value = id;
            return dataParameter;
        }

        public IDataParameter GetFirstNameParam(string firstName)
        {
            IDataParameter dataParameter = new SqlParameter();
            dataParameter.ParameterName = _columnProvider.FirstName;
            dataParameter.Value = firstName;
            return dataParameter;
        }

        public IDataParameter GetLastNameParam(string lastName)
        {
            IDataParameter dataParameter = new SqlParameter();
            dataParameter.ParameterName = _columnProvider.LastName;
            dataParameter.Value = lastName;
            return dataParameter;
        }

        public IDataParameter GetEmailParam(string email)
        {
            IDataParameter dataParameter = new SqlParameter();
            dataParameter.ParameterName = _columnProvider.Email;
            dataParameter.Value = email;
            return dataParameter;
        }
    }
}
