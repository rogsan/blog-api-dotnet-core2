using System;

namespace blog_api_dotnet_core2.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public String Name { get; set; }
    }
}