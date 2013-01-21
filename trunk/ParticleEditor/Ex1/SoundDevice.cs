using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectSound;

namespace Ex1
{
    class SoundDevice
    {
  
        Microsoft.DirectX.DirectSound.Device m_SndDev = new Microsoft.DirectX.DirectSound.Device();
        static readonly SoundDevice m_Snd = new SoundDevice();

        private SoundDevice()
        {
            
        }

        public static SoundDevice GetInstance()
        {
            return m_Snd;
        }

        public void InitDS(Form1 Parent)
        {
            m_SndDev.SetCooperativeLevel(Parent, CooperativeLevel.Normal);
        }

        public Device GetDevice()
        {
            return m_SndDev;
        }


    
    }
}
