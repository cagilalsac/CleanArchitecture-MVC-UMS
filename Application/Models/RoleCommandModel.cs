using Domain.Common.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class RoleCommandModel : RecordBase
    {
        [DisplayName("Role Name")]
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(20, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? Name { get; set; }
    }
}
