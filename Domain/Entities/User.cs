using Domain.Common.Enums;
using Domain.Common.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : RecordBase
    {
        [Required]
        [StringLength(15)]
        public string? UserName { get; set; }

		[Required]
		[StringLength(10)]
		public string? Password { get; set; }

        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
