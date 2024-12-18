using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etiqa_Freelancers_API.Models
{
    public class Skillset
    {
        [Key]
        public int Id { get; set; }
        public string Skill { get; set; }

        [ForeignKey("Freelancer")]
        public int FreelancerId { get; set; }

        //Navigation Property
        //public Freelancer Freelancer { get; set; }
    }
}
