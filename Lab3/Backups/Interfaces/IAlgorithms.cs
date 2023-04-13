using Backups.Entities.PathWrapper;

namespace Backups.Interfaces;

public interface IAlgorithm
{
    IEnumerable<Storage> Run(IEnumerable<BackupObject> backupObjects);
}