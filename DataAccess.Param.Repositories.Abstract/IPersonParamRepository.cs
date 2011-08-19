using System.Data;

namespace DataAccess.Param.Repositories.Abstract
{
    public interface IPersonParamRepository
    {
        IDataParameter GetPersonIdParam(int id);
        IDataParameter GetFirstNameParam(string firstName);
        IDataParameter GetLastNameParam(string lastName);
        IDataParameter GetEmailParam(string email);
    }
}
