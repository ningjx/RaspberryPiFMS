﻿using System.Threading.Tasks;

namespace RaspberryPiFMS.Models
{
    public class OriginSignal
    { 
        public long Channel01;
        public long Channel02;
        public long Channel03;
        public long Channel04;
        public long Channel05;
        public long Channel06;
        public long Channel07;
        public long Channel08;
        public long Channel09;
        public long Channel10;
        public long Channel11;
        public long Channel12;
        public long Channel13;
        public long Channel14;
        public long Channel15;
        public long Channel16;
        public bool IsConnected = true;

        private  int _channelCount = 0;
        public void SetSignal(long data)
        {
            _channelCount++;
            switch (_channelCount)
            {
                case 1:
                    Channel01 = data;
                    break;
                case 2:
                    Channel02 = data;
                    break;
                case 3:
                    Channel03 = data;
                    break;
                case 4:
                    Channel04 = data;
                    break;
                case 5:
                    Channel05 = data;
                    break;
                case 6:
                    Channel06 = data;
                    break;
                case 7:
                    Channel07 = data;
                    break;
                case 8:
                    Channel08 = data;
                    break;
                case 9:
                    Channel09 = data;
                    break;
                case 10:
                    Channel10 = data;
                    break;
                case 11:
                    Channel11 = data;
                    break;
                case 12:
                    Channel12 = data;
                    break;
                case 13:
                    Channel13 = data;
                    break;
                case 14:
                    Channel14 = data;
                    break;
                case 15:
                    Channel15 = data;
                    break;
                case 16:
                    Channel16 = data;
                    break;
                default:
                    break;
            }
            if (_channelCount == 16)
            {
                _channelCount = 0;
                Task.Run(() => OriginConSingnal.ConvertSignal());
            }
        }

        public long this[int index]
        {
            get 
            {
                switch (index)
                {
                    case 1:
                        return Channel01;
                    case 2:
                        return Channel02;
                    case 3:
                        return Channel03;
                    case 4:
                        return Channel04;
                    case 5:
                        return Channel05;
                    case 6:
                        return Channel06;
                    case 7:
                        return Channel07;
                    case 8:
                        return Channel08;
                    case 9:
                        return Channel09;
                    case 10:
                        return Channel10;
                    case 11:
                        return Channel11;
                    case 12:
                        return Channel12;
                    case 13:
                        return Channel13;
                    case 14:
                        return Channel14;
                    case 15:
                        return Channel15;
                    case 16:
                        return Channel16;
                    default:
                        return 0;
                }
            }
        }

        public void SetDefaultSignal()
        {
            Channel01 = 1000;
            Channel02 = 1000;
            Channel03 = 200;
            Channel04 = 1000;
        }

        public void SetSignalLost()
        {
            Channel01 = 1000;
            Channel02 = 1000;
            Channel03 = 200;
            Channel04 = 1000;
            IsConnected = false;
        }
    }
}
