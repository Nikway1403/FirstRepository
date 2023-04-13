namespace Backups.Entities.BachupModels;

public class Backup
{
    private readonly List<RestorePoint> _restorePoints;

    public Backup()
    {
        _restorePoints = new List<RestorePoint>();
    }

    public IEnumerable<RestorePoint> RestorePoints => _restorePoints;

    public void AddRestorePoint(RestorePoint restorePoint)
    {
        ArgumentNullException.ThrowIfNull(restorePoint);
        _restorePoints.Add(restorePoint);
    }

    public void RemoveRestorePoint(RestorePoint restorePoint)
    {
        ArgumentNullException.ThrowIfNull(restorePoint);
        _restorePoints.Remove(restorePoint);
    }
}