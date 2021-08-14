using PTS.BLL.DTOs.Company;

namespace PTS.BLL.DTOs.Project
{
	public class ProjectDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int CompanyId { get; set; }

		public CompanyDTO Company { get; set; }
	}
}
