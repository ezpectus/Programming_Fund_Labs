namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core
{
    public interface IEventObservable<T>
    {
        void Subscribe(IEventObserver<T> observer);
        void Unsubscribe(IEventObserver<T> observer);
    }
}