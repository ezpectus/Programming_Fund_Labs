using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core;
using System;


namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Entities
{
    public class Logger : IEventObserver<double>
    {

     public void OnNext(double value)
        {
            Console.WriteLine($"Logger received value: {value}");
        }
        public void OnError(Exception ex)
        {
            Console.WriteLine($"Logger received error: {ex.Message}");
        }
        public void OnCompleted()
        {
            Console.WriteLine("Logger received completion signal.");
        }

    }
}
