using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.Direct3D;

namespace Ex1
{
    class Particle
    {
        /// <summary>
        /// ParticleColor
        /// </summary>
        /// <returns>Color of the particle</returns>
        public Color ParticleColor
        {
            get { return ClrColor; }
            set { ClrColor = value; }
        }

        /// <summary>
        /// VelocityX
        /// </summary>
        /// <returns>X velocity</returns>
        public float VelocityX
        {
            get { return fVelocityX; }
            set { fVelocityX = value; }
        }

        /// <summary>
        /// VelocityY
        /// </summary>
        /// <returns>Y velocity</returns>
        public float VelocityY
        {
            get { return fVelocityY; }
            set { fVelocityY = value; }
        }

        /// <summary>
        /// CurrentLife
        /// </summary>
        /// <returns>Current particle life</returns>
        public float CurrentLife
        {
            get { return fCurLife; }
            set { fCurLife = value; }
        }

        /// <summary>
        /// MaxLife
        /// </summary>
        /// <returns>Max life expectancy of the particle</returns>
        public float MaxLife
        {
            get { return fMaxLife; }
            set { fMaxLife = value; }
        }

        /// <summary>
        /// Y
        /// </summary>
        /// <returns>Y position</returns>
        public float Y
        {
            get { return fPosY; }
            set { fPosY = value; }
        }

        /// <summary>
        /// X
        /// </summary>
        /// <returns>X position</returns>
        public float X
        {
            get { return fPosX; }
            set { fPosX = value; }
        }

        /// <summary>
        /// Gravity
        /// </summary>
        /// <returns>Gravitational force applied to the particle</returns>
        public float Gravity
        {
            get { return fGravity; }
            set { fGravity = value; }
        }

        /// <summary>
        /// Scale
        /// </summary>
        /// <returns>Scale</returns>
        public float Scale
        {
            get { return fCurrentScale; }
            set { fCurrentScale = value; }
        }

        /// <summary>
        /// Inertia
        /// </summary>
        /// <returns>Inertial force on the particle</returns>
        public float Inertia
        {
            get { return fInertia; }
            set { fInertia = value; }
        }

        /// <summary>
        /// CurrentScale
        /// </summary>
        /// <returns>Current particle scale</returns>
        public float CurrentScale
        {
            get { return fCurrentScale; }
            set { fCurrentScale = value; }
        }

        float fMaxLife;
        float fVelocityX;
        float fVelocityY;
        float fGravity;
        float fWind;
        float fStartScale;
        float fEndScale;
        float fCurLife;
        float fPosX;
        float fPosY;
        float fCurrentScale;
        float fInertia;
        Color ClrColor;
        Emitter ParentEmitter;

        /// <summary>
        /// Updates the particle logic.
        /// </summary>
        /// <param name="dt">Delta Time</param>
        /// <returns>void</returns>
        public void Update(float dt)
        {
            //Calculate Inertia
            if (VelocityX > 0)
            {
                VelocityX -= Inertia;
                if (VelocityX < 0)
                    VelocityX = 0;
            }
            else if(VelocityX < 0)
            { 
                VelocityX += Inertia;
                if (VelocityX > 0)
                    VelocityX = 0;
            }

            if (VelocityY > 0)
            {
                VelocityY -= Inertia;
                if (VelocityY < 0)
                    VelocityY = 0;
            }
            else if (VelocityY < 0)
            {
                VelocityY += Inertia;
                if (VelocityY > 0)
                    VelocityY = 0;
            }
            
            //calculate gravity
            VelocityY += fGravity * dt;

            //calculate wind
            VelocityX += fWind * dt;

            //calculate movement by velocity
            fPosX += VelocityX * dt;
            fPosY += VelocityY * dt;

            //calculate life
            fCurLife -= dt;
            if (fCurLife < 0)
                fCurLife = 0;
           
            //Calculate interpolation
            float fAmount = fCurLife / fMaxLife;

            float A = ParentEmitter.EndColor.A + fAmount * (ParentEmitter.StartColor.A - ParentEmitter.EndColor.A);
            float R = ParentEmitter.EndColor.R + fAmount * (ParentEmitter.StartColor.R - ParentEmitter.EndColor.R);
            float G = ParentEmitter.EndColor.G + fAmount * (ParentEmitter.StartColor.G - ParentEmitter.EndColor.G);
            float B = ParentEmitter.EndColor.B + fAmount * (ParentEmitter.StartColor.B - ParentEmitter.EndColor.B);

            if (A < 0) { A = 0; }
            else if (A > 255) { A = 255; }
            if (R > 255) { R = 255; }
            else if (R < 0) { R = 0; }
            if (G > 255) { G = 255; }
            else if (G < 0) { G = 0; }
            if (B > 255) { B = 255; }
            else if (B < 0) { B = 0; }
            
            ClrColor = Color.FromArgb((int)A, (int)R, (int)G, (int)B);

            //Calculate scale
            fCurrentScale = fEndScale + fAmount * (fStartScale - fEndScale);

        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Parent">Reference to the parent emitter</param>
        /// <param name="Inertia">Inertial force to apply</param>
        /// <param name="Wind">Wind force to apply</param>
        /// <param name="VelocityX">X velocity to apply</param>
        /// <param name="VelocityY">Y velocity to apply</param>
        /// <param name="Gravity">Gravitational force to apply</param>
        /// <param name="StartScale">Starting scale</param>
        /// <param name="EndScale">Ending Scale</param>
        /// <param name="PosX">X position</param>
        /// <param name="PosY">Y position</param>
        /// <param name="MaxLife">Max Life expectancy</param>
        /// <param name="Color">Color</param>
        /// <returns>void</returns>
        public Particle(Emitter Parent,float Inertia, float Wind, float VelocityX, float VelocityY,float Gravity,float StartScale,float EndScale ,float MaxLife, int PosX, int PosY, Color Color)
        {
            fVelocityX = VelocityX;
            fVelocityY = VelocityY;
            fGravity = Gravity;
            fMaxLife = MaxLife;
            fCurLife = MaxLife;
            fInertia = Inertia;
            fWind = Wind;
            fPosX = PosX;
            fPosY = PosY;
            ClrColor = Color;
            fStartScale = StartScale;
            fCurrentScale = StartScale;
            fEndScale = EndScale;
            ParentEmitter = Parent;
        }
    }
}
