/// <summary>
/// File: “Emitter.cs?
/// Author: Kelvin Bonilla
/// Purpose: Emitter for the particle effect.
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using System.Runtime.InteropServices;    // for PInvoke

using Microsoft.Win32;    // RegistryKey

namespace Ex1
{
    class Emitter
    {


        /// <summary>
        /// ParticleList
        /// </summary>
        /// <returns>List containing all the particles</returns>
        internal List<Particle> ParticleList
        {
            get { return Particles; }
            set { Particles = value; }
        }

        /// <summary>
        /// NumberParticles
        /// </summary>
        /// <returns>Number of particles</returns>
        public int NumberParticles
        {
            get { return m_nNumParticles; }
            set { m_nNumParticles = value; }
        }


        /// <summary>
        /// CurrentParticleCount
        /// </summary>
        /// <returns>Count of the current number of particles on the screen</returns>
        public int CurrentParticleCount
        {
            get { return Particles.Count; }
        }


        /// <summary>
        /// ImageID
        /// </summary>
        /// <returns>Image ID for the particle</returns>
        public int ImageID
        {
            get { return m_nImageID; }
            set { m_nImageID = value; }
        }


        /// <summary>
        /// Position
        /// </summary>
        /// <returns>Position of the emitter on the screen</returns>
        public Point Position
        {
            get { return new Point(m_nPosX, m_nPosY); }
            set { m_nPosX = value.X; m_nPosY = value.Y; }
        }


        /// <summary>
        /// MinLife
        /// </summary>
        /// <returns>Minimum Life of the particle</returns>
        public float MinLife
        {
            get { return m_fMinLife; }
            set { m_fMinLife = value; }
        }

        /// <summary>
        /// MaxLife
        /// </summary>
        /// <returns>Maximum Life of the particle</returns>
        public float MaxLife
        {
            get { return m_fMaxLife; }
            set { m_fMaxLife = value; }
        }


        /// <summary>
        /// MinVelocityX
        /// </summary>
        /// <returns>Minimum Possible X velocity for the particles</returns>
        public float MinVelocityX
        {
            get { return m_fMinVelocityX; }
            set { m_fMinVelocityX = value; }
        }

        /// <summary>
        /// MaxVelocityX
        /// </summary>
        /// <returns>Maximum possible X velocity for the particles</returns>
        public float MaxVelocityX
        {
            get { return m_fMaxVelocityX; }
            set { m_fMaxVelocityX = value; }
        }

        /// <summary>
        /// MinVelocityY
        /// </summary>
        /// <returns>Minimum possible Y velocity for the particles</returns>
        public float MinVelocityY
        {
            get { return m_fMinVelocityY; }
            set { m_fMinVelocityY = value; }
        }

        /// <summary>
        /// MaxVelocityY
        /// </summary>
        /// <returns>Maximum possible Y velocity for the particles</returns>
        public float MaxVelocityY
        {
            get { return m_fMaxVelocityY; }
            set { m_fMaxVelocityY = value; }
        }

        /// <summary>
        /// StartMinScale
        /// </summary>
        /// <returns>Minimum start scale for the particles</returns>
        public float StartMinScale
        {
            get { return m_fStartMinScale; }
            set { m_fStartMinScale = value; }
        }

        /// <summary>
        /// StartMaxScale
        /// </summary>
        /// <returns>Max possible starting scale</returns>
        public float StartMaxScale
        {
            get { return m_fStartMaxScale; }
            set { m_fStartMaxScale = value; }
        }

        /// <summary>
        /// EndMinScale
        /// </summary>
        /// <returns>Minimum end scale</returns>
        public float EndMinScale
        {
            get { return m_fEndMinScale; }
            set { m_fEndMinScale = value; }
        }

        /// <summary>
        /// EndMaxScale
        /// </summary>
        /// <returns>max end scale</returns>
        public float EndMaxScale
        {
            get { return m_fEndMaxScale; }
            set { m_fEndMaxScale = value; }
        }

        /// <summary>
        /// Gravity
        /// </summary>
        /// <returns>Gravitational force applied on the particles</returns>
        public float Gravity
        {
            get { return m_fGravity; }
            set { m_fGravity = value; }
        }

