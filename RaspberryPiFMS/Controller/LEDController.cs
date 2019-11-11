﻿using RaspberryPiFMS.Enum;
using RaspberryPiFMS.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace RaspberryPiFMS.Controller
{
    public class LEDController
    {
        /// <summary>
        /// 航行灯（翼尖闪烁）
        /// </summary>
        private bool _logoLight = false;
        /// <summary>
        /// 红色信标灯（闪烁）
        /// </summary>
        private bool _antiCollisionLight = false;
        private bool _isTimerRunning = false;
        private Timer _timer = new Timer();
        private Pca9685 _ledDriver;
        public LEDController(Pca9685 ledDriver)
        {
            _ledDriver = ledDriver;
            _timer.Enabled = true;
            _timer.Interval = 1500;
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_logoLight)
            {
                _ledDriver.SetLedOn(LedChannel.LogoLight.GetHashCode());
                Thread.Sleep(200);
                _ledDriver.SetLedOff(LedChannel.LogoLight.GetHashCode());
                Thread.Sleep(200);
                _ledDriver.SetLedOn(LedChannel.LogoLight.GetHashCode());
                Thread.Sleep(200);
                _ledDriver.SetLedOff(LedChannel.LogoLight.GetHashCode());
            }
            if (_antiCollisionLight)
            {
                _ledDriver.SetLedOn(LedChannel.AntiCollisionLight.GetHashCode());
                Thread.Sleep(200);
                _ledDriver.SetLedOff(LedChannel.AntiCollisionLight.GetHashCode());
            }
        }

        public void SetLedOnAndOff(LedChannel channel, Switch @switch)
        {
            if (channel == LedChannel.AntiCollisionLight && @switch == Switch.On)
            {
                _antiCollisionLight = true;
                return;
            }
            if (channel == LedChannel.AntiCollisionLight && @switch == Switch.Off)
            {
                _antiCollisionLight = false;
                return;
            }
            if (channel == LedChannel.LogoLight && @switch == Switch.On)
            {
                _logoLight = true;
                return;
            }
            if (channel == LedChannel.LogoLight && @switch == Switch.Off)
            {
                _logoLight = false;
                return;
            }
            if (@switch == Switch.Off)
                _ledDriver.SetLedOff(channel.GetHashCode());
            if (@switch == Switch.On)
                _ledDriver.SetLedOn(channel.GetHashCode());

            if (!_isTimerRunning && (_antiCollisionLight || _logoLight))
                _timer.Start();
            if (!_antiCollisionLight && !_logoLight && _isTimerRunning)
                _timer.Stop();
        }
    }
}
