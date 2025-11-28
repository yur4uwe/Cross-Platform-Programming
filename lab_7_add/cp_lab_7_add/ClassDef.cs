using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_7_add
{
    public abstract class SmartDevice
    {
        public string Name { get; set; }
        public bool IsOn { get; set; }
        public abstract string Type { get; }

        public SmartDevice(string name)
        {
            Name = name;
            IsOn = false;
        }

        public virtual void Toggle()
        {
            IsOn = !IsOn;
        }

        public abstract string StatusMessage { get; }
    }

    public class SmartLamp : SmartDevice
    {
        public int Brightness { get; set; }
        public override string Type => "Lamp";

        public SmartLamp(string name, int brightness = 50) : base(name)
        {
            Brightness = brightness;
        }

        public override void Toggle()
        {
            base.Toggle();
            Brightness = IsOn ? Brightness : 0;
        }

        public override string StatusMessage =>
            $"{Name} ({Type}) is {(IsOn ? $"On at {Brightness}% brightness" : "Off")}";
    }

    public class SmartThermostat : SmartDevice
    {
        public double Temperature { get; set; }
        public override string Type => "Thermostat";

        public SmartThermostat(string name, double temperature = 22.0) : base(name)
        {
            Temperature = temperature;
        }

        public override string StatusMessage =>
            $"{Name} ({Type}) is {(IsOn ? $"On at {Temperature}°C" : "Off")}";
    }

    public class SmartFan : SmartDevice
    {
        public int Speed { get; set; }
        public override string Type => "Fan";

        public SmartFan(string name, int speed = 1) : base(name)
        {
            Speed = speed;
        }

        public override string StatusMessage =>
            $"{Name} ({Type}) is {(IsOn ? $"On (Speed {Speed})" : "Off")}";
    }

}
