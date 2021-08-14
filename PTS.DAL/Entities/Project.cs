using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.DAL.Entities
{
	public class Project
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
		public string Description { get; set; }

		[Required]
		[Column(Order = 4)]
		public int CompanyId { get; set; }

		public virtual Company Company { get; set; }

		public virtual ICollection<User> WorkingHours { get; set;}

		public Project()
		{
			WorkingHours = new Collection<User>();
		}
	}
}