        /// <summary>
        /// Inertia
        /// </summary>
        /// <returns>Force of inertia applied to the particles</returns>
        public float Inertia
        {
            get { return m_fInertia; }
            set { m_fInertia = value; }
        }

        /// <summary>
        /// EndColor
        /// </summary>
        /// <returns>Ending color for all particles</returns>
        public Color EndColor
        {
            get { return m_clrEnd; }
            set { m_clrEnd = value; }
        }

        /// <summary>
        /// StartColor
        /// </summary>
        /// <returns>Starting color for all particles</returns>
        public Color StartColor
        {
            get { return m_clrStart; }
            set { m_clrStart = value; }
        }

        /// <summary>
        /// Height
        /// </summary>
        /// <returns>Height of the emitter</returns>
        public int Height
        {
            get { return m_nHeight; }
            set { m_nHeight = value; }
        }

        /// <summary>
        /// Width
        /// </summary>
        /// <returns>Width of the emitter</returns>
        public int Width
        {
            get { return m_nWidth; }
            set { m_nWidth = value; }
        }

        /// <summary>
        /// X
        /// </summary>
        /// <returns>X position for the particle</returns>
        public int X
        {
            get { return m_nPosX; }
            set { m_nPosX = value; }
        }


        /// <summary>
        /// Y
        /// </summary>
        /// <returns>Y position for the particle</returns>
        public int Y
        {
            get { return m_nPosY; }
            set { m_nPosY = value; }
        }

        /// <summary>
        /// EmissionSpeed
        /// </summary>
        /// <returns>How many particles burst per update</returns>
        public int EmissionSpeed
        {
            get { return m_nEmissionSpeed; }
            set { m_nEmissionSpeed = value; }
        }

        /// <summary>
        /// Wind
        /// </summary>
        /// <returns>Wind force on particles</returns>
        public float Wind
        {
            get { return m_fWind; }
            set { m_fWind = value; }
        }

        /// <summary>
        /// EmitMode
        /// </summary>
        /// <returns>Mode of emission [Stream/Burst]</returns>
        public int EmitMode
        {
            get { return m_nEmitMode; }
            set { m_nEmitMode = value; }
        }

        public int AnimationType
        {
            get { return m_nAnimationType; }
            set { m_nAnimationType = value; }
        }


        /// <summary>
        /// Events
        /// </summary>
        /// <returns>List of event for triggers</returns>
        internal List<Event> Events
        {
            get { return ParticleEvents; }
            set { ParticleEvents = value; }
        }

        SGD.ManagedTextureManager m_TM = SGD.ManagedTextureManager.Instance;
        SGD.ManagedDirect3D m_D3D = SGD.ManagedDirect3D.Instance;
        List<Particle> Particles = new List<Particle>();
        List<Event> ParticleEvents = new List<Event>();
        Color m_clrStart = new Color();
        Color m_clrEnd = new Color();
        Random m_Randomizer = new Random();
        Form1 m_ParentForm;
        float m_fMinLife = new float();
        float m_fMaxLife = new float();
        int m_nPosX = new int();
        int m_nPosY = new int();
        int m_nWidth = new int();
        int m_nHeight = new int();
        int m_nImageID = new int();
        int m_nNumParticles = new int();
        int m_nEmissionSpeed = new int();
        int m_nEmitMode = new int();
        int m_nAnimationType = new int();
        float m_fMinVelocityX = new float();
        float m_fGravity = new float();
        float m_fWind = new float();
        float m_fStartMaxScale = new float();
        float m_fStartMinScale = new float();
        float m_fEndMaxScale = new float();
        float m_fEndMinScale = new float();
        float m_fMaxVelocityY = new float();
        float m_fMinVelocityY = new float();
        float m_fMaxVelocityX = new float();
        float m_fInertia = new float();

