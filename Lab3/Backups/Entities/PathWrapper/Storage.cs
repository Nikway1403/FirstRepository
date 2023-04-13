namespace Backups.Entities.PathWrapper;

public class Storage
{
    private List<BackupObject> _backupObjects;
    public Storage(string name, string extension, List<BackupObject> backupObjects)
    {
        Name = name;
        Extension = extension;
        _backupObjects = backupObjects;
    }

    public IEnumerable<BackupObject> BackupObjects => _backupObjects;
    public string Name { get; }
    public string Extension { get; }
    public string FullName => Name + Extension;
}