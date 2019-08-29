﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RaspberryPiFMS.Helper
{
    public class SocketHelper
    {
        private Socket socket;
        private string ipAddress;
        private int port;
        private IPEndPoint ipe;
        private EndPoint ep;

        public SocketHelper()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ipAddress = "106.14.115.249";
            port = 35415;
            ipe = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            ep = ipe;
        }

        public SocketHelper(string ip, string point)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ipAddress = ip;
            port = Convert.ToInt32(point);
            ipe = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            ep = ipe;
        }
        public void CloseCon()
        {
            socket.Close();
        }

        public void SendData(string data)
        {
            var byteData = new byte[500];
            byteData = Encoding.ASCII.GetBytes(data);
            socket.SendTo(byteData, ipe);
        }

        public string ReciveData()
        {
            string data = string.Empty;
            byte[] buffer = new byte[500];
            socket.ReceiveFrom(buffer, ref ep);
            data = Encoding.ASCII.GetString(buffer);
            return data;
        }
    }
}
