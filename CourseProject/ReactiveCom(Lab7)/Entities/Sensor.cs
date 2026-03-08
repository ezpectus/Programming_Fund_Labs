
using PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Core;

namespace PGR_FUND_LABS_CS.CourseProject.ReactiveCom_Lab7_.Entities
{
    public class Sensor
    {

        private readonly EventChannel<double> _eventChannel;

        public Sensor(EventChannel<double> eventChannel)
        {
            this._eventChannel = eventChannel;
        }


        public void Send(double value)
        {

            _eventChannel.Publish(value);
        }


    }
}
