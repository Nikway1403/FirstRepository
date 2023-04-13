using System.IO.Compression;
using Backups.Entities.PathWrapper;
using Backups.Interfaces;
using Zio;
using Zio.FileSystems;

namespace Backups.Entities.Repositories;

public class MemoryRepository : IRepository
{
    public MemoryRepository()
    {
        FileSystem = new MemoryFileSystem();
    }

    public UPath RepoPath { get; private set; }
    public IFileSystem FileSystem { get; }

    public void SetRepo(UPath path)
    {
        if (!FileSystem.DirectoryExists(path))
        {
            throw new Exception("invalid path for repo");
        }

        RepoPath = path;
    }

    public bool IsDirectory(string path)
    {
        return FileSystem.DirectoryExists(path);
    }

    public bool IsFile(string path)
    {
        return FileSystem.FileExists(path);
    }

    public void Archive(Storage storage)
    {
        Stream archiveStream = FileSystem.OpenFile(UPath.Combine(RepoPath, storage.FullName), FileMode.OpenOrCreate, FileAccess.ReadWrite);
        var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create);
        var backupObjects = storage.BackupObjects.ToList();
        foreach (BackupObject obj in backupObjects)
        {
            if (FileSystem.FileExists(obj.Path))
            {
                Stream fileStream = FileSystem.OpenFile(obj.Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Stream archiveEntry = archive
                    .CreateEntry(Path.GetFileName(obj.Path)).Open();
                fileStream.CopyTo(archiveEntry);
                archiveEntry.Dispose();
            }
            else if (FileSystem.DirectoryExists(obj.Path))
            {
                using Stream archiveEntry = archive
                    .CreateEntry(Path.GetFileName(obj.Path) + ".zip").Open();
                var insideArchive = new ZipArchive(archiveEntry, ZipArchiveMode.Create);
                foreach (UPath path in FileSystem.EnumerateFiles(obj.Path))
                {
                    using Stream fileStream = FileSystem.OpenFile(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    using Stream insideArchiveEntry = insideArchive
                        .CreateEntry(Path.GetFileName(path.FullName)).Open();
                    fileStream.CopyTo(insideArchiveEntry);
                }

                archiveEntry.Dispose();
            }
            else
            {
                throw new Exception("invalid path of backup object");
            }
        }
    }
}