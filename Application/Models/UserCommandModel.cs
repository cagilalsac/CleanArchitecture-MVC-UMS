using Domain.Common.Enums;
using Domain.Common.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UserCommandModel : RecordBase
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} must have minimum {2} maximum {1} characters!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3, ErrorMessage = "{0} must have minimum {1} characters!")]
        [MaxLength(10, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? Password { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Birth Date")]
        [Required(ErrorMessage = "{0} is required!")]
        public DateTime? BirthDate { get; set; }

        public Sex Sex { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "{0} is required!")]
        public int? RoleId { get; set; }
    }
}
