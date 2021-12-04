using System;
using Accessibility;
using Microsoft.Win32;

namespace Sound
{
    public class DeviceList
    {
        private Devices[] _list;

        public DeviceList()
        {
            this._list = new Devices[0];
        }

        public void Add(Devices devices)
        {
            int index = _list.Length;
            Array.Resize(ref _list, _list.Length+1);
            _list[index] = devices;
        }

        public bool IsContain(string name)
        {
            for (int i = 0; i < this._list.Length; i++)
            {
                if (this._list[i].GetName().Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public string GetId(string friendlyName)
        {
            for (int i = 0; i < this._list.Length; i++)
            {
                if (this._list[i].GetName().Equals(friendlyName))
                {
                    return this._list[i].GetId();
                }
            }
            return "";
        }

        public string[] GetIds()
        {
            string[] list = new string[_list.Length];
            for (int i = 0; i < _list.Length; i++)
            {
                list[i] = _list[i].GetId();
            }
            return list;
        }
        
        public string[] GetIds(string[] friendlyNames)
        {
            string[] list = new string[friendlyNames.Length];
            for (int i = 0; i < friendlyNames.Length; i++)
            {
                list[i] = this.GetId(friendlyNames[i]);
            }
            return list;
        }

        public string[] GetNames()
        {
            string[] list = new string[_list.Length];
            for (int i = 0; i < _list.Length; i++)
            {
                list[i] = _list[i].GetName();
            }
            return list;
        }

        public Devices GetById(string id)
        {
            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i].GetId().Equals(id))
                {
                    return _list[i];
                }
            }
            return null;
        }

        public Devices[] GetList()
        {
            return _list;
        }
        
        public static DeviceList GetAudioDevice()
        {
            RegistryKey Audio = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\MMDevices\\Audio\\Render", false);
            string[] device_names = Audio.GetSubKeyNames();
            DeviceList deviceList = new DeviceList();
            for (int i = 0; i < device_names.Length; i++)
            {
                if (Audio.OpenSubKey(device_names[i]).GetValue("DeviceState").Equals(1) && Audio
                    .OpenSubKey(device_names[i] + "\\Properties")
                    .GetValue("{24dbb0fc-9311-4b3d-9cf0-18ff155639d4},0") != null)
                {
                    deviceList.Add(new Devices((string)Audio.OpenSubKey(device_names[i]+"\\Properties").GetValue("{b3f8fa53-0004-438e-9003-51a46e139bfc},6")," {0.0.0.00000000}."+device_names[i], (string)Audio.OpenSubKey(device_names[i]+"\\Properties").GetValue("{a45c254e-df1c-4efd-8020-67d146a850e0},2")));
                }
            }
            return deviceList;
        }

        public override string ToString()
        {
            string outString = "";
            foreach (Devices device in _list)
            {
                outString += device.ToString() + "\r\n";
            }
            return outString;
        }
    }
}