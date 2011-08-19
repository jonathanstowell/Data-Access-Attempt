using System;

namespace DataAccess.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public Person Creator { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
