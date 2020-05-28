﻿using System;
using System.Net.Sockets;
using System.Net;
using System.Timers;
using Timer = System.Timers.Timer;
using RaspberryPiFCS.Interface;
using RaspberryPiFCS.Models;
using RaspberryPiFCS.SystemMessage;
using RaspberryPiFCS.Enum;

namespace RaspberryPiFCS.Equipments
{
    /// <summary>
    /// Socket设备
    /// </summary>
    public class Socket : IEquipment_Socket
    {
        public IPEndPoint BindIP { get; }
        public IPEndPoint TargetIP { get; }
        public EndPoint OriginIP => _endPoint;
        public EquipmentData EquipmentData { get; } = new EquipmentData("Socket");

        private System.Net.Sockets.Socket _socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private Timer _timer = new Timer(10);
        private EndPoint _endPoint;
        private byte[] Buffer { get; } = new byte[10000];

        /// <summary>
        /// 向目标IP发送字节
        /// </summary>
        public byte[] ByteForTarget { set { _socket.SendTo(value, TargetIP); } }

        /// <summary>
        /// 向来源IP发送字节
        /// </summary>
        public byte[] ByteForOrigin { set { _socket.SendTo(value, OriginIP); } }

        public RelyConyroller RelyConyroller { get; set; } = new RelyConyroller
        {
            RegisterType.Sys
        };

        public Socket(int bindPort, int sendPort = 0)
        {
            BindIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), bindPort);
            if (sendPort != 0)
                TargetIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), sendPort);
        }

        public bool Lunch()
        {
            try
            {
                //检查依赖
                if (!StatusDatasBus.ControllerRegister.CheckRely(RelyConyroller))
                {
                    throw new Exception($"依赖设备尚未启动{string.Join("、", RelyConyroller)}");
                }

                _socket.Bind(BindIP);
                _timer.AutoReset = true;
                _timer.Elapsed += TimerElapsed;
                _timer.Start();
                StatusDatasBus.ControllerRegister.Register(RegisterType.Socket, false);
            }
            catch (Exception ex)
            {
                EquipmentData.AddError(Enum.ErrorType.Error, $"IP为{BindIP.Address.ToString()}、端口为{BindIP.Port}Socket设备启动失败！", ex);
                ErrorMessage.Add(Enum.ErrorType.Error, $"IP为{BindIP.Address.ToString()}、端口为{BindIP.Port}Socket设备启动失败！", ex);
                return false;
            }
            return true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _socket.ReceiveFrom(Buffer, ref _endPoint);
            ReceivedEvent?.Invoke(Buffer);
        }

        public delegate void ReceiveBytesHandler(byte[] bytes);

        public event ReceiveBytesHandler ReceivedEvent;
    }
}
