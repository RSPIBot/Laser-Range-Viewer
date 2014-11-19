using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Laser_range_vieuwer
{
    public partial class Form1 : Form
    {
        double[] rangeValues;
        bool connected = false;
        public Form1()
        {
            InitializeComponent();

            txt_ip.Text = "192.168.1.50";
            txt_port.Text = "5000";
            Debug.WriteLine("Aplication starting");
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            Debug.WriteLine("Connecting to server " + txt_ip.Text + " on port "+Convert.ToInt32(txt_port.Text)+"");
            connected = true;
            int size = 400;
            rangeValues = new double[size];
            for (int i = 0; i < size; i++)
                rangeValues[i] = 10;
            DrawSinus(size);
            DrawRangeValues(size);
            DrawConvertedRangeValues(size);
        }

        private void DrawSinus(int n)
        {
            //chart1.Series["Series1"].Points.AddY((double)rpm);
            for(int i = 0; i< n; i++)
            {
                double point = Math.Sin(((double)i/(double)n)*Math.PI)*2+1;
                Debug.WriteLine("sin val "+point+ " at " + i);
                chart1.Series["sin(N) 0<N<PI"].Points.AddY(point);
            }
        }

        private void DrawRangeValues(int n)
        {
            //chart1.Series["Series1"].Points.AddY((double)rpm);
            for (int i = 0; i < n; i++)
            {
                chart1.Series["Laser Data"].Points.AddY(rangeValues[i]);
            }
        }

        private void DrawConvertedRangeValues(int n)
        {
            //chart1.Series["Series1"].Points.AddY((double)rpm);
            for (int i = 0; i < n; i++)
            {
                double point = rangeValues[i]/(Math.Sin(((double)i / (double)n) * Math.PI) * 2 + 1);
                chart1.Series["Converted Distence"].Points.AddY(point);
            }
        }
    }
}
//comport_box.Text
//rpm1 = Convert.ToInt32(serdata);
//chart1.Series["Series1"].Points.AddY((double)rpm);