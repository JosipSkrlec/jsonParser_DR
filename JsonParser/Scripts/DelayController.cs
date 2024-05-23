using System;
using System.Windows.Forms;

namespace JsonParser.Scripts
{
    internal class DelayController
    {
        private const int DELAY_INTERVAL_VALUE = 3500;

        public Action OnDelayFinishedEvent = default;

        private Timer _timer;

        public void StartDelay()
        {
            _timer = new Timer();
            _timer.Interval = DELAY_INTERVAL_VALUE;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= Timer_Tick;
            _timer.Dispose();

            OnDelayFinishedEvent?.Invoke();
        }
    }
}