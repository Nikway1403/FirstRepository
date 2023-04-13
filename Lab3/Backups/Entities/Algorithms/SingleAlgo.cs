using Backups.Entities.PathWrapper;
using Backups.Interfaces;

namespace Backups.Entities.Algorithms;

public class SingleAlgo : IAlgorithm
{
    private static int counter = 1;

    public IEnumerable<Storage> Run(IEnumerable<BackupObject> backupObjects)
    {
        return new List<Storage> { new Storage($"Storage{counter++}", ".zip", backupObjects.ToList()) };
    }
}