using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess.Entities.Abstract;

namespace DataAccess.Entities.Concrete
{
    public class Person : IPerson
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<IPost> Posts { get; set; }

        public Person()
        {
            Posts = new Collection<IPost>();
        }

        public virtual void AddPost(IPost post)
        {
            post.Creator = this;
            Posts.Add(post);
        }
    }
}
