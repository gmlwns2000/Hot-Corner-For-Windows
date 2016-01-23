using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace HotCorner
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte vk, byte scan, int flags, ref int extrainfo);
         
        static void Main(string[] args)
        {
            bool on = false;
            while (true)
            {
                Thread.Sleep(1);
                if(Cursor.Position.Y == 0 && Screen.PrimaryScreen.Bounds.Width - 1 == Cursor.Position.X)
                {
                    if (!on)
                    {
                        on = true;
                        const byte VK_LWIN = 0x5B;
                        const byte VK_TAB = 0x09;
                        const int KEYUP = 0x02;
                        int Info = 0;
                        keybd_event(VK_LWIN, 0, 0, ref Info);
                        keybd_event(VK_TAB, 0, 0, ref Info);
                        keybd_event(VK_LWIN, 0, KEYUP, ref Info);
                        keybd_event(VK_TAB, 0, KEYUP, ref Info);
                    }
                }
                else
                {
                    if (on)
                    {
                        on = false;
                    }
                }
            }
        }
    }
}
