﻿using RaspberryPiFMS.Enum;
using RaspberryPiFMS.Helper;
using RaspberryPiFMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Timer = System.Timers.Timer;

namespace RaspberryPiFMS.ComputeCenter
{
    public class ControlPolymerize
    {
        private Timer _timer = new Timer();
        private PIDHelper _pid = new PIDHelper();

        public ControlPolymerize()
        {
            _pid.PIDOutEvent += PIDOutEvent;

            _timer.Interval = 20;
            _timer.AutoReset = true;
            _timer.Elapsed += Excute;
            _timer.Start();
        }

        private void PIDOutEvent(double value)
        {
            CenterData.ThrottelL = value;
        }

        private void Excute(object sender, System.Timers.ElapsedEventArgs e)
        {
            switch (Bus.ContrlMode)
            {
                case ContrlMode.Manual:
                    ManualPolymerize();
                    break;
                case ContrlMode.LateralNavigation:
                    LateralNavigation();
                    break;
                case ContrlMode.VerticalNavigation:
                    VerticalNavigation();
                    break;
                case ContrlMode.APOn:
                    APOn();
                    break;
                case ContrlMode.AutoSpeed:
                    AutoSpeed();
                    break;
            }
        }

        private void ManualPolymerize()
        {
            ConvertSignal();
            CenterData.Yaw = OriginConSingnal.Yaw;
            CenterData.ThrottelL = OriginConSingnal.Throttel;
            CenterData.ThrottelR = OriginConSingnal.Throttel;
            //对油门进行PID控制
            //_pid.SetWithPID((float)Cache.CenterControlData.ThrottelL, (float)Cache.RemoteSignal.Channel03);
            CenterData.RollL = OriginConSingnal.Roll;
            CenterData.RollR = OriginConSingnal.Roll;
            CenterData.PitchL = OriginConSingnal.Pitch;
            CenterData.PitchR = OriginConSingnal.Pitch;

            CommonOperation();
        }
        private void LateralNavigation()
        {

        }
        private void VerticalNavigation()
        {

        }
        private void APOn()
        {

        }
        private void AutoSpeed()
        {

        }


