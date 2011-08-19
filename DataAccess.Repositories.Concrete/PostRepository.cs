using System.Collections.Generic;
using System.Data;
using DataAccess.Core.Abstract;
using DataAccess.Core.Concrete.Infrastructure;
using DataAccess.Entities.Concrete;
using DataAccess.ParamCollection.Repositories.Abstract;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Concrete
{
    public class PostRepository  : ObjectKeyReaderBase<Post>, IPostRepository
    {
        private IPostParamCollectionRepository _paramCollectionRepository;

        public PostRepository(IDatabaseFactory databaseFactory, IMapper<Post> mapper, IPostParamCollectionRepository paramCollectionRepository)
            : base(databaseFactory, mapper)
        {
            _paramCollectionRepository = paramCollectionRepository;
        }

        public override ICollection<Post> GetAll()
        {
            return ExecuteCollection(CommandType.StoredProcedure, "GetAllPosts");
        }

        public override Post GetById(int id)
        {
            ICollection<IDataParameter> collection = _paramCollectionRepository.GetPostIdParamCollection(id);
            return ExecuteSingle(CommandType.StoredProcedure, "GetPostById", collection);
        }

        public override bool Add(Post item)
        {
            ICollection<IDataParameter> collection =
                _paramCollectionRepository.GetCreatorIdContentCreatedDateTimeParamCollection(item.Creator.PersonId,
                                                                                item.Content,
                                                                                item.CreatedDateTime);

            return ExecuteWrite(CommandType.StoredProcedure, "AddPost", collection);
        }

        public override bool Update(Post item)
        {
            ICollection<IDataParameter> collection =
                _paramCollectionRepository.GetPostIdFirstNameLastNameEmailParamCollection(item.PostId,
                                                                                        item.Creator.PersonId,
                                                                                        item.Content,
                                                                                        item.CreatedDateTime);

            return ExecuteWrite(CommandType.StoredProcedure, "UpdatePost", collection);
        }

        public override bool Delete(Post item)
        {
            ICollection<IDataParameter> collection = _paramCollectionRepository.GetPostIdParamCollection(item.PostId);
            return ExecuteWrite(CommandType.StoredProcedure, "DeletePost", collection);
        }
    }
}
