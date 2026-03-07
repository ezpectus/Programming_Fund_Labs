using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core
{
   public interface IEventObserver<T>
    {
        void OnNext(T value);
        void OnError(Exception ex);
        void OnCompleted();
    }
}
