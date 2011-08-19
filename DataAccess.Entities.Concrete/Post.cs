using System;
using DataAccess.Entities.Abstract;

namespace DataAccess.Entities.Concrete
{
    public class Post : IPost
    {
        public int PostId { get; set; }
        public IPerson Creator { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
