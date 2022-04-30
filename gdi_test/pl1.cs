using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gdi_test
{
    public partial class pl1 : Form
    {
        public pl1()
        {
            InitializeComponent();
        }

        public static Cursor CreateCursor(Bitmap bm, Size size)
        {
            bm = new Bitmap(bm, size);
            return new Cursor(bm.GetHicon()); //get cursor icon
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();//random class
            int num = random.Next(0, 150);
            int num1 = random.Next(0, 150);
            int num2 = random.Next(0, 150);
            int num3 = random.Next(0, 150);
            //random numbers
            Bitmap bmp1 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            Bitmap bmp2 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(num, num3, num1, num2, bmp.Size);
            g.CopyFromScreen(num3, num2, num, num1, bmp.Size);
            //get screenshot
            int width = random.Next(900, 1500);
            int height = random.Next(490, 800);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Random rnrnr = new Random();
                    //Color p = bmp.GetPixel(x -1, y );
                    Color p = bmp.GetPixel(rnrnr.Next(100, 900), rnrnr.Next(100, 600));


                    int a = p.A;
                    int r = p.R;
                    int gr = p.G;
                    int b = p.B;


                    r = 255 - r;
                    gr = 255 - gr;
                    b = 255 - b;


                    bmp.SetPixel(rnrnr.Next(12, 999), rnrnr.Next(12, 700), Color.FromArgb(a, r, gr, b));
                    bmp2.SetPixel(rnrnr.Next(3, 912), rnrnr.Next(12, 700), Color.FromArgb(a, r, gr, b));
                    bmp1.SetPixel(rnrnr.Next(36, 999), rnrnr.Next(12, 700), Color.FromArgb(a, r, gr, b));

                }
                pictureBox2.Location = Cursor.Position;
                pictureBox1.Image = bmp2;
                pictureBox4.Image = bmp;
                pictureBox3.Image = bmp1;

            }
            //change every pixel until all the area becomes inverted and then put the screenshot on screen
            this.Cursor = CreateCursor((Bitmap)imglist1.Images[0], new Size(32, 32));//set cursor to error icon from imagelist

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rndon = new Random();
            this.Location = new Point(rndon.Next(0, 900), rndon.Next(0, 720));

        }
    }
}
