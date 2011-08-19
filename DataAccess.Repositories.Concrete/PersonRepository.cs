using System.Collections.Generic;
using System.Data;
using DataAccess.Core.Abstract;
using DataAccess.Core.Concrete.Infrastructure;
using DataAccess.Entities;
using DataAccess.ParamCollection.Repositories.Abstract;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Concrete
{
    public class PersonRepository : ObjectKeyReaderBase<Person>, IPersonRepository
    {
        private IPersonParamCollectionRepository _paramCollectionRepository;

        public PersonRepository(IDatabaseFactory databaseFactory, IMapper<Person> mapper, IPersonParamCollectionRepository paramCollectionRepository)
            : base(databaseFactory, mapper)
        {
            _paramCollectionRepository = paramCollectionRepository;
        }

        public override ICollection<Person> GetAll()
        {
            return ExecuteCollection(CommandType.StoredProcedure, "GetAllPeople");
        }

        public override Person GetById(int id)
        {
            ICollection<IDataParameter> collection = _paramCollectionRepository.GetPersonIdParamCollection(id);
            return ExecuteSingle(CommandType.StoredProcedure, "GetPersonById", collection);
        }

        public override bool Add(Person item)
        {
            ICollection<IDataParameter> collection =
                _paramCollectionRepository.GetFirstNameLastNameEmailParamCollection(item.FirstName, 
                                                                                item.LastName,
                                                                                item.Email);

            return ExecuteWrite(CommandType.StoredProcedure, "AddPerson", collection);
        }

        public override bool Update(Person item)
        {
            ICollection<IDataParameter> collection =
                _paramCollectionRepository.GetPersonIdFirstNameLastNameEmailParamCollection(item.PersonId, 
                                                                                        item.FirstName,
                                                                                        item.LastName, 
                                                                                        item.Email);

            return ExecuteWrite(CommandType.StoredProcedure, "UpdatePerson", collection);
        }

        public override bool Delete(Person item)
        {
            ICollection<IDataParameter> collection = _paramCollectionRepository.GetPersonIdParamCollection(item.PersonId);
            return ExecuteWrite(CommandType.StoredProcedure, "DeletePerson", collection);
        }
    }
}
