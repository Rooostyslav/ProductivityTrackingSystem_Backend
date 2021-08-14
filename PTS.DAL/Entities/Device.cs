using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.DAL.Entities
{
	public class Device
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Type { get; set; }

		[Required]
		[Column(Order = 4)]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string HashedPassword { get; set; }

		[Required]
		[Column(Order = 5)]
		public int UserId { get; set; }

		public virtual User User { get; set; }
	}
}
