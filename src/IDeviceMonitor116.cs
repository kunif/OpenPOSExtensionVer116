/* ILights116.cs UnifiedPOS Lights Extension Interface for POS for.NET 1.14.1
  version 1.16.0.0 January 19th, 2022

  Copyright (C) 2022 Kunio Fukuchi

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.

  Kunio Fukuchi

*/
namespace OpenPOS.Extension
{
    using System;
    using System.Collections.Generic;
    public enum MonitoringModeType
    {
        Update = 1,
        Straddled,
        High,
        Low,
        WithIn,
        Outside,
        Polling
    }

    public struct DeviceDataValue
    {
        private string _id;
        private int _value;
        public string Id
        {
            get { return this._id; }
        }
        public int Value
        {
            get { return this._value; }
        }
        public DeviceDataValue(string Id, int Value)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                throw new ArgumentException();
            }
            this._id = Id;
            this._value = Value;
        }
        public bool Equals(DeviceDataValue data)
        {
            if ((data.Id == this._id) && (data.Value == this._value))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is DeviceDataValue)
            {
                return this.Equals((DeviceDataValue)obj);
            }
            return false;
        }
        public static bool Equals(DeviceDataValue a, DeviceDataValue b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(DeviceDataValue a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(DeviceDataValue a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }

    public struct DeviceInfoValue
    {
        private string _id;
        private string _type;
        private string _unit;
        private string _coefficient;
        public string Id
        {
            get { return this._id; }
        }
        public string Type
        {
            get { return this._type; }
        }
        public string Unit
        {
            get { return this._unit; }
        }
        public string Coefficient
        {
            get { return this._coefficient; }
        }
        public DeviceInfoValue(string Id, string Type, string Unit, string Coefficient)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                throw new ArgumentException();
            }
            this._id = Id;
            this._type = Type;
            this._unit = Unit;
            this._coefficient = Coefficient;
        }
        public bool Equals(DeviceInfoValue info)
        {
            if ((info.Id == this._id)
                && (info.Type == this._type)
                && (info.Unit == this._unit)
                && (info.Coefficient == this._coefficient)
                )
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is DeviceInfoValue)
            {
                return this.Equals((DeviceDataValue)obj);
            }
            return false;
        }
        public static bool Equals(DeviceInfoValue a, DeviceInfoValue b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(DeviceInfoValue a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(DeviceInfoValue a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }

    public struct MonitoringDeviceValue
    {
        private string _id;
        private MonitoringModeType _mode;
        private int _boundary;
        private int _subboundary;
        private int _interval;
        public string Id
        {
            get { return this._id; }
        }
        public MonitoringModeType MonitoringMode
        {
            get { return this._mode; }
        }
        public int Boundary
        {
            get { return this._boundary; }
        }
        public int SubBoundary
        {
            get { return this._subboundary; }
        }
        public int IntervalTime
        {
            get { return this._interval; }
        }
        public MonitoringDeviceValue(string Id, MonitoringModeType MonitoringMode, int Boundary, int SubBoundary, int IntervalTime)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                throw new ArgumentException();
            }
            this._id = Id;
            this._mode = MonitoringMode;
            this._boundary = Boundary;
            this._subboundary = SubBoundary;
            this._interval = IntervalTime;
        }
        public bool Equals(MonitoringDeviceValue info)
        {
            if ((info.Id == this._id)
                && (info.MonitoringMode == this._mode)
                && (info.Boundary == this._boundary)
                && (info.SubBoundary == this._subboundary)
                && (info.IntervalTime == this._interval)
                )
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is MonitoringDeviceValue)
            {
                return this.Equals((MonitoringDeviceValue)obj);
            }
            return false;
        }
        public static bool Equals(MonitoringDeviceValue a, MonitoringDeviceValue b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(MonitoringDeviceValue a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(MonitoringDeviceValue a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }

    public static class IDeviceMonitor116Constants
    {
        public const int statusStartMonitoring = 11;
        public const int statusStopMonitoring = 12;
    }

    public interface IDeviceMonitor116
    {
        DeviceDataValue DeviceData { get; }
        DeviceInfoValue[] DeviceList { get; }
        MonitoringDeviceValue[] MonitoringDeviceList { get; }
        void AddMonitoringDevice(string deviceId, MonitoringModeType monitoringMode, int boundary, int subBoundary, int intervalTime);
        void ClearMonitoringDevice();
        void DeleteMonitoringDevice(string deviceId);
        int GetDeviceValue(string deviceId);
    }
}