using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AForgeTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        Bitmap GetPlayerArea()
        {
            Point l = new Point(1830, 100);
            Size s = new Size(20, 20);
            return RSVision.GetBitmap(l, s);
        }
        Bitmap GetScreenArea()
        {
            Point l = new Point(1780, 50);
            Size s = new Size(100, 100);
            return RSVision.GetBitmap(l, s);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Cursor.Position.ToString();
        }

        Bitmap Screen;
        private void button1_Click(object sender, EventArgs e)
        {
            Screen = GetScreenArea();

        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var area = GetPlayerArea();
            RSVision.Compare(Screen, area);
            Console.WriteLine("TIME = " + sw.ElapsedMilliseconds);

        }
    }
}
