using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core
{
   public class EventChannel<T> : IEventObservable<T>
    {

        private readonly List<IEventObserver<T>> observers = new();
        public void Subscribe(IEventObserver<T> observer)
        {
            if (!observers.Contains(observer)) observers.Add(observer); 
        }

        public void Unsubscribe(IEventObserver<T> observer)
        {
            if (observers.Contains(observer)) observers.Remove(observer);  
        }


        public void Publish(T value)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }
        }

      public void PublishError(Exception ex) {
         foreach (var observer in observers)
            {
                observer.OnError(ex);
            }
        }

      public void PublishComplete() {
          foreach (var observer in observers)
                {
                    observer.OnCompleted();
                }
        }
    }
 }
