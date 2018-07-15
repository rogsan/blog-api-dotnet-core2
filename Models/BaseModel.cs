using System;
using System.ComponentModel.DataAnnotations;

namespace blog_api_dotnet_core2.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public String CreatedBy { get; set; }

        public Boolean IsDeleted { get; set; }
    }
}