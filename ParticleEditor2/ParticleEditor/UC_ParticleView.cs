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
        Particle ParticleData = null;
        Texture m_ttFigure = new Texture();

        List<TEST> star = new List<TEST>();
        class TEST				// Create A Structure For Star
        {
	        public int r, g, b;			// Stars Color
            public float dist,			// Stars Distance From Center
			        angle;			// Stars Current Angle
        }

        public UC_ParticleView()
        {
            InitializeComponent();

            ParticleData = new Particle();

            for (int i=0; i<50; i++)
	        {
                TEST T = new TEST();

                Random rnd1 = new Random();
                Random rnd2 = new Random();
                Random rnd3 = new Random();

                star.Add(T);
		        T.angle=0.0f;
		        T.dist=((float)i/50)*5.0f;
                T.r = rnd1.Next(0, 255) % 256;
                T.g = rnd2.Next(0, 255) % 256;
                T.b = rnd3.Next(0, 255) % 256;
	        }

            CreateTexture();
  
        }

        private void CreateTexture()
        {
            OpenGL gl = openGLControl.OpenGL;
            
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            m_ttFigure.Create(gl, "Star.bmp");
        }

        private void openGLControl_SizeChanged(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            

            gl.Viewport(0, 0, this.Size.Width, this.Size.Height);

            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            gl.Perspective(45.0f, (float)this.Size.Width / (float)this.Size.Height, 0.1f, 100.0f);

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
        }

        
        private void openGLControl_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;

            //gl.BindTexture(OpenGL.GL_TEXTURE_2D, m_ttFigure);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -0.0);
            
            m_ttFigure.Bind(gl);

            //gl.Begin(OpenGL.GL_QUADS);
            //gl.TexCoord(0.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, 0);	// Bottom Left Of The Texture and Quad
            //gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, -1.0f, 0);	// Bottom Right Of The Texture and Quad
            //gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 1.0f, 0);	// Top Right Of The Texture and Quad
            //gl.TexCoord(0.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, 0);	// Top Left Of The Texture and Quad
            //gl.End();

            float spin = 0.0f;
            for (int i=0; i < 50; i++)						// Loop Through All The Stars
	        {
		        gl.LoadIdentity();								// Reset The View Before We Draw Each Star
		        gl.Translate(0.0f,0.0f, -16);					// Zoom Into The Screen (Using The Value In 'zoom')
		        gl.Rotate(90,1.0f,0.0f,0.0f);					// Tilt The View (Using The Value In 'tilt')
		        gl.Rotate(star[i].angle,0.0f,1.0f,0.0f);		// Rotate To The Current Stars Angle
		        gl.Translate(star[i].dist,0.0f,0.0f);		// Move Forward On The X Plane
		        gl.Rotate(-star[i].angle,0.0f,1.0f,0.0f);	// Cancel The Current Stars Angle
		        gl.Rotate(-90,1.0f,0.0f,0.0f);				// Cancel The Screen Tilt
		

			        gl.Color(star[(50 - i)-1].r,star[(50 - i)-1].g,star[(50 - i)-1].b,255);
			        gl.Begin(OpenGL.GL_QUADS);
                    gl.TexCoord(0.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, 0.0f);
                    gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, -1.0f, 0.0f);
                    gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 1.0f, 0.0f);
                    gl.TexCoord(0.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, 0.0f);
			        gl.End();

		        gl.Rotate(spin,0.0f,0.0f,1.0f);

		        gl.Color(star[i].r,star[i].g,star[i].b,255);
		        gl.Begin(OpenGL.GL_QUADS);
                    gl.TexCoord(0.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, 0.0f);
                    gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, -1.0f, 0.0f);
                    gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 1.0f, 0.0f);
                    gl.TexCoord(0.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, 0.0f);
		        gl.End();

		        spin+=0.01f;
		        star[i].angle+= (float)i/50;
		        star[i].dist-=0.01f;
		        
                Random rnd1 = new Random();
                Random rnd2 = new Random();
                Random rnd3 = new Random();

                if (star[i].dist<0.0f)
		        {
			        star[i].dist+=5.0f;
			        star[i].r =  rnd1.Next(0,255) % 256;
			        star[i].g =  rnd2.Next(0,255) % 256;
			        star[i].b =  rnd3.Next(0,255) % 256;
		        }
	        }
            

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
        //    //  TODO: Set the projection matrix here.

        //    //  Get the OpenGL object.
        //    OpenGL gl = openGLControl.OpenGL;

        //    //  Set the projection matrix.
        //    gl.MatrixMode(OpenGL.GL_PROJECTION);

        //    //  Load the identity.
        //    gl.LoadIdentity();

        //    //  Create a perspective transformation.
        //    gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

        //    //  Use the 'look at' helper function to position and aim the camera.
        //    gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

        //    //  Set the modelview matrix.
        //    gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void SetBackGroundColor(float _fR, float _fG, float _fB)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.ClearColor(_fR, _fG, _fB, 0);
        }

        public void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.Location.ToString());
        }
        






        //DataSetting
        //Tab01 4
        internal void SetBackR(float _fBackR)
        {
            ParticleData.BackgroundR = _fBackR;

            SetBackGroundColor(ParticleData.BackgroundR, ParticleData.BackgroundG, ParticleData.BackgroundB);
        }
        internal void SetBackG(float _fBackG)
        {
            ParticleData.BackgroundG = _fBackG;

            SetBackGroundColor(ParticleData.BackgroundR, ParticleData.BackgroundG, ParticleData.BackgroundB);
        }
        internal void SetBackB(float _fBackB)
        {
            ParticleData.BackgroundB = _fBackB;

            SetBackGroundColor(ParticleData.BackgroundR, ParticleData.BackgroundG, ParticleData.BackgroundB);
        }
        internal void SetTexture(string _szTexture)
        {
            ParticleData.Texture = _szTexture;
        }

        //Tab02 14
        internal void SetEmitterType(string _szEmitterType)
        {
            ParticleData.EmitterType = _szEmitterType;
        }
        internal void SetMaxParticles(float _fMaxParticles)
        {
            ParticleData.MaxParticles = _fMaxParticles;
        }
        internal void SetBarToBoxLifespan(float _fLifespan)
        {
            ParticleData.Lifespan = _fLifespan;
        }
        internal void SetLifespanVar(float _fLifespanVar)
        {
            ParticleData.LifespanVariance = _fLifespanVar;
        }
        internal void SetStartSize(float _fStartSize)
        {
            ParticleData.StartSize = _fStartSize;
        }
        internal void SetStartSizeVar(float _fStartSizeVar)
        {
            ParticleData.StartSizeVariance = _fStartSizeVar;
        }
        internal void SetFinishSize(float _fFinishSize)
        {
            ParticleData.FinishSize = _fFinishSize;
        }
        internal void SetFinishSizeVar(float _fFinishSizeVar)
        {
            ParticleData.FinishSizeVariance = _fFinishSizeVar;
        }
        internal void SetEmitterAngle(float _fEmitterAngle)
        {
            ParticleData.EmitterAngle = _fEmitterAngle;
        }
        internal void SetAngleVar(float _fAngleVar)
        {
            ParticleData.AngleVariance = _fAngleVar;
        }
        internal void SetStartRot(float _fStartRot)
        {
            ParticleData.StartRot = _fStartRot;
        }
        internal void SetStartRotVar(float _fStartRotVar)
        {
            ParticleData.StartRotVar = _fStartRotVar;
        }
        internal void SetEndRot(float _fEndRot)
        {
            ParticleData.EndRot = _fEndRot;
        }
        internal void SetEndRotVar(float _fEndRotVar)
        {
            ParticleData.EndRotVar = _fEndRotVar;
        }

        //Tab03 15
        internal void SetXVariance(float _fXVariance)
        {
            ParticleData.XVariance = _fXVariance;
        }
        internal void SetYVariance(float _fYVariance)
        {
            ParticleData.YVariance = _fYVariance;
        }
        internal void SetSpeed(float _fSpeed)
        {
            ParticleData.Speed = _fSpeed;
        }
        internal void SetSpeedVariance(float _fSpeedVar)
        {
            ParticleData.SpeedVariance = _fSpeedVar;
        }
        internal void SetGravityX(float _fGravityX)
        {
            ParticleData.GravityX = _fGravityX;
        }
        internal void SetGravityY(float _fGravityY)
        {
            ParticleData.GravityY = _fGravityY;
        }
        internal void SetTanAcc(float _fTanAcc)
        {
            ParticleData.TanAcc = _fTanAcc;
        }
        internal void SetTanAccVar(float _fTanAccVar)
        {
            ParticleData.TanAccVar = _fTanAccVar;
        }
        internal void SetRadAcc(float _fRadAcc)
        {
            ParticleData.RadAcc = _fRadAcc;
        }
        internal void SetRadAccVar(float _fRadAccVar)
        {
            ParticleData.RadAccVar = _fRadAccVar;
        }
        internal void SetMaxRadius(float _fMaxRadius)
        {
            ParticleData.MaxRadius = _fMaxRadius;
        }
        internal void SetMaxRadiusVar(float _fMaxRadiusVar)
        {
            ParticleData.MaxRadiusVariance = _fMaxRadiusVar;
        }
        internal void SetMinRadius(float _fMinRadius)
        {
            ParticleData.MinRadius = _fMinRadius;
        }
        internal void SetDegSec(float _fDegSec)
        {
            ParticleData.DegSec = _fDegSec;
        }
        internal void SetDegSecVar(float _fDegSecVar)
        {
            ParticleData.DegSecVar = _fDegSecVar;
        }

        //Tab04
        internal void SetStartR(float _fStartR)
        {
            ParticleData.ColorStartR = _fStartR;
        }
        internal void SetStartG(float _fStartG)
        {
            ParticleData.ColorStartG = _fStartG;
        }
        internal void SetStartB(float _fStartB)
        {
            ParticleData.ColorStartB = _fStartB;
        }
        internal void SetStartA(float _fStartA)
        {
            ParticleData.ColorStartA = _fStartA;
        }
        internal void SetFinishR(float _fFinishR)
        {
            ParticleData.ColorFinishVarR = _fFinishR;
        }
        internal void SetFinishG(float _fFinishG)
        {
            ParticleData.ColorFinishVarG = _fFinishG;
        }
        internal void SetFinishB(float _fFinishB)
        {
            ParticleData.ColorFinishVarB = _fFinishB;
        }
        internal void SetFinishA(float _fFinishA)
        {
            ParticleData.ColorFinishVarA = _fFinishA;
        }

        //Tab05

        internal void SetStartVarR(float _fStartVarR)
        {
            ParticleData.ColorStartVarR = _fStartVarR;
        }
        internal void SetStartVarG(float _fStartVarG)
        {
            ParticleData.ColorStartVarG = _fStartVarG;
        }
        internal void SetStartVarB(float _fStartVarB)
        {
            ParticleData.ColorStartVarB = _fStartVarB;
        }
        internal void SetStartVarA(float _fStartVarA)
        {
            ParticleData.ColorStartVarA = _fStartVarA;
        }
        internal void SetFinishVarR(float _fFinishVarR)
        {
            ParticleData.ColorFinishVarR = _fFinishVarR;
        }
        internal void SetFinishVarG(float _fFinishVarG)
        {
            ParticleData.ColorFinishVarG = _fFinishVarG;
        }
        internal void SetFinishVarB(float _fFinishVarB)
        {
            ParticleData.ColorFinishVarB = _fFinishVarB;
        }
        internal void SetFinishVarA(float _fFinishVarA)
        {
            ParticleData.ColorFinishVarA = _fFinishVarA;
        }
        internal void SetSource(string _szSource)
        {
            ParticleData.Source = _szSource;
        }
        internal void SetDest(string _szDest)
        {
            ParticleData.Dest = _szDest;
        }

        //Window Control 관련 함수, 이벤트
    }
}
