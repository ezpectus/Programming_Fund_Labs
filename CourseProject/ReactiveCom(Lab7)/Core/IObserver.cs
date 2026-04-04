using System;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core
{
    public interface IEventObserver<T>
    {
        void OnNext(T value);
        void OnError(Exception ex);
        void OnCompleted();
    }
}