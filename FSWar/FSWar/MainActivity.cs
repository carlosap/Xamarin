using Android.App;
using Android.Hardware;
using Android.OS;
using Android.Widget;
using FSWar;
using System;

namespace MotionDetector
{
    [Activity(Label = "FSWar", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity, ISensorEventListener
    {
        static readonly object _syncLock = new object();
        SensorManager _sensorManager;
        TextView _sensorTextView;
        TextView _sensorCounterTextView;
        TextView _sensorAverageTextView;
        TextView _sensorRotationStopwatchTextView;
        System.Diagnostics.Stopwatch rotationStopwatch = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch tenMillisecondStopwatch = new System.Diagnostics.Stopwatch();
        TimeSpan ts = new TimeSpan();

        int counter = 0;
        bool lockCounter = true;
        double totalZ = 0;
        double averageZ = 0;
        int avgCounter = 0;
        double atRestLastPassTime = 0;
        double withMagnetLastPassTime = 0;

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            // We don't want to do anything here.
        }

        public void OnSensorChanged(SensorEvent e)
        {
            lock (_syncLock)
            {
                // Sensor values, we only care about Z since that is the altitiude of the device
                // and does not change as often as rotating it does, plus magnets will be passing over it based on an altitiude
                _sensorTextView.Text = string.Format("x={0:f0}, y={1:f0}, z={2:f0}", e.Values[0], e.Values[1], e.Values[2]);

                // Recognize a magnet passing by if the sensor reads a value of the average Z + 10
                // TODO: Refine the +10 to be some sort of percentage calculation, had to use +10 because sometimes Z was almost 0
                if ((Math.Abs(e.Values[2]) > (Math.Abs(averageZ) + 10)) && (averageZ > 0))
                {
                    // Only read magnetic value if the counter is unlocked; meaning this is the first time we are entering above averageZ
                    // All subsequent readings that are greater than the averageZ will be ignored
                    if (!lockCounter)
                    {
                        // If the stopwatch is not running restart it
                        if (!rotationStopwatch.IsRunning)
                        {
                            rotationStopwatch.Restart();

                            // Reset counter only after a new spin begins, that way the users can see their last spin
                            counter = 0;
                        }

                        // Mark the time that the magnet was activated
                        withMagnetLastPassTime = rotationStopwatch.ElapsedMilliseconds;

                        // Bump the counter and show on screen
                        counter++;
                        _sensorCounterTextView.Text = string.Format("Count = {0:n0}", counter);

                        // Stop triggering counts until the value drops to the calculated averageZ when at rest
                        lockCounter = true;
                    }
                    else
                    {
                        // Stop timer if no change in 5 seconds
                        // This can happen if a magnet is held above the screen too long,
                        // or the phone was moved and the at rest Z value is now much different
                        if (rotationStopwatch.ElapsedMilliseconds - withMagnetLastPassTime >= 4999)
                        {
                            // Reset everything
                            Reset();
                        }
                    }
                }
                else
                {
                    // Value dropped below minimum threshold so the counter is no longer locked
                    if (lockCounter)
                    {
                        // This prevents a race condition during startup where averageZ can be 0
                        // We only want to unlock counter if there is an average Z to compare to
                        if (averageZ > 0)
                        {
                            lockCounter = false;
                        }

                        // Mark the time no magnet was sensed
                        atRestLastPassTime = rotationStopwatch.Elapsed.TotalMilliseconds;
                    }

                    // Start the 10 millisecond timer used for calculating average Z
                    if (!tenMillisecondStopwatch.IsRunning)
                    {
                        tenMillisecondStopwatch.Restart();
                    }

                    // Calculate average Z every 10 milliseconds when no magnet is present
                    if (tenMillisecondStopwatch.ElapsedMilliseconds >= 100)
                    {
                        avgCounter++;
                        totalZ = totalZ + Math.Abs(e.Values[2]);
                        averageZ = totalZ / avgCounter;

                        // After 100 counts (10 seconds), reset the averageZ in case the device moves
                        if (avgCounter >= 100)
                        {
                            avgCounter = 0;
                            totalZ = 0;
                        }

                        // Restart the 10 millisecond timer used for average Z calculation
                        tenMillisecondStopwatch.Restart();
                    }

                    // Stop Timer if no change in 5 seconds
                    if (rotationStopwatch.Elapsed.TotalMilliseconds - atRestLastPassTime >= 4999)
                    {
                        Reset();
                    }
                }

                // Display the time only while running, that way the user can see the last time even though it was stopped and reset
                if (rotationStopwatch.IsRunning)
                {
                    ts = rotationStopwatch.Elapsed;
                    _sensorRotationStopwatchTextView.Text = string.Format("Elapsed Time = {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                }

                _sensorAverageTextView.Text = string.Format("Average Z = {0:f0}", averageZ);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            _sensorManager = (SensorManager)GetSystemService(SensorService);
            _sensorTextView = FindViewById<TextView>(Resource.Id.proximity_text);
            _sensorCounterTextView = FindViewById<TextView>(Resource.Id.counter_text);
            _sensorAverageTextView = FindViewById<TextView>(Resource.Id.average_text);
            _sensorRotationStopwatchTextView = FindViewById<TextView>(Resource.Id.rotationstopwatch_text);
        }

        protected override void OnResume()
        {
            base.OnResume();

            // Proximity Sensor
            //_sensorManager.RegisterListener(this,
            //                                _sensorManager.GetDefaultSensor(SensorType.Proximity),
            //                                SensorDelay.Fastest);

            // Magnetic Field Sensor
            //_sensorManager.RegisterListener(this,
            //                                _sensorManager.GetDefaultSensor(SensorType.MagneticField),
            //                                SensorDelay.Fastest);

            // Light Sensor
            //_sensorManager.RegisterListener(this,
            //                                _sensorManager.GetDefaultSensor(SensorType.Light),
            //                                SensorDelay.Fastest);

            // Magnetic Field Uncalibrated Sensor
            _sensorManager.RegisterListener(this,
                                            _sensorManager.GetDefaultSensor(SensorType.MagneticFieldUncalibrated),
                                            SensorDelay.Fastest);
        }

        protected override void OnPause()
        {
            base.OnPause();
            _sensorManager.UnregisterListener(this);
        }

        public void Reset()
        {
            rotationStopwatch.Stop();
            rotationStopwatch.Reset();
            tenMillisecondStopwatch.Stop();
            tenMillisecondStopwatch.Reset();
            lockCounter = true;
            totalZ = 0;
            averageZ = 0;
            avgCounter = 0;
            atRestLastPassTime = 0;
            withMagnetLastPassTime = 0;
        }
    }
}