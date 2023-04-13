using Backups.Entities.PathWrapper;

namespace Backups.Interfaces;

public interface IRepository
{
    bool IsDirectory(string path);
    bool IsFile(string path);
    void Archive(Storage storage);
}