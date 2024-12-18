using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etiqa_Freelancers_API.Models
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }

        public string HobbyName { get; set; }

        [ForeignKey("Freelancer")]
        public int FreelancerId { get; set; }

        //Navigation Property
        //public Freelancer Freelancer { get; set; }
    }
}
