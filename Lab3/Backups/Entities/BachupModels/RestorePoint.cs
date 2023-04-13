using Backups.Entities.PathWrapper;

namespace Backups.Entities.BachupModels;

public class RestorePoint
{
    private readonly List<Storage> _storages;

    public RestorePoint(DateTime dateTime)
    {
        _storages = new List<Storage>();
        Date = dateTime;
    }

    public DateTime Date { get; }

    public IEnumerable<Storage> Storages => _storages;

    public void AddStorage(Storage storage)
    {
        ArgumentNullException.ThrowIfNull(storage);
        _storages.Add(storage);
    }

    public void RemoveStorage(Storage storage)
    {
        ArgumentNullException.ThrowIfNull(storage);
        _storages.Remove(storage);
    }
}