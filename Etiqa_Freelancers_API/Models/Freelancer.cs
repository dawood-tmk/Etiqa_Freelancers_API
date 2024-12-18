using System.ComponentModel.DataAnnotations;

namespace Etiqa_Freelancers_API.Models
{
    public class Freelancer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public bool Archived { get; set; } = false;

        public ICollection<Skillset> Skillsets { get; set; } = new List<Skillset>();
        public ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();


    }
}
