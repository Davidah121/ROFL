using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace ROFL
{
    public class DetectShakeTest
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.Fastest;
        int count = 0;
        RunMenu r;
        public DetectShakeTest(RunMenu r)
        {
            // Register for reading changes, be sure to unsubscribe when finished
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            this.r = r;
        }

        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            // Process shake event
            Debug.WriteLine("SHAKE");
            count++;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                r.setSteps(count);
            });
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
