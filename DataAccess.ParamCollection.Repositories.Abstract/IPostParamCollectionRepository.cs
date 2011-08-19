using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.ParamCollection.Repositories.Abstract
{
    public interface IPostParamCollectionRepository
    {
        ICollection<IDataParameter> GetPostIdParamCollection(int id);
        ICollection<IDataParameter> GetCreatorIdContentCreatedDateTimeParamCollection(int creatorId, string content, DateTime createdDateTime);
        ICollection<IDataParameter> GetPostIdFirstNameLastNameEmailParamCollection(int id, int creatorId, string content, DateTime createdDateTime);
    }
}
