using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownfishAPI
{
    public class ClownfishHandler
    {
        private int _clownfishWnd;
        private const Int32 WM_COPYDATA = 0x4A;
        public ClownfishHandler()
        {
            _clownfishWnd = UnsafeMethods.FindWindow("CLOWNFISHVOICECHANGER", "Clownfish Voice Changer");
        }

        public void PlayFile(string path)
        {
            SendCommand(XCommand.Music, path);
        }

        public void StopMusic()
        {
            SendCommand(XCommand.Music, "");
        }

        public void SendTTS(string text)
        {
            SendCommand(XCommand.TTS, text);
        }

        public void ControlClownfish(ClownfishStatus status)
        {
            SendCommand(XCommand.ClownfishControl, status);
        }

        private void SendCommand(XCommand x, string y)
        {
            string sendCommand = string.Format("{0}|{1}", (int)x, y);
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = new IntPtr(42);
            cds.cbData = sendCommand.Length;
            cds.lpData = sendCommand;

            UnsafeMethods.SendMessage(new IntPtr(_clownfishWnd), WM_COPYDATA, IntPtr.Zero, ref cds);
        }

        private void SendCommand(XCommand x, ClownfishStatus y)
        {
            string sendCommand = string.Format("{0}|{1}", (int)x, (int)y);
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = new IntPtr(42);
            cds.cbData = sendCommand.Length;
            cds.lpData = sendCommand;

            UnsafeMethods.SendMessage(new IntPtr(_clownfishWnd), WM_COPYDATA, IntPtr.Zero, ref cds);
        }
    }
}
