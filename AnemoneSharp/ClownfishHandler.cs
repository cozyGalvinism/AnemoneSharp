using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnemoneSharp;

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

        public void ChangeVoiceCustomPitch(float pitch)
        {
            SendCommand(XCommand.VoiceChanger, 13, pitch.Clamp(-15f, 15f));
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
            SendCommand(XCommand.ClownfishControl, (int)status);
        }

        public void ControlMusic(MusicStatus status)
        {
            SendCommand(XCommand.MusicControl, (int)status);
        }

        private void SendCommand(XCommand x, params object[] args)
        {
            string commandArgs = string.Join("|", args.Select(arg => arg.ToString()));
            string sendCommand = $"{(int) x}|{commandArgs}";
            sendCommand = Encoding.UTF8.GetString(Encoding.Default.GetBytes(sendCommand));
            COPYDATASTRUCT cds = new COPYDATASTRUCT
            {
                dwData = new IntPtr(42), cbData = sendCommand.Length, lpData = sendCommand
            };

            UnsafeMethods.SendMessage(new IntPtr(_clownfishWnd), WM_COPYDATA, IntPtr.Zero, ref cds);
        }

        private void SendCommand(int x, params object[] args)
        {
            string commandArgs = string.Join("|", args.Select(arg => arg.ToString()));
            string sendCommand = $"{x}|{commandArgs}";
            sendCommand = Encoding.UTF8.GetString(Encoding.Default.GetBytes(sendCommand));
            COPYDATASTRUCT cds = new COPYDATASTRUCT
            {
                dwData = new IntPtr(42),
                cbData = sendCommand.Length,
                lpData = sendCommand
            };

            UnsafeMethods.SendMessage(new IntPtr(_clownfishWnd), WM_COPYDATA, IntPtr.Zero, ref cds);
        }
    }
}
