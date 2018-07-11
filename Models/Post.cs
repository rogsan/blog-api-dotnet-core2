using System;

namespace blog_api_dotnet_core2.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public String Url { get; set; }

        public String Category { get; set; }
        public String Tags { get; set; }
        
        public String Title { get; set; }
        public String Body { get; set; }

        public DateTime CreatedAt { get; set; }
        public String CreatedBy { get; set; } 
    }
}