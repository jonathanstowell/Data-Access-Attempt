using System.Collections.Generic;
using System.Data;

namespace DataAccess.ParamCollection.Repositories.Abstract
{
    public interface IPersonParamCollectionRepository
    {
        ICollection<IDataParameter> GetPersonIdParamCollection(int id);
        ICollection<IDataParameter> GetFirstNameLastNameEmailParamCollection(string firstName, string lastName, string email);
        ICollection<IDataParameter> GetPersonIdFirstNameLastNameEmailParamCollection(int id, string firstName, string lastName, string email);
    }
}
