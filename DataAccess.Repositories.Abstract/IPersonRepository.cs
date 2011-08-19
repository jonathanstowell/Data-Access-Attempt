using DataAccess.Core.Abstract;
using DataAccess.Entities;

namespace DataAccess.Repositories.Abstract
{
    public interface IPersonRepository : IObjectKeyReaderBase<Person>
    {
    }
}
