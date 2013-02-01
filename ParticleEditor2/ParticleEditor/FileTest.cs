using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Drawing;

namespace ParticleEditor
{
    public class FireTest
    {
        private QdFireEngine pe = new QdFireEngine(1.0f, 0.2f, 0.0f, 1.0f);
        private Texture m_ttFigure = new Texture();

        public void LoadTexture(OpenGL _gl)
        {
            _gl.Enable(OpenGL.GL_TEXTURE_2D);
            m_ttFigure.Create(_gl, "particle.bmp");
        }

        public void Setting(OpenGL _gl, Size _size)
        {
            _gl.Viewport(0, 0, _size.Width, _size.Height);

            _gl.MatrixMode(OpenGL.GL_PROJECTION);
            _gl.LoadIdentity();

            _gl.Perspective(45.0f, (float)_size.Width / (float)_size.Height, 0.1f, 100.0f);

            _gl.MatrixMode(OpenGL.GL_MODELVIEW);
            _gl.LoadIdentity();
        }

        public void Display(OpenGL gl)
        {
            pe.draw(gl);
        }

        public void init(OpenGL _gl)
        {
            pe.setLimit(-2, 2, -1, 3);
            pe.init(1);
            pe.resetParticles();

            _gl.Enable(OpenGL.GL_LIGHTING);
            _gl.Enable(OpenGL.GL_LIGHT0);
            _gl.ShadeModel(OpenGL.GL_SMOOTH);
            _gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            _gl.MatrixMode(OpenGL.GL_PROJECTION);
            _gl.LoadIdentity();
            _gl.MatrixMode(OpenGL.GL_MODELVIEW);
            _gl.Enable(OpenGL.GL_TEXTURE_2D);
            _gl.Disable(OpenGL.GL_DEPTH_TEST);
            _gl.Enable(OpenGL.GL_BLEND);
            _gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);	
        }

