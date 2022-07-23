using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;
using System.Collections.ObjectModel;
using System.Threading;
using System.Media;
using System.IO;
//using System.Speech.Synthesis;


namespace HAI_KIOSK
{
    public partial class NoiseMonitor : Form
    {
        UsbSetupPacket usbSetupPacket = new UsbSetupPacket(0xC0, 4, 0, 10, 200);
        Thread NoiseMonitoring;
        public static UsbDevice MyUsbDevice;
        public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(0x16c0, 0x5dc);
        public delegate void NM_EventHandler_Slevel(int data);
        public delegate void NM_EventHandler_SCNOption(int data);
        public delegate void DNM();
        public event NM_EventHandler_Slevel SendSlevel;
        public event NM_EventHandler_SCNOption ModifyScnType;
        byte[] Values = new byte[4];
        Queue<double> Noise_Queue = new Queue<double>();
        double Soundlevel = 0;
        int Length;
        double LastValue = 0;
        public NoiseMonitor()
        {
            InitializeComponent();

            MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);
            if (MyUsbDevice == null)
                throw new Exception("WS1361C Noise Level Meter Not Connected.");
            UsbSetupPacket usbSetupPacket = new UsbSetupPacket(0xC0, 4, 0, 10, 200);

        }

        private void NoiseMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            NoiseMonitoring.Abort();
            //save csv
        }

        private void nm_start_btn_Click(object sender, EventArgs e)
        {
            if (nm_start_btn.Text == "start")
            {
                nm_start_btn.Text = "Stop";
                nm_start_btn.BackColor = Color.Red;
                NoiseMonitoring = new Thread(UNMM);
                NoiseMonitoring.Start();
            }
            else
            {
                nm_start_btn.Text = "start";
                nm_start_btn.BackColor = Color.Gray;
                NoiseMonitoring.Abort();
            }
        }

        private void UNMM()
        {
            DNM temp1 = noise2invoke;
            DNM temp2 = slevel2invoke;
            Noise_Queue.Clear();
            while (true)
            {
                Thread.Sleep(10);
                MyUsbDevice.ControlTransfer(ref usbSetupPacket, Values, Values.Length, out Length);
                double db = (Values[0] + ((Values[1] & 3) * 256)) * 0.1 + 30;
                if (LastValue == db)
                    continue;
                LastValue = db;
                if (Noise_Queue.Count != 15)
                {
                    Noise_Queue.Enqueue(LastValue);
                }
                else
                {
                    Noise_Queue.Enqueue(LastValue);
                    Noise_Queue.Dequeue();
                }
                Soundlevel = Calc_Soundlevel();
                noise_lbl.Invoke(temp1, new object[] { });
                Slevel_lbl.Invoke(temp2, new object[] { });
                SendSlevel((int)Soundlevel);
            }
        }

        public void noise2invoke()
        {
            noise_lbl.Text = LastValue.ToString();
        }
        public void slevel2invoke()
        {
            Slevel_lbl.Text = Soundlevel.ToString();
        }

        public double Calc_Soundlevel()
        {
            double m_noise = 0;
            foreach (double item in Noise_Queue)
            {
                Console.Write(item.ToString() + " ");
                m_noise += item;
            }
            Console.WriteLine();
            return (m_noise / Noise_Queue.Count) * 1.44 - 59.227;

        }

        private void scn_Button_Click(object sender, EventArgs e)
        {
            if (scn_Button.Text == "Output Off")
            {
                scn_Button.Text = "Output On";
                scn_Button.BackColor = Color.Red;
                ModifyScnType(1);
            }
            else
            {
                scn_Button.Text = "Output Off";
                scn_Button.BackColor = Color.Gray;
                ModifyScnType(0);
            }
        }
    }
}