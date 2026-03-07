using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core
{
   public interface IEventObservable<T>
    {
        void Subscribe(IEventObserver<T> observer);
        void Unsubscribe(IEventObserver<T> observer);

    }
}
