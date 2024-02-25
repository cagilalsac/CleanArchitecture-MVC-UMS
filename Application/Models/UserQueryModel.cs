using Domain.Common.Enums;
using Domain.Common.Records.Bases;
using System.ComponentModel;

namespace Application.Models
{
    public class UserQueryModel : RecordBase
    {
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        public string? Active { get; set; }

        [DisplayName("Birth Date")]
        public string? BirthDate { get; set; }

        public Sex Sex { get; set; }

        [DisplayName("Role")]
        public string? RoleName { get; set; }
    }
}
