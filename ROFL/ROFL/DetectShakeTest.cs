using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace ROFL
{
    public class DetectShakeTest
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.Game;
        int count = 0;
        Label editLabel;

        public DetectShakeTest(Label l)
        {
            // Register for reading changes, be sure to unsubscribe when finished
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            editLabel = l;
        }

        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            // Process shake event
            count++;
            editLabel.Text = "Shakes: " + count;
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
