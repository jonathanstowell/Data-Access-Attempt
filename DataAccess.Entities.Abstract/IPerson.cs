using System.Collections.Generic;

namespace DataAccess.Entities.Abstract
{
    public interface IPerson
    {
        int PersonId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        ICollection<IPost> Posts { get; set; }
    }
}