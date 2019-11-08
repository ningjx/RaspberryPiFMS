﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using flyfire.IO.Ports;
using RaspberryPiFMS.Helper;
using RJCP.IO.Ports;


namespace RaspberryPiFMS.Controller
{
    public class RemoteController
    {
        private SbusHelper _sbusHelper;
        CustomSerialPort sbus;
        public RemoteController(string portName)
        {
            _sbusHelper = new SbusHelper();
            sbus = new CustomSerialPort(portName, 100000, Parity.Even, 8, StopBits.Two);
            sbus.ReceiveTimeoutEnable = false ;
            sbus.ReceivedEvent += Sbus_ReceivedEvent;
            sbus.Open();
            //sbus.
        }

        public void Dispose()
        {
            Dispose();
        }

        public void GetSingnal()
        {

        }

        private void Sbus_ReceivedEvent(object sender, byte[] bytes)
        {
            _sbusHelper.DecodeSignal(bytes);
        }
    }
}
