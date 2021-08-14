using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.BLL.Services.Interfaces
{
	public interface IBackupService
	{
		string BackupsFolder { get; }

		IEnumerable<string> FindAllBackupsFileNames();

		Task<string> CreateBackupAsync();

		Task ApplyBackup(string backupFileName);
	}
}
