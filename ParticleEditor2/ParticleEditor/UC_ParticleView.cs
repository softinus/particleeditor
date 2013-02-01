using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph.Assets;



namespace ParticleEditor
{

    public partial class UC_ParticleView : UserControl
    {
        Particle m_Particle = null;

        public UC_ParticleView()
        {
            InitializeComponent();

            OpenGL gl = openGLControl.OpenGL;
            m_Particle = new Particle(gl);

        }

        private void openGLControl_SizeChanged(object sender, EventArgs e)
        {
            //opengl setting
            OpenGL gl = openGLControl.OpenGL;

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.ShadeModel(OpenGL.GL_SMOOTH);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Disable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);	

            double dX01 = -1.0;
            double dX02 = 1.0;
            double dY01 = -1.0;
            double dY02 = 1.0;

            double dHeight = (double)this.Size.Height;
            double dWidth = (double)this.Size.Width;

            double dMainRatio = dHeight / dWidth;
            double dGLRatio = (((dY02 - dY01)) / ((dX02 - dX01)));
            double dRatio = 0.0;

            gl.Viewport(0, 0, (int)dWidth, (int)dHeight);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            if (dGLRatio > dMainRatio)
            {
                dRatio = ((dY02 - dY01)) / dHeight;

                dX01 = (((dX02 + dX01) - (dRatio * dWidth)) * 0.5);
                dX02 = (((dX02 + dX01) + (dRatio * dWidth)) * 0.5);

                gl.Ortho(dX01, dX02, dY01, dY02, -1, 1);
            }
            else
            {
                dRatio = ((dX02 - dX01)) / dWidth;

                dY01 = ((dY02 + dY01) - (dRatio * dHeight)) * 0.5;
                dY02 = ((dY02 + dY01) + (dRatio * dHeight)) * 0.5;

                gl.Ortho(dX01, dX02, dY01, dY02, -1, 1);
            }

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

        }

        
        private void openGLControl_OpenGLDraw(object sender, PaintEventArgs e)
        {
            if (m_Particle.particleData.TextureInit)
                m_Particle.SetTexture(m_Particle.particleData.Texture);

            OpenGL gl = openGLControl.OpenGL; 
            
            gl.ClearColor(m_Particle.particleData.BackgroundR, m_Particle.particleData.BackgroundG, m_Particle.particleData.BackgroundB, 1.0f);
            gl.LoadIdentity();
            
            m_Particle.Update(ref gl);
            
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); 
            gl.PushMatrix();
            
            gl.Begin(OpenGL.GL_QUADS);
            
            m_Particle.Draw();
            
