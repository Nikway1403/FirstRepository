using Backups.Entities.BachupModels;
using Backups.Entities.PathWrapper;
using Backups.Interfaces;

namespace Backups.Task;

public class BackupTask
{
    private readonly List<BackupObject> _backupObjects = new List<BackupObject>();

    public BackupTask(IRepository repository, IAlgorithm algorithm)
    {
        ArgumentNullException.ThrowIfNull(repository);
        ArgumentNullException.ThrowIfNull(algorithm);
        Repository = repository;
        Algorithm = algorithm;
    }

    public IEnumerable<BackupObject> BackupObjects => _backupObjects;

    public IRepository Repository { get; }

    public IAlgorithm Algorithm { get; }

    public Backup Backup { get; } = new Backup();

    public void AddBackupObject(BackupObject backupObject)
    {
        ArgumentNullException.ThrowIfNull(backupObject);
        if (!Repository.IsDirectory(backupObject.Path) && !Repository.IsFile(backupObject.Path))
        {
            throw new Exception("no such file");
        }

        _backupObjects.Add(backupObject);
    }

    public void Execute()
    {
        var storages = Algorithm.Run(_backupObjects).ToList();
        foreach (Storage storage in storages)
        {
            Repository.Archive(storage);
        }

        var rp = new RestorePoint(DateTime.Now);
        foreach (Storage storage in storages)
        {
            rp.AddStorage(storage);
        }
    }
}