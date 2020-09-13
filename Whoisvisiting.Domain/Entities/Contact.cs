using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whoisvisiting.Domain.Entities
{
    [Table("Contacts")]
    public class Contact : BaseEntity
    {
        [Key]
        [Column("ContactId")]
        [ScaffoldColumn(false)]
        public override int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Url]
        public string Domain { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public string Bio { get; set; }

        public string Avatar { get; set; }
        public string Title { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string Logo { get; set; }
    }
}
