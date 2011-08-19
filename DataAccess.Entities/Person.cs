using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Person()
        {
        }
    }
}
