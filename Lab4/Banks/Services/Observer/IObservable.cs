using Banks.Services.Observer;

namespace Banks.Services.Observer;

public interface IObservable
{
    void SubscribeObserver(IObserver observer);
    void UnsubscribeObserver(IObserver observer);
    void NotifyObservers();
}