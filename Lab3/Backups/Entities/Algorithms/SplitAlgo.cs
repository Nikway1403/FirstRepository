using Backups.Entities.PathWrapper;
using Backups.Interfaces;

namespace Backups.Entities.Algorithms;

public class SplitAlgo : IAlgorithm
{
    private static int counter = 1;
    public IEnumerable<Storage> Run(IEnumerable<BackupObject> backupObjects)
    {
        return backupObjects.Select(obj => new Storage($"Storage{counter++}", ".zip", new List<BackupObject> { obj }));
    }
}