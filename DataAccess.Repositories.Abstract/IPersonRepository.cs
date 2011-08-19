using DataAccess.Core.Abstract;
using DataAccess.Entities.Concrete;

namespace DataAccess.Repositories.Abstract
{
    public interface IPersonRepository : IObjectKeyReaderBase<Person>
    {
    }
}
