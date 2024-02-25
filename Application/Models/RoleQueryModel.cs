using Domain.Common.Records.Bases;
using System.ComponentModel;

namespace Application.Models
{
    public class RoleQueryModel : RecordBase
    {
        [DisplayName("Role Name")]
        public string? Name { get; set; }

        [DisplayName("User Count")]
        public int UserCount { get; set; }

        public string? Users { get; set; }
    }
}
