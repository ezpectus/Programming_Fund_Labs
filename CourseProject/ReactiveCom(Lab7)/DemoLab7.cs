using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core;
using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Entities;
using System;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_
{
    public class DemoLab7
    {
        public static void Run()
        {
            var channel = new EventChannel<double>();
            var display = new Display();
            var logger = new Logger();

            channel.Subscribe(logger);
            channel.Subscribe(display);

            channel.Publish(25.5);
            channel.Publish(30.0);
            channel.Publish(28.3);

            // Simulate an error
            channel.PublishError(new Exception("Sensor malfunction"));

            // Simulate completion
            channel.PublishComplete();

            // Unsubscribe display and publish again
            channel.Unsubscribe(display);
            channel.Publish(22.0);
        }
    }
}