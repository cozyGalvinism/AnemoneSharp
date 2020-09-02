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
            SendCommand(XCommand.AudioFile, path);
        }

        public void StopMusic()
        {
            SendCommand(XCommand.AudioFile, "");
        }

        public void SendTTS(string text)
        {
            SendCommand(XCommand.TTS, text);
        }

        public void ChangeVoice(int voice)
        {
            SendCommand(XCommand.VoiceChanger, voice.ToString());
        }

        public void SetEffect(int effect)
        {
            SendCommand(XCommand.SoundFX, effect.ToString());
        }

        public void SetVolume(int volume)
        {
            int finalVol = Math.Min(volume, 100);
            SendCommand(XCommand.SoundVolume, finalVol.ToString());
        }

        public void EnableVST(string action)
        {
            SendCommand(XCommand.VST, action);
        }

        public void ControlClownfish(ClownfishStatus status)
        {
            SendCommand(XCommand.ClownfishControl, status);
        }

        private void SendCommand(XCommand x, string y)
        {
            string sendCommand = $"{(int) x}|{y}";
            sendCommand = Encoding.UTF8.GetString(Encoding.Default.GetBytes(sendCommand));
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = new IntPtr(42);
            cds.cbData = sendCommand.Length;
            cds.lpData = sendCommand;

            UnsafeMethods.SendMessage(new IntPtr(_clownfishWnd), WM_COPYDATA, IntPtr.Zero, ref cds);
        }

        private void SendCommand(XCommand x, ClownfishStatus y)
        {
            string sendCommand = $"{(int) x}|{(int) y}";
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = new IntPtr(42);
            cds.cbData = sendCommand.Length;
            cds.lpData = sendCommand;

            UnsafeMethods.SendMessage(new IntPtr(_clownfishWnd), WM_COPYDATA, IntPtr.Zero, ref cds);
        }
    }
}