            gl.End();
            gl.PopMatrix();
        }

  
        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {

        }

        private void SetBackGroundColor(float _fR, float _fG, float _fB)
        {

        }

        public void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        //DataSetting
        //Tab01 4
        internal void SetBackR(float _fBackR)
        {
            m_Particle.particleData.BackgroundR = _fBackR;
        }
        internal void SetBackG(float _fBackG)
        {
            m_Particle.particleData.BackgroundG = _fBackG; 
        }
        internal void SetBackB(float _fBackB)
        {
            m_Particle.particleData.BackgroundB = _fBackB;
        }
        internal void SetTexture(string _szTexture)
        {
            m_Particle.particleData.TextureInit = true;
            m_Particle.particleData.Texture = _szTexture;
        }

        //Tab02 14
        internal void SetEmitterType(string _szEmitterType)
        {
            //ParticleData.EmitterType = _szEmitterType;
        }
        internal void SetMaxParticles(float _fMaxParticles)
        {
            m_Particle.particleData.MaxParticles = (int)_fMaxParticles;
            m_Particle.particleData.ParticleInit = true;
        }
        internal void SetBarToBoxLifespan(float _fLifespan)
        {
            m_Particle.particleData.Lifespan = _fLifespan;
        }
        internal void SetLifespanVar(float _fLifespanVar)
        {
            //ParticleData.LifespanVariance = _fLifespanVar;
        }
        internal void SetStartSize(float _fStartSize)
        {
            m_Particle.particleData.StartSize = _fStartSize;
        }
        internal void SetStartSizeVar(float _fStartSizeVar)
        {
            //ParticleData.StartSizeVariance = _fStartSizeVar;
        }
        internal void SetFinishSize(float _fFinishSize)
        {
            m_Particle.particleData.FinishSize = _fFinishSize;
        }
        internal void SetFinishSizeVar(float _fFinishSizeVar)
        {
            //ParticleData.FinishSizeVariance = _fFinishSizeVar;
        }
        internal void SetEmitterAngle(float _fEmitterAngle)
        {
            m_Particle.particleData.EmitterAngle = _fEmitterAngle;
        }
        internal void SetAngleVar(float _fAngleVar)
        {
            //ParticleData.AngleVariance = _fAngleVar;
        }
        internal void SetStartRot(float _fStartRot)
        {
            //ParticleData.StartRot = _fStartRot;
        }
        internal void SetStartRotVar(float _fStartRotVar)
        {
            //ParticleData.StartRotVar = _fStartRotVar;
        }
        internal void SetEndRot(float _fEndRot)
        {
            //ParticleData.EndRot = _fEndRot;
        }
        internal void SetEndRotVar(float _fEndRotVar)
        {
            //ParticleData.EndRotVar = _fEndRotVar;
        }

        //Tab03 15
        internal void SetXVariance(float _fXVariance)
        {
            //ParticleData.XVariance = _fXVariance;
        }
        internal void SetYVariance(float _fYVariance)
        {
            //ParticleData.YVariance = _fYVariance;
        }
        internal void SetSpeed(float _fSpeed)
        {
            //ParticleData.Speed = _fSpeed;
        }
        internal void SetSpeedVariance(float _fSpeedVar)
        {
            //ParticleData.SpeedVariance = _fSpeedVar;
        }
        internal void SetGravityX(float _fGravityX)
        {
            //ParticleData.GravityX = _fGravityX;
        }
        internal void SetGravityY(float _fGravityY)
        {
            //ParticleData.GravityY = _fGravityY;
        }
        internal void SetTanAcc(float _fTanAcc)
        {
            //ParticleData.TanAcc = _fTanAcc;
        }
        internal void SetTanAccVar(float _fTanAccVar)
        {
            //ParticleData.TanAccVar = _fTanAccVar;
        }
        internal void SetRadAcc(float _fRadAcc)
        {
            //ParticleData.RadAcc = _fRadAcc;
        }
        internal void SetRadAccVar(float _fRadAccVar)
        {
            //ParticleData.RadAccVar = _fRadAccVar;
        }
        internal void SetMaxRadius(float _fMaxRadius)
        {
            //ParticleData.MaxRadius = _fMaxRadius;
        }
        internal void SetMaxRadiusVar(float _fMaxRadiusVar)
        {
            //ParticleData.MaxRadiusVariance = _fMaxRadiusVar;
        }
        internal void SetMinRadius(float _fMinRadius)
        {
            //ParticleData.MinRadius = _fMinRadius;
        }
        internal void SetDegSec(float _fDegSec)
        {
            //ParticleData.DegSec = _fDegSec;
        }
        internal void SetDegSecVar(float _fDegSecVar)
        {
            //ParticleData.DegSecVar = _fDegSecVar;
        }

        //Tab04
        internal void SetStartR(float _fStartR)
        {
            m_Particle.particleData.ColorStartR = _fStartR;
        }
        internal void SetStartG(float _fStartG)
        {
            m_Particle.particleData.ColorStartG = _fStartG;
        }
        internal void SetStartB(float _fStartB)
        {
            m_Particle.particleData.ColorStartB = _fStartB;
        }
        internal void SetStartA(float _fStartA)
        {
            m_Particle.particleData.ColorStartA = _fStartA;
        }
        internal void SetFinishR(float _fFinishR)
        {
            m_Particle.particleData.ColorFinishR = _fFinishR;
        }
        internal void SetFinishG(float _fFinishG)
        {
            m_Particle.particleData.ColorFinishG = _fFinishG;
        }
        internal void SetFinishB(float _fFinishB)
        {
            m_Particle.particleData.ColorFinishB = _fFinishB;
        }
        internal void SetFinishA(float _fFinishA)
        {
            m_Particle.particleData.ColorFinishA = _fFinishA;
        }

        //Tab05

        internal void SetStartVarR(float _fStartVarR)
        {
            //ParticleData.ColorStartVarR = _fStartVarR;
        }
        internal void SetStartVarG(float _fStartVarG)
        {
            //ParticleData.ColorStartVarG = _fStartVarG;
        }
        internal void SetStartVarB(float _fStartVarB)
        {
            //ParticleData.ColorStartVarB = _fStartVarB;
        }
        internal void SetStartVarA(float _fStartVarA)
        {
            //ParticleData.ColorStartVarA = _fStartVarA;
        }
        internal void SetFinishVarR(float _fFinishVarR)
        {
            //ParticleData.ColorFinishVarR = _fFinishVarR;
        }
        internal void SetFinishVarG(float _fFinishVarG)
        {
            //ParticleData.ColorFinishVarG = _fFinishVarG;
        }
        internal void SetFinishVarB(float _fFinishVarB)
        {
            //ParticleData.ColorFinishVarB = _fFinishVarB;
        }
        internal void SetFinishVarA(float _fFinishVarA)
        {
            //ParticleData.ColorFinishVarA = _fFinishVarA;
        }
        internal void SetSource(string _szSource)
        {
            //ParticleData.Source = _szSource;
        }
        internal void SetDest(string _szDest)
        {
            //ParticleData.Dest = _szDest;
        }

        //Window Control 관련 함수, 이벤트
    }
}
