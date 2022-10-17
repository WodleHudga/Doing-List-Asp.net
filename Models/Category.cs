using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Doing_List.Models
{
    public class Category
    {
        //requrirements for the table are here
        //Key is primary key in the entity framework


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Marks Earned")]
        [Range(1,100, ErrorMessage ="Marks Cannot be More than 100")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