        private void CommonOperation()
        {
            CenterData.Gear = OriginConSingnal.Channel05 == Switch.On ? true : false;
            CenterData.PushBack = OriginConSingnal.Channel11 == Switch.On ? true : false;
            switch (OriginConSingnal.Channel09)
            {
                case Switch.Off:
                    CenterData.Flap = FlapMode.FlapUp;
                    break;
                case Switch.MId:
                    CenterData.Flap = FlapMode.TakeOff;
                    break;
                case Switch.On:
                    CenterData.Flap = FlapMode.Landing;
                    break;
                default:
                    break;
            }
            #region 灯光
            /*使用频道8(两档)/7(三挡)
            8-off
                  7-off:航行灯开 防撞灯开 LOGO灯开(根据起落架状态)
                  7-mid:滑行灯开(根据起落架状态)
                  7-on:跑道脱离灯
            8-on  
                  7-on:起飞灯(根据起落架状态)
                  7-mid:着陆灯(根据起落架状态)
                  7-off:高亮度白色防撞灯 机翼检查灯开
            7个灯光控制*/
            if (OriginConSingnal.Channel08 == Switch.Off)
            {
                if (OriginConSingnal.Channel07 == Switch.Off)//航行灯开 防撞灯开 LOGO灯开(根据起落架状态)
                {
                    CenterData.TaxiLight = false;
                    CenterData.RunwayLight = false;
                    CenterData.TakeOffLight = false;
                    CenterData.LandingLight = false;
                    CenterData.WingInspectionLight = false;
                    CenterData.PositionLight = false;

                    CenterData.FlightLight = true;
                    CenterData.AntiCollisionLight = true;
                    CenterData.LogoLight = CenterData.Gear ? true : false;
                }
                else if (OriginConSingnal.Channel07 == Switch.MId)// 滑行灯开(根据起落架状态)
                {
                    CenterData.RunwayLight = false;
                    CenterData.TakeOffLight = false;
                    CenterData.LandingLight = false;
                    CenterData.WingInspectionLight = false;
                    CenterData.PositionLight = false;

                    CenterData.FlightLight = true;
                    CenterData.AntiCollisionLight = true;
                    CenterData.LogoLight = CenterData.Gear ? true : false;
                    CenterData.TaxiLight = CenterData.Gear ? true : false;
                }
                else//跑道脱离灯
                {
                    CenterData.TakeOffLight = false;
                    CenterData.LandingLight = false;
                    CenterData.WingInspectionLight = false;
                    CenterData.PositionLight = false;

                    CenterData.FlightLight = true;
                    CenterData.AntiCollisionLight = true;
                    CenterData.LogoLight = CenterData.Gear ? true : false;
                    CenterData.TaxiLight = CenterData.Gear ? true : false;
                    CenterData.RunwayLight = true;
                }
            }
            else
            {
                if (OriginConSingnal.Channel07 == Switch.On)//起飞灯(根据起落架状态)
                {
                    CenterData.LandingLight = false;
                    CenterData.WingInspectionLight = false;
                    CenterData.PositionLight = false;

                    CenterData.FlightLight = true;
                    CenterData.AntiCollisionLight = true;
                    CenterData.LogoLight = CenterData.Gear ? true : false;
                    CenterData.TaxiLight = CenterData.Gear ? true : false;
                    CenterData.RunwayLight = true;
                    CenterData.TakeOffLight = CenterData.Gear ? true : false;
                }
                else if (OriginConSingnal.Channel07 == Switch.MId)//着陆灯(根据起落架状态)
                {
                    CenterData.WingInspectionLight = false;
                    CenterData.PositionLight = false;

                    CenterData.FlightLight = true;
                    CenterData.AntiCollisionLight = true;
                    CenterData.LogoLight = CenterData.Gear ? true : false;
                    CenterData.TaxiLight = CenterData.Gear ? true : false;
                    CenterData.RunwayLight = true;
                    CenterData.TakeOffLight = CenterData.Gear ? true : false;
                    CenterData.LandingLight = CenterData.Gear ? true : false;
                }
                else//高亮度白色防撞灯 机翼检查灯开
                {
                    CenterData.FlightLight = true;
                    CenterData.AntiCollisionLight = true;
                    CenterData.LogoLight = CenterData.Gear ? true : false;
                    CenterData.TaxiLight = CenterData.Gear ? true : false;
                    CenterData.RunwayLight = true;
                    CenterData.TakeOffLight = CenterData.Gear ? true : false;
                    CenterData.LandingLight = CenterData.Gear ? true : false;
                    CenterData.PositionLight = true;
                    CenterData.WingInspectionLight = true;
                }
            }
            #endregion
        }
        /// <summary>
        /// 转换原始遥控数据
        /// </summary>
        /// <param name="originData"></param>
        private void ConvertSignal()
        {
            OriginConSingnal.Roll = OriginSignal.Channel04 / 10;
            OriginConSingnal.Pitch = OriginSignal.Channel02 / 10;
            OriginConSingnal.Yaw = OriginSignal.Channel01 / 10;
            OriginConSingnal.Throttel = OriginSignal.Channel03 / 10 + 50;
            OriginConSingnal.Channel05 = OriginSignal.Channel05.GetSwitch();
            OriginConSingnal.Channel06 = OriginSignal.Channel06.GetSwitch(500);
            OriginConSingnal.Channel07 = OriginSignal.Channel07.GetSwitch();
            OriginConSingnal.Channel08 = OriginSignal.Channel08.GetSwitch();
            OriginConSingnal.Channel09 = OriginSignal.Channel09.GetSwitch();
            OriginConSingnal.Channel10 = OriginSignal.Channel10 / 10;
            OriginConSingnal.Channel11 = OriginSignal.Channel11.GetSwitch(500);
            OriginConSingnal.Channel12 = OriginSignal.Channel12 / 10;
            //OriginConSingnal.Channel13 = OriginSignal.Channel13 / 10;
            //OriginConSingnal.Channel14 = OriginSignal.Channel14 / 10;
            //OriginConSingnal.Channel15 = OriginSignal.Channel15 / 10;
            //OriginConSingnal.Channel16 = OriginSignal.Channel16 / 10;  
        }
    }
}