        /// <summary>
        /// Emitter
        /// </summary>
        /// <param name="ParticleAmount">Amount of particles to start with.</param>
        /// <param name="Parent">Reference to the parent form</param>
        /// <returns>List of event for triggers</returns>
        public Emitter(int ParticleAmount, Form1 Parent)
        {
            //TODO: Initialize all variables before the loop          
            m_clrStart = Color.FromArgb(255, 0, 255, 255);
            m_clrEnd = Color.FromArgb(255, 255, 255, 255);
            m_fGravity = 0;
            m_fMaxVelocityX = 100;
            m_fMaxVelocityY = 100;
            m_fMinVelocityX = 5;
            m_fMinVelocityY = 5;
            m_fStartMinScale = 1;
            m_fStartMaxScale = 2;
            m_fEndMaxScale = 0;
            m_fEndMinScale = 0;
            m_fMaxLife = 10;
            m_fMinLife = 5;
            m_nPosX = 20;
            m_nPosY = 20;
            m_nWidth = 10;
            m_nHeight = 5;
            m_nEmissionSpeed = 1;
            m_nNumParticles = ParticleAmount;
            m_ParentForm = Parent;
            m_nEmitMode = (int)Form1.EMIT_MODE.STREAM;
        }

        /// <summary>
        /// Creates a random float.
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>Random float</returns>
        public float RandFloat(float min, float max)
        {
            return (max - min) * (float)m_Randomizer.NextDouble() + min;
        }

        /// <summary>
        /// Creates a random int.
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>Random int</returns>
        public int RandInt(int min, int max)
        {
            return m_Randomizer.Next(min, max);
        }

        /// <summary>
        /// Updates the particle logic.
        /// </summary>
        /// <param name="dt">Delta Time</param>
        /// <returns>void</returns>
        public void Update(float dt)
        {
            //Move and Kill Particles
            for (int i = 0; i < Particles.Count; ++i)
            {
                Particles[i].Update(dt);

                if (Particles[i].CurrentLife <= 0)
                {
                    Particles.Remove(Particles[i]);
                }
            }

            //Add New Particles
            if (m_ParentForm.IsEmitting)
            {
                switch (m_nEmitMode)
                {
                    case (int)Form1.EMIT_MODE.STREAM:
                        if (Particles.Count < m_nNumParticles)
                        {
                            for (int i = 0; i < m_nEmissionSpeed; ++i)
                            {
                                AddParticle();
                                if (Particles.Count >= m_nNumParticles)
                                {
                                    break;
                                }
                            }
                        }
                        break;

                    case (int)Form1.EMIT_MODE.BURST:
                        if (Math.Abs(Particles.Count - m_nNumParticles) >= m_nEmissionSpeed)
                        {
                            for (int i = 0; i < m_nEmissionSpeed; ++i)
                            {
                                AddParticle();
                            }
                        }
                        break;
                }
            }
            m_ParentForm.ParticleCountLabel.Text = Particles.Count.ToString();
        }

        /// <summary>
        /// Renders all particles to the screen.
        /// </summary>
        /// <returns>void</returns>
        public void Render()
        {
            for (int i = 0; i < Particles.Count; ++i)
            {
                m_TM.Draw(m_nImageID,
                    (int)Particles[i].X,
                    (int)Particles[i].Y,
                    Particles[i].Scale,
                    Particles[i].Scale,
                    Rectangle.Empty,
                    0, 0, 0, Particles[i].ParticleColor.ToArgb());
            }
        }

        /// <summary>
        /// Adds a new particle to the emitter with the ongoing emitter settings
        /// </summary>
        /// <returns>void</returns>
        public void AddParticle()
        {
            float m_fRoundScale = RandFloat(m_fStartMinScale, m_fStartMaxScale);
            Particles.Add(new Particle(
            this,
            m_fInertia,
            m_fWind,
            RandFloat(m_fMinVelocityX, m_fMaxVelocityX),
            RandFloat(m_fMinVelocityY, m_fMaxVelocityY),
            m_fGravity,
            RandFloat(m_fStartMinScale, m_fStartMaxScale),
            RandFloat(m_fEndMinScale, m_fEndMaxScale),
            RandFloat(m_fMinLife, m_fMaxLife),
            RandInt(m_nPosX, m_nPosX + m_nWidth),
            RandInt(m_nPosY, m_nPosY + m_nHeight),
            m_clrStart));

        }
    }
}