        public void resetParticles()
        {
            pe.resetParticles();
        }
    }

    public class QdColor
    {
        public float m_fR;
        public float m_fG;
        public float m_fB;
        public float m_fA;
    }

    public class QdFireEngine : QdParticelEngine
    {
        public QdColor m_clrParticleColor = new QdColor();

        public QdFireEngine(float fRed, float fGreen, float fBlue, float fAlpha)
        {
            m_clrParticleColor.m_fA = fAlpha;
            m_clrParticleColor.m_fB = fBlue;
            m_clrParticleColor.m_fG = fGreen;
            m_clrParticleColor.m_fR = fRed;
        }

        public new int resetParticles()
        {
            int nCount = 0;

            //Give the random number generator a seed
            //srand(time(NULL));

            while (nCount != m_nParticles)
            {
                particleDead(nCount);
                nCount++;
            }
            return QD_SUCCESS;
        }

        public new int particleDead(int nParticle)
        {
            int nCount = nParticle;
            setCurrentColor(nCount, m_clrParticleColor.m_fR, m_clrParticleColor.m_fG, m_clrParticleColor.m_fB, m_clrParticleColor.m_fA);

            Random r = new Random();

            float fRand = (float)(r.Next() % 500);
            fRand = fRand / 50000;
            setFadeColor(nCount, 0, 0, 0, -fRand - .01f);
            setFadeLife(nCount, -fRand - .001f);

            float fX;
            float fY;

            Random r3 = new Random();
            fRand = (float)(r3.Next() % 500);
            fRand = fRand / 500;

            Random r1 = new Random();
            fX = fRand - .5f;
            fRand = (float)(r1.Next() % 500);
            fRand = fRand / 500;
            fY = fRand;

            fX = fX / 1000;
            fY = fY / 50;

            Random r2 = new Random();
            setDirection(nCount, 0, fY, 0);
            setGravity(nCount, 0, 0, 0);
            fRand = (float)(r2.Next() % 400);
            fRand = fRand / 500;
            setLR(nCount, fRand - .4f, -1, 0);
            setUL(nCount, fRand - .4f + 0.3f, -0.7f, 0);
            setAge(nCount, 0);
            setFrame(nCount, 0);

            setLife(nCount, 1);

            return QD_SUCCESS;
        }
    };
    public class QdParticle
    {
        public Qd3dPoint m_ptUL = new Qd3dPoint();
        public Qd3dPoint m_ptLR = new Qd3dPoint();

        public QdColor m_clrCurrent = new QdColor();
        public QdColor m_clrFade = new QdColor();

        public Qd3dPoint m_ptDirection = new Qd3dPoint();
        public Qd3dPoint m_ptGravity = new Qd3dPoint();

        public int m_nFrames;
        public float m_fAge;

        public float m_fLife;
        public float m_fGravityFactor;
        public float m_fFadeLife;
        public float m_nParticle;

        public QdParticle()
        {
            m_fAge = 0;
            m_nFrames = 0;
            m_fLife = 1.0f;
            m_fGravityFactor = .025f;
        }

        public void draw(OpenGL gl)
        {
            //gl.Begin(OpenGL.GL_QUADS);
            //gl.TexCoord(0.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, 0);	// Bottom Left Of The Texture and Quad
            //gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, -1.0f, 0);	// Bottom Right Of The Texture and Quad
            //gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 1.0f, 0);	// Top Right Of The Texture and Quad
            //gl.TexCoord(0.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, 0);	// Top Left Of The Texture and Quad
            //gl.End();

        
            //Set color
            gl.Color(1, m_clrCurrent.m_fG, m_clrCurrent.m_fB, m_clrCurrent.m_fA);

            //Dont display particle on first frame of it's life
            //if (m_fLife == 1.0f)
            //{
            //    gl.Color(0, 0, 0, 0);
            //}

            //gl.Translate(0.0f, 0.0f, 6.0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(1, 1); gl.Vertex(m_ptUL.m_fX, m_ptUL.m_fY, m_ptUL.m_fZ);
            gl.TexCoord(0, 1); gl.Vertex(m_ptLR.m_fX, m_ptUL.m_fY, m_ptUL.m_fZ);
            gl.TexCoord(0, 0); gl.Vertex(m_ptLR.m_fX, m_ptLR.m_fY, m_ptUL.m_fZ);
            gl.TexCoord(1, 0); gl.Vertex(m_ptUL.m_fX, m_ptLR.m_fY, m_ptUL.m_fZ);
            gl.End();
        }

        public void advance()
        {

            //Move the quad in the direction it should be headed
            m_ptUL.m_fX += m_ptDirection.m_fX;
            m_ptUL.m_fY += m_ptDirection.m_fY;
            m_ptUL.m_fZ += m_ptDirection.m_fZ;

            m_ptLR.m_fX += m_ptDirection.m_fX;
            m_ptLR.m_fY += m_ptDirection.m_fY;
            m_ptLR.m_fZ += m_ptDirection.m_fZ;

            //Add the force of gravity
            //The formula for the force of gravity (without factoring friction from
            //the air) is something like:  h = vit + 1/2 a t^2
            m_ptUL.m_fX += m_ptGravity.m_fX * m_fAge * m_fAge;
            m_ptUL.m_fY += m_ptGravity.m_fY * m_fAge * m_fAge;
            m_ptUL.m_fZ += m_ptGravity.m_fZ * m_fAge * m_fAge;

            m_ptLR.m_fX += m_ptGravity.m_fX * m_fAge * m_fAge;
            m_ptLR.m_fY += m_ptGravity.m_fY * m_fAge * m_fAge;
            m_ptLR.m_fZ += m_ptGravity.m_fZ * m_fAge * m_fAge;

            //Slowly fade the color
            m_clrCurrent.m_fR += m_clrFade.m_fR;
            m_clrCurrent.m_fG += m_clrFade.m_fG;
            m_clrCurrent.m_fB += m_clrFade.m_fB;
            m_clrCurrent.m_fA += m_clrFade.m_fA;

            m_fLife += m_fFadeLife;

            m_nFrames++;
            m_fAge = m_nFrames * m_fGravityFactor;

        }

    }

    public class Qd3dPoint
    {
        public float m_fX;
        public float m_fY;
        public float m_fZ;
    }

    public class QdParticelEngine
    {
        public int QD_SUCCESS = 1;
        public int QD_NO_AUTO_TEXTURE = 571;
        public bool m_bLimit;
        public QdParticle[] m_pParticles = new QdParticle[1];
        public bool m_bEngineActive;
        public int m_nParticles;
        public int m_nAge;

        public float m_fLimitR;
        public float m_fLimitL;
        public float m_fLimitT;
        public float m_fLimitB;

        public char m_szImgPath;
        public char[] m_szImgPathA = new char[128];

        public int setLimit(float fLimitL, float fLimitR, float fLimitT, float fLimitB)
        {
            //Enable limit
            m_bLimit = false;

            m_fLimitL = fLimitL;
            m_fLimitR = fLimitR;
            m_fLimitT = fLimitT;
            m_fLimitB = fLimitB;

            return QD_SUCCESS;
        }
        public int setLimit(bool bLimit)
        {
            m_bLimit = bLimit;
            return QD_SUCCESS;
        }
        public int setCurrentColor(int nParticle, float fRed, float fGreen, float fBlue, float fAlpha)
        {
            m_pParticles[nParticle].m_clrCurrent.m_fR = fRed;
            m_pParticles[nParticle].m_clrCurrent.m_fG = fGreen;
            m_pParticles[nParticle].m_clrCurrent.m_fB = fBlue;
            m_pParticles[nParticle].m_clrCurrent.m_fA = fAlpha;

            return QD_SUCCESS;
        }
        public int setFadeColor(int nParticle, float fRed, float fGreen, float fBlue, float fAlpha)
        {
            m_pParticles[nParticle].m_clrFade.m_fR = fRed;
            m_pParticles[nParticle].m_clrFade.m_fG = fGreen;
            m_pParticles[nParticle].m_clrFade.m_fB = fBlue;
            m_pParticles[nParticle].m_clrFade.m_fA = fAlpha;

            return QD_SUCCESS;
        }
        public int setDirection(int nParticle, float fX, float fY, float fZ)
        {
            m_pParticles[nParticle].m_ptDirection.m_fX = fX;
            m_pParticles[nParticle].m_ptDirection.m_fY = fY;
            m_pParticles[nParticle].m_ptDirection.m_fZ = fZ;
            return QD_SUCCESS;

        }
        public int setGravity(int nParticle, float fX, float fY, float fZ)
        {
            m_pParticles[nParticle].m_ptGravity.m_fX = fX;
            m_pParticles[nParticle].m_ptGravity.m_fY = fY;
            m_pParticles[nParticle].m_ptGravity.m_fZ = fZ;
            return QD_SUCCESS;
        }
        public int setLR(int nParticle, float fX, float fY, float fZ)
        {
            m_pParticles[nParticle].m_ptLR.m_fX = fX;
            m_pParticles[nParticle].m_ptLR.m_fY = fY;
            m_pParticles[nParticle].m_ptLR.m_fZ = fZ;
            return QD_SUCCESS;
        }
        public int setUL(int nParticle, float fX, float fY, float fZ)
        {
            m_pParticles[nParticle].m_ptUL.m_fX = fX;
            m_pParticles[nParticle].m_ptUL.m_fY = fY;
            m_pParticles[nParticle].m_ptUL.m_fZ = fZ;
            return QD_SUCCESS;
        }
        public int setAge(int nParticle, float fAge)
        {
            m_pParticles[nParticle].m_fAge = fAge;
            return QD_SUCCESS;
        }
        public int setFrame(int nParticle, int nFrame)
        {
            m_pParticles[nParticle].m_nFrames = nFrame;
            return QD_SUCCESS;
        }
        public int setGravityFactor(int nParticle, float fGravityFactor)
        {
            m_pParticles[nParticle].m_fGravityFactor = fGravityFactor;
            return QD_SUCCESS;
        }
        public int setLife(int nParticle, float fLife)
        {
            m_pParticles[nParticle].m_fLife = fLife;
            return QD_SUCCESS;
        }
        public int setFadeLife(int nParticle, float fFadeLife)
        {
            m_pParticles[nParticle].m_fFadeLife = fFadeLife;
            return QD_SUCCESS;
        }
        public int setImgPath(char szImgPath)
        {
            m_szImgPath = szImgPath;
            return QD_SUCCESS;

        }
        public int draw(OpenGL gl)
        {
            int nCount = 0;
            while (nCount != m_nParticles)
            {
                m_pParticles[nCount].draw(gl);
                m_pParticles[nCount].advance();
                if (m_pParticles[nCount].m_fLife < 0.0f)
                {
                    particleDead(nCount);
                }

                nCount++;
                
            }

            if (m_bLimit)
            {
                nCount = 0;
                while (nCount != m_nParticles)
                {
                    if (m_pParticles[nCount].m_ptUL.m_fX < m_fLimitL)
                    {
                        particleDead(nCount);
                    }
                    else if (m_pParticles[nCount].m_ptLR.m_fX > m_fLimitR)
                    {
                        particleDead(nCount);
                    }
                    else if (m_pParticles[nCount].m_ptLR.m_fY < m_fLimitB)
                    {
                        particleDead(nCount);
                    }
                    else if (m_pParticles[nCount].m_ptUL.m_fY > m_fLimitT)
                    {
                        particleDead(nCount);
                    }

                    nCount++;
                }

            }
            m_nAge++;

            nCount = 0;


            return nCount;
        }
        public int init(int nParticles)
        {
            m_bEngineActive = false;
            m_pParticles = new QdParticle[nParticles];
            m_nParticles = nParticles;

            int nCount = 0;
            while (nCount < nParticles)
            {
                QdParticle qdParticle = new QdParticle();

                m_pParticles[nCount] = qdParticle;
                m_pParticles[nCount].m_nParticle = nCount;
                nCount++;
            }

            resetParticles();
            
            return nParticles;
        }

         public virtual int resetParticles()
         {
             
             return 0;
         }

        public virtual int particleDead(int nParticle)
        {
            return 0;
        }
        public int destroy()
        {
            m_nAge = 0;
            m_pParticles = new QdParticle[0];
            return 4;

        }
    }
}
