using System;

namespace Sound
{
    public class Devices
    {
        private string _deviceSource;
        private string _deviceId;
        private string _deviceName;

        public Devices(string deviceSource, string deviceId, string deviceName)
        {
            this._deviceId = deviceId;
            this._deviceSource = deviceSource;
            this._deviceName = deviceName;
        }

        public string GetId()
        {
            return this._deviceId;
        }

        public string GetName()
        {
            return this._deviceName;
        }

        public string GetSource()
        {
            return this._deviceSource;
        }

        public override string ToString()
        {
            return "source:" + this._deviceSource + ", name:" + this._deviceName + ", id:" + this._deviceId;
        }
    }
}