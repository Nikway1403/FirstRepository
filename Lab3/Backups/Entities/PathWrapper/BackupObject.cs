namespace Backups.Entities.PathWrapper;

public class BackupObject
{
    public BackupObject(string path)
    {
        Path = path;
    }

    public string Path { get; }
}