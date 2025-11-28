using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cp_lab_7_add
{
    public partial class Form1 : Form
    {
        enum DeviceType
        {
            Lamp,
            Thermostat,
            Fan
        }

        private List<SmartDevice> devices = new List<SmartDevice>();

        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetValues(typeof(DeviceType));
        }

        private SmartDevice NewDevice(string name, DeviceType type)
        {
            switch (type)
            {
                case DeviceType.Lamp:
                    return new SmartLamp(name);
                case DeviceType.Thermostat:
                    return new SmartThermostat(name);
                case DeviceType.Fan:
                    return new SmartFan(name);
                default:
                    throw new ArgumentException("Invalid device type");
            }
        }

        private void AddDeviceToUI(SmartDevice device)
        {
            GroupBox deviceGroupBox = new GroupBox();
            deviceGroupBox.Text = device.Name + $" ({device.GetType().Name})";
            deviceGroupBox.Width = 240;
            deviceGroupBox.Height = 80;
            deviceGroupBox.Padding = new Padding(8);
            deviceGroupBox.Margin = new Padding(5);
            deviceGroupBox.BackColor = SystemColors.ControlLight;

            Button toggleButton = new Button();
            toggleButton.Text = "Toggle";
            toggleButton.Size = new Size(60, 25);
            toggleButton.Location = new Point(10, 30);
            toggleButton.Click += (s, e) =>
            {
                device.Toggle();
                deviceGroupBox.BackColor = device.IsOn ? Color.LightGreen : SystemColors.ControlLight;
            };

            Button statusButton = new Button();
            statusButton.Text = "Status";
            statusButton.Size = new Size(60, 25);
            statusButton.Location = new Point(80, 30);
            statusButton.Click += (s, e) =>
            {
                MessageBox.Show(device.StatusMessage, "Device Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Size = new Size(60, 25);
            deleteButton.Location = new Point(150, 30);
            deleteButton.Click += (s, e) =>
            {
                flowPanelDevices.Controls.Remove(deviceGroupBox);
                devices.Remove(device);
            };

            deviceGroupBox.Controls.Add(toggleButton);
            deviceGroupBox.Controls.Add(statusButton);
            deviceGroupBox.Controls.Add(deleteButton);

            flowPanelDevices.Controls.Add(deviceGroupBox);
        }

        private void AddDeviceButton_Click(object sender, EventArgs e)
        {
            string deviceName = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(deviceName))
            {
                MessageBox.Show("Please enter a device name.");
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a device type.");
                return;
            }

            DeviceType selectedType = (DeviceType)comboBox1.SelectedIndex;
            SmartDevice device = NewDevice(deviceName, selectedType);

            devices.Add(device);
            AddDeviceToUI(device);
        }
    }
}
