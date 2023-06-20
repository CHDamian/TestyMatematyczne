using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestyMatematyczne.Models
{
    public class User : IdentityUser
    {
        [Required]
        [DefaultValue(true)]
        public bool IsTeacher { get; set; }

        public IList<Contest> Contest { get; set; }
        public ICollection<Solution>? Solution { get; set; }
    }
}
