using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_
{
 public class DemoLab7
    {


        public static void Run()
            {
                var channel = new Core.EventChannel<double>();
                var display = new Entities.Display();
                var logger = new Entities.Logger();

                channel.Subscribe(logger);
                channel.Subscribe(display);
                channel.Publish(25.5);
                channel.Publish(30.0);
                channel.Publish(28.3);


    
                // Simulate an error
                channel.PublishError(new Exception("Sensor malfunction"));
    
                // Simulate completion
                channel.PublishComplete();
    
                // Unsubscribe the display
                channel.Unsubscribe(display);
    
                // Publish after unsubscription to show that display no longer receives updates
                channel.Publish(22.0);

        }


    }
}
