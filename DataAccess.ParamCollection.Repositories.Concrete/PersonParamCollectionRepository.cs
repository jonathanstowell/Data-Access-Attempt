using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using DataAccess.Param.Repositories.Abstract;
using DataAccess.ParamCollection.Repositories.Abstract;

namespace DataAccess.Repositories.Concrete
{
    public class PersonParamCollectionRepository : IPersonParamCollectionRepository
    {
        private IPersonParamRepository _paramRepository;

        public PersonParamCollectionRepository(IPersonParamRepository paramRepository)
        {
            _paramRepository = paramRepository;
        }

        public ICollection<IDataParameter> GetPersonIdParamCollection(int id)
        {
            ICollection<IDataParameter> collection = new Collection<IDataParameter>();
            collection.Add(_paramRepository.GetPersonIdParam(id));

            return collection;
        }

        public ICollection<IDataParameter> GetFirstNameLastNameEmailParamCollection(string firstName, string lastName, string email)
        {
            ICollection<IDataParameter> collection = new Collection<IDataParameter>();

            collection.Add(_paramRepository.GetEmailParam(email));
            collection.Add(_paramRepository.GetFirstNameParam(firstName));
            collection.Add(_paramRepository.GetLastNameParam(lastName));

            return collection;
        }

        public ICollection<IDataParameter> GetPersonIdFirstNameLastNameEmailParamCollection(int id, string firstName, string lastName, string email)
        {
            ICollection<IDataParameter> collection = new Collection<IDataParameter>();

            collection.Add(_paramRepository.GetPersonIdParam(id));
            collection.Add(_paramRepository.GetEmailParam(email));
            collection.Add(_paramRepository.GetFirstNameParam(firstName));
            collection.Add(_paramRepository.GetLastNameParam(lastName));

            return collection;
        }
    }
}
