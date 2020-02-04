using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteMusicController
{
    public class KeyBoardSimulator
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        public static void PressButton()
        {
            const int VK_VOLUME_UP = 0xAF;
            const int VK_SPACE = 0x20;
            const int VK_MEDIA_PLAY_PAUSE = 0xB3;
            const int VK_VOLUME_DOWN = 0xAE;
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            for (int i = 0; i < 10; i++)
            {
                keybd_event((byte)VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
    public class KButton
    {
        public string Name { get; private set; }
        public byte Code { get; private set; } 
        public KButton(string Name,int Code)
        {
            this.Name = Name;
            this.Code = (byte)Code;
        }

    }
}
