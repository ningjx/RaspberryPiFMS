﻿using RaspberryPiFMS.Fuctions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using RaspberryPiFMS.Interface;

namespace RaspberryPiFMS.Controller
{
    public class Controller : IController
    {
        private  readonly Timer _timer = new Timer(20);
        private  bool _isRunning = false;

        public Controller()
        {
            _timer.AutoReset = true;
            _timer.Elapsed += Elapsed;
        }
        public  void Start()
        {
            _timer.Start();
        }
        private  void Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_isRunning) return;
            _isRunning = true;

            BaseFuncion.Excute(StateDatasBus.CenterSignal.Yaw, StateDatasBus.CenterSignal.PitchL, StateDatasBus.CenterSignal.PitchR, StateDatasBus.CenterSignal.ThrottelL1, StateDatasBus.CenterSignal.ThrottelR1, StateDatasBus.CenterSignal.RollL, StateDatasBus.CenterSignal.RollR, StateDatasBus.CenterSignal.Trim);
            LEDFunction.Excute(StateDatasBus.CenterSignal.FlightLight, StateDatasBus.CenterSignal.AntiCollisionLight, StateDatasBus.CenterSignal.LogoLight, StateDatasBus.CenterSignal.TaxiLight, StateDatasBus.CenterSignal.RunwayLight, StateDatasBus.CenterSignal.TakeOffLight, StateDatasBus.CenterSignal.LandingLight, StateDatasBus.CenterSignal.WingInspectionLight, StateDatasBus.CenterSignal.PositionLight);
            PushBackFunction.Excute(StateDatasBus.CenterSignal.PushBackL1, StateDatasBus.CenterSignal.PushBackL2, StateDatasBus.CenterSignal.PushBackR1, StateDatasBus.CenterSignal.PushBackR2, StateDatasBus.CenterSignal.PushBack);

            _isRunning = false;
        }
    }
}
