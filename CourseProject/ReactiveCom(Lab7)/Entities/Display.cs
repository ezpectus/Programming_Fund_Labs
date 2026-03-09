using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Entities
{
   public class Display : IEventObserver<double>
    {
     
        public void OnNext(double value)
        {
            Console.WriteLine($"Display shows value: {value}");
        }

        public void OnError(Exception ex)
        {
            Console.WriteLine($"Display received error: {ex.Message}");
         
        }

        public void OnCompleted()
        {
           Console.WriteLine("Display: stream completed");
        }


        }
}
