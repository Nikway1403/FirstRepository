using Backups.Entities.Algorithms;
using Backups.Entities.PathWrapper;
using Backups.Entities.Repositories;
using Backups.Task;
using Xunit;
using Zio;

namespace Backups.Test;

public class BackupTest
{
    /*[Fact]
    public void Test()
    {
        var repo = new LocalRepository(@"C:\Users\babas\Desktop\Repo");

        // var alg = new SingleAlgo();
        var alg = new SplitAlgo();
        var task = new BackupTask(repo, alg);
        task.AddBackupObject(new BackupObject(@"C:\Users\babas\Desktop\file.txt"));
        task.AddBackupObject(new BackupObject(@"C:\Users\babas\Desktop\filefile"));
        task.AddBackupObject(new BackupObject(@"C:\Users\babas\Desktop\musicfile.mp4"));
        task.AddBackupObject(new BackupObject(@"C:\Users\babas\Desktop\file"));
        task.AddBackupObject(new BackupObject(@"C:\Users\babas\Desktop\file1"));
        task.Execute();
    }*/

    [Fact]
    public void Test2()
    {
        var repo = new MemoryRepository();
        IFileSystem fs = repo.FileSystem;
        fs.CreateDirectory("/mnt/c/repository");
        repo.SetRepo("/mnt/c/repository");
        fs.CreateDirectory("/mnt/c/testDir");
        fs.CreateFile("/mnt/c/testDir/testFile1.txt").Dispose();
        fs.CreateFile("/mnt/c/testDir/testFile2.txt").Dispose();
        var alg = new SingleAlgo();
        var task = new BackupTask(repo, alg);
        task.AddBackupObject(new BackupObject("/mnt/c/testDir"));
        task.AddBackupObject(new BackupObject("/mnt/c/testDir/testFile1.txt"));
        task.AddBackupObject(new BackupObject("/mnt/c/testDir/testFile2.txt"));
        task.Execute();
    }
}