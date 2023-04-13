using System.IO.Compression;
using Backups.Entities.PathWrapper;
using Backups.Interfaces;

namespace Backups.Entities.Repositories;

public class LocalRepository : IRepository
{
    public LocalRepository(string repoPath)
    {
        RepoPath = repoPath;
    }

    public string RepoPath { get; }

    public bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public bool IsFile(string path)
    {
        return File.Exists(path);
    }

    public void Archive(Storage storage)
    {
        string s = Path.Combine(RepoPath, storage.Name);
        Directory.CreateDirectory(s);
        var backupObjects = storage.BackupObjects.ToList();
        foreach (BackupObject obj in backupObjects)
        {
            if (IsFile(obj.Path))
            {
                File.Copy(obj.Path, Path.Combine(s, Path.GetFileName(obj.Path)));
                continue;
            }

            Directory.CreateDirectory(Path.Combine(s, Path.GetFileName(obj.Path)));
            foreach (string dirPath in Directory.GetDirectories(obj.Path, "*", SearchOption.AllDirectories))
            {
                string newDirPath = dirPath.Replace(obj.Path, Path.Combine(s, Path.GetFileName(obj.Path)));
                Directory.CreateDirectory(newDirPath);
            }

            foreach (string filePath in Directory.GetFiles(obj.Path, "*.*", SearchOption.AllDirectories))
            {
                string newFilePath = filePath.Replace(obj.Path, Path.Combine(s, Path.GetFileName(obj.Path)));
                File.Copy(filePath, newFilePath);
            }
        }

        ZipFile.CreateFromDirectory(s, Path.Combine(RepoPath, storage.FullName));
        Directory.Delete(s, true);
    }
}