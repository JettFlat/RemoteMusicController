using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteMusicController
{
    public static class KeyBoardSimulator
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        public static void PressButton(byte code)
        {
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            keybd_event(code, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
        }
    }
    public class KButton
    {

        public Button Button { get; private set; }
        public byte Code { get; private set; }
        public KButton(Button Button, int Code)
        {
            this.Button = Button;
            this.Code = (byte)Code;
        }
        public void Press()
        {
            KeyBoardSimulator.PressButton(Code);
        }
        public static List<KButton> List { get; } = new List<KButton> { 
            new KButton(Button.Play_Pause, (byte)0xB3), 
            new KButton(Button.VolumeUp, (byte)0xAF), 
            new KButton(Button.VolumeDown, (byte)0xAE), 
            new KButton(Button.Next, (byte)0xB0), 
            new KButton(Button.Prev, (byte)0xB1) };

    }
    public enum Button
    {
        Play_Pause,
        VolumeUp,
        VolumeDown,
        Next,
        Prev,
    }
}
