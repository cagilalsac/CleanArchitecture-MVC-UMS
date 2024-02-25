using Domain.Common.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Role : RecordBase
    {
		[Required]
		[StringLength(20)]
		public string? Name { get; set; }

        public List<User>? Users { get; set; }
    }
}