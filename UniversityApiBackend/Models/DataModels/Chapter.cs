using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        [ForeignKey("Course")]
        public int CurseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string List = string.Empty;    
    }
}
    