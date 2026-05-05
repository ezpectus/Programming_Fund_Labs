using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core;
using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Entities;
using System;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_
{
    public static class DemoLab7
    {
        public static void Run()
        {
            Console.WriteLine("=== Lab 7: Reactive Communication ===");

            var channel = new EventChannel<double>();
            var display = new Display();
            var logger = new Logger();

            Console.WriteLine("\n[Step 1] Subscribing observers...");
            channel.Subscribe(logger);
            channel.Subscribe(display);

            Console.WriteLine("\n[Step 2] Publishing values...");
            channel.Publish(25.5);
            channel.Publish(30.0);
            channel.Publish(28.3);

            Console.WriteLine("\n[Step 3] Simulating error...");
            channel.PublishError(new Exception("Sensor malfunction"));

            Console.WriteLine("\n[Step 4] Completing stream...");
            channel.PublishComplete();

            Console.WriteLine("\n[Step 5] Unsubscribing Display...");
            channel.Unsubscribe(display);

            Console.WriteLine("\n[Step 6] Publishing after unsubscribe...");
            channel.Publish(22.0);

            Console.WriteLine("\n=== Lab 7 completed ===");
        }
    }
}