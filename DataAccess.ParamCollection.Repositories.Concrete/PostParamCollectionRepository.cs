using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using DataAccess.Param.Repositories.Abstract;
using DataAccess.ParamCollection.Repositories.Abstract;

namespace DataAccess.ParamCollection.Repositories.Concrete
{
    public class PostParamCollectionRepository : IPostParamCollectionRepository
    {
        private IPostParamRepository _paramRepository;

        public PostParamCollectionRepository(IPostParamRepository paramRepository)
        {
            _paramRepository = paramRepository;
        }

        public ICollection<IDataParameter> GetPostIdParamCollection(int id)
        {
            ICollection<IDataParameter> collection = new Collection<IDataParameter>();
            collection.Add(_paramRepository.GetPostIdParam(id));

            return collection;
        }

        public ICollection<IDataParameter> GetCreatorIdContentCreatedDateTimeParamCollection(int creatorId, string content, DateTime createdDateTime)
        {
            ICollection<IDataParameter> collection = new Collection<IDataParameter>();

            collection.Add(_paramRepository.GetCreatorIdParam(creatorId));
            collection.Add(_paramRepository.GetContentParam(content));
            collection.Add(_paramRepository.GetCreatedDateTimeParam(createdDateTime));

            return collection;
        }

        public ICollection<IDataParameter> GetPostIdFirstNameLastNameEmailParamCollection(int id, int creatorId, string content, DateTime createdDateTime)
        {
            ICollection<IDataParameter> collection = new Collection<IDataParameter>();

            collection.Add(_paramRepository.GetPostIdParam(id));
            collection.Add(_paramRepository.GetCreatorIdParam(creatorId));
            collection.Add(_paramRepository.GetContentParam(content));
            collection.Add(_paramRepository.GetCreatedDateTimeParam(createdDateTime));

            return collection;
        }
    }
}
