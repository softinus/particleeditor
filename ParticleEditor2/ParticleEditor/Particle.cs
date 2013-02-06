using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Drawing;
using System.Threading;

namespace ParticleEditor
{
    public class Particle
    {
        public OpenGL openGL = new OpenGL();
        public ParticleData particleData = null;
        public ParticleEngine[] particles = null;
        public Texture texture = null;

        public Particle(OpenGL _openGL)
        {
            openGL = _openGL;
            particleData = new ParticleData();
            int iPaticleCount = particleData.MaxParticles;
            particleData.ParticleInit = false;

            particles = new ParticleEngine[iPaticleCount];

            SetTexture(particleData.Texture);
            
            Random rndParticleStart = new Random();


            for (int i = 0; i < iPaticleCount; i++)
            {
                int iMinStart = 0;
                int iMaxStart = 3;

                float fStart = rndParticleStart.Next(iMinStart, iMaxStart);

                ParticleEngine particleEngine = new ParticleEngine(_openGL); 
                particles[i] = particleEngine;
                particles[i].ParticleMove(fStart, true);
            }   
        }

        public void ParticleInit()
        {
            int iPaticleCount = particleData.MaxParticles;
            particleData.ParticleInit = false;
            particles = new ParticleEngine[iPaticleCount];
            texture = new Texture();

            Random rndParticleStart = new Random();

            for (int i = 0; i < iPaticleCount; i++)
            {
                ParticleEngine particleEngine = new ParticleEngine(openGL);
                particles[i] = particleEngine;

                int iMinStart = 0;
                int iMaxStart = 3;

                float fStart = rndParticleStart.Next(iMinStart, iMaxStart);

                particles[i].ParticleMove(fStart, true);
            }   
        }

        public void Draw()
        {
            foreach(ParticleEngine particle in particles)
                particle.Draw(ref particleData, texture);
        }

        public void Update()
        {
            openGL.Rotate(particleData.EmitterAngle, 0, 0, 1);

            Random rndParticleLife = new Random();
            Random rndParticleRepeat = new Random();
            Random rndParticleStart = new Random();

            foreach (ParticleEngine particle in particles)
            {
                int iMinLife = 500;
                int iMaxLife = 3000; //

                int iMinMove = 500;
                int iMaxMove = 1500;

                int iMinStart = 0;
                int iMaxStart = 3;

                float fLife = rndParticleLife.Next(iMinLife, iMaxLife) / 1000.0f;
                float fMove = rndParticleRepeat.Next(iMinMove, iMaxMove);
                float fStart = rndParticleStart.Next(iMinStart, iMaxStart);

                particle.Update(fLife, fMove, fStart);
            }

            if (particleData.TextureInit)
            {
                SetTexture(particleData.Texture);
                particleData.TextureInit = false;
            }

            if (particleData.ParticleInit)
            {
                ParticleInit();
                particleData.ParticleInit = false;
            }
        }

        //public int[] GetRandomData()
        //{
        //    int[] iRand = new int[2];

        //    Random rndStep01 = new Random();
        //    Random rndStep02 = new Random();

        //    int iStep01 = rndStep01.Next(0, 11);

        //    int iStep02 = rndStep02.Next(0, 2);
        //    int iStep03 = rndStep02.Next(0, 3);
        //    int iStep04 = rndStep02.Next(0, 4);
        //    int iStep05 = rndStep02.Next(0, 5);
        //    int iStep06 = rndStep02.Next(0, 6);
        //    int iStep07 = rndStep02.Next(0, 7);

        //    switch (iStep01)
        //    {
        //        case 0: 
        //            iRand[0] = 0;
        //            iRand[1] = 4;
        //            break;
        //        case 1:
        //            iRand[0] = 0;
        //            iRand[1] = 4;
        //            break;
        //        case 2:
        //            iRand[0] = 0;
        //            iRand[1] = 4;
        //            break;
        //        case 3:
        //            iRand[0] = 0;
        //            iRand[1] = 4;
        //            break;
        //        case 4:
        //            iRand[0] = 0;
        //            iRand[1] = 4;
        //            break;
        //        case 5:
        //            switch (iStep02)
        //            {
        //                case 0:
        //                    iRand[0] = 0;
        //                    iRand[1] = 4;
        //                    break;
        //                case 1:
        //                    iRand[0] = 4;
        //                    iRand[1] = 5;
        //                    break;
        //            }
        //            break;
        //        case 6:
        //            switch (iStep03)
        //            {
        //                case 0:
        //                    iRand[0] = 0;
        //                    iRand[1] = 4;
        //                    break;
        //                case 1:
        //                    iRand[0] = 4;
        //                    iRand[1] = 5;
        //                    break;
        //                case 2:
        //                    iRand[0] = 5;
        //                    iRand[1] = 6;
        //                    break;
        //            }
        //            break;
        //        case 7:
        //            switch (iStep04)
        //            {
        //                case 0:
        //                    iRand[0] = 0;
        //                    iRand[1] = 4;
        //                    break;
        //                case 1:
        //                    iRand[0] = 4;
        //                    iRand[1] = 5;
        //                    break;
        //                case 2:
        //                    iRand[0] = 5;
        //                    iRand[1] = 6;
        //                    break;
        //                case 3:
        //                    iRand[0] = 6;
        //                    iRand[1] = 7;
        //                    break;
        //            }
        //            break;
        //        case 8:
        //            switch (iStep05)
        //            {
        //                case 0:
        //                    iRand[0] = 0;
        //                    iRand[1] = 4;
        //                    break;
        //                case 1:
        //                    iRand[0] = 4;
        //                    iRand[1] = 5;
        //                    break;
        //                case 2:
        //                    iRand[0] = 5;
        //                    iRand[1] = 6;
        //                    break;
        //                case 3:
        //                    iRand[0] = 6;
        //                    iRand[1] = 7;
        //                    break;
        //                case 4:
        //                    iRand[0] = 7;
        //                    iRand[1] = 8;
        //                    break;
        //            }
        //            break;
        //        case 9:
        //            switch (iStep06)
        //            {
        //                case 0:
        //                    iRand[0] = 0;
        //                    iRand[1] = 4;
        //                    break;
        //                case 1:
        //                    iRand[0] = 4;
        //                    iRand[1] = 5;
        //                    break;
        //                case 2:
        //                    iRand[0] = 5;
        //                    iRand[1] = 6;
        //                    break;
        //                case 3:
        //                    iRand[0] = 6;
        //                    iRand[1] = 7;
        //                    break;
        //                case 4:
        //                    iRand[0] = 7;
        //                    iRand[1] = 8;
        //                    break;
        //                case 5:
        //                    iRand[0] = 8;
        //                    iRand[1] = 9;
        //                    break;
        //            }
        //            break;
        //        case 10:
        //            switch (iStep06)
        //            {
        //                case 0:
        //                    iRand[0] = 0;
        //                    iRand[1] = 4;
        //                    break;
        //                case 1:
        //                    iRand[0] = 4;
        //                    iRand[1] = 5;
        //                    break;
        //                case 2:
        //                    iRand[0] = 5;
        //                    iRand[1] = 6;
        //                    break;
        //                case 3:
        //                    iRand[0] = 6;
        //                    iRand[1] = 7;
        //                    break;
        //                case 4:
        //                    iRand[0] = 7;
        //                    iRand[1] = 8;
        //                    break;
        //                case 5:
        //                    iRand[0] = 8;
        //                    iRand[1] = 9;
        //                    break;
        //                case 10:
        //                    iRand[0] = 9;
        //                    iRand[1] = 10;
        //                    break;
        //            }
        //            break;

        //    }


        //    return iRand;
        //}

        public void SetTexture(string _szParticle)
        {
            texture = new Texture();
            texture.Name = _szParticle;
            string szPath = "SampleParticle/" + _szParticle;
            texture.Create(openGL, szPath);
        }
    }

    public class ParticleEngine
    {
        ParticleData _particleData = new ParticleData();

        private OpenGL m_openGL = new OpenGL();
        private ParticleData m_particleData = new ParticleData();
        private ParticleLocation m_particleLocation = new ParticleLocation();
        private ParticalColor m_ParticalColor = new ParticalColor();

        private float[] m_ParticleSection = new float[6];
        private float m_fLifeTime = 0.0f;

        public ParticleEngine(OpenGL _openGL)
        {
            m_openGL = _openGL;
        }

        public void Draw(ref ParticleData _particleData, Texture _texture)
        {
            m_particleData = _particleData;
            
            _texture.Bind(m_openGL);

            float fColorR = m_particleData.ColorStartR + m_ParticalColor.ModifyR;
            float fColorG = m_particleData.ColorStartG + m_ParticalColor.ModifyG;
            float fColorB = m_particleData.ColorStartB + m_ParticalColor.ModifyB;
            float fColorA = m_particleData.ColorStartA + m_ParticalColor.ModifyA;
            
            m_openGL.Color(fColorR, fColorG, fColorB, fColorA);

            m_openGL.TexCoord(1.0f, 0.0f); m_openGL.Vertex(m_particleLocation.UpX, m_particleLocation.UpY, 0);
            m_openGL.TexCoord(0.0f, 0.0f); m_openGL.Vertex(m_particleLocation.DownX, m_particleLocation.UpY, 0);
            m_openGL.TexCoord(0.0f, 1.0f); m_openGL.Vertex(m_particleLocation.DownX, m_particleLocation.DownY, 0);
            m_openGL.TexCoord(1.0f, 1.0f); m_openGL.Vertex(m_particleLocation.UpX, m_particleLocation.DownY, 0);
            
        }

        public void Update(float _fLifeTime, float _fParticleMove, float _fParticleStart) //Engine Update
        {
            ParticleColor();
            ParticleSize();
            ParticleMove(_fParticleMove, false);
            ParticleDead(_fLifeTime, _fParticleStart);
        }

////////////////////////////////////
        public void ParticleSize()
        {

        }

        public void ParticleColor()
        {
            m_ParticalColor.SetColor(m_particleData);
            m_ParticalColor.SetColorModify(m_particleData.Lifespan);
        }

        public void ParticleMove(float _fParticleMove, bool _bInit)
        {
            if (!_bInit)
            {
                float fMove = _fParticleMove / 10000.0f;
                m_particleLocation.UpY += fMove;
                m_particleLocation.DownY += fMove;

                m_particleLocation.SetSize(m_particleData.StartSize, m_particleData.FinishSize);
                m_particleLocation.SetSizeModify(m_particleData.Lifespan);

                m_particleLocation.DownY += m_particleLocation.ParticleSize * 2.0f;
                m_particleLocation.DownX += m_particleLocation.ParticleSize;
                m_particleLocation.UpX -= m_particleLocation.ParticleSize;

                //m_ColorMove.ColorA += 0.04f;

            }
            else
            {
                SetEngineInit(_fParticleMove);
            }
        }
        public void ParticleDead(float _fLifeTime, float _fParticleStart)
        {
            if (_fLifeTime == 0.0f)
            {
                _fLifeTime = 0.1f;
            }

            SetLifeTime(_fLifeTime);

            if ((m_fLifeTime > m_particleData.Lifespan))// || (m_particleLocation.DownY > (m_particleData.Lifespan * 0.1f)))
            {
                SetEngineInit(_fParticleStart);
            }
        }

/////////////////////////////////////
       

        public void SetLifeTime(float _fLifeTime)
        {
            m_fLifeTime += _fLifeTime;
        }
        public void SetEngineInit(float _fInitData)
        {
            float fMove = (_fInitData * m_particleData.Lifespan) / 100.0f;

            m_particleLocation.UpY = fMove;
            m_particleLocation.DownY = fMove - (m_particleData.StartSize * 2);
            m_particleLocation.UpX = m_particleData.StartSize;
            m_particleLocation.DownX = -m_particleData.StartSize;

            m_fLifeTime = 0;

            m_ParticalColor.SetColorInit();
        }


        public class ParticalColor
        {
            ParticleData m_ParticleData = new ParticleData();

            public ParticalColor()
            {
                startr = m_ParticleData.ColorStartR;
                startg = m_ParticleData.ColorStartG;
                startb = m_ParticleData.ColorStartB;
                starta = m_ParticleData.ColorStartA;

                finishr = m_ParticleData.ColorFinishR;
                finishg = m_ParticleData.ColorFinishG;
                finishb = m_ParticleData.ColorFinishB;
                finisha = m_ParticleData.ColorFinishA;

                modifyr = 0.0f;
                modifya = 0.0f;
                modifyb = 0.0f;
                modifyg = 0.0f;
            }

            public void SetColor(ParticleData _particleData)
            {
                startr = _particleData.ColorStartR;
                startg = _particleData.ColorStartG;
                startb = _particleData.ColorStartB;
                starta = _particleData.ColorStartA;

                finishr = _particleData.ColorFinishR;
                finishg = _particleData.ColorFinishG;
                finishb = _particleData.ColorFinishB;
                finisha = _particleData.ColorFinishA;
            }

            public void SetColorModify(float _fDivide)
            {
                float fSizeR = (Math.Abs(startr - finishr) / _fDivide) * 1.5f;
                float fSizeG = (Math.Abs(startg - finishg) / _fDivide) * 1.5f;
                float fSizeB = (Math.Abs(startb - finishb) / _fDivide) * 1.5f;           
                float fSizeA = (Math.Abs(starta - finisha) / _fDivide);

                if (startr > finishr)
                    fSizeR = -fSizeR;

                if (startg > finishg)
                    fSizeG = -fSizeG;

                if (startb > finishb)
                    fSizeB = -fSizeB;

                if (starta > finisha)
                    fSizeA = -fSizeA;

                modifyr += fSizeR;
                modifyg += fSizeG;
                modifyb += fSizeB;
                modifya += fSizeA;                
            }

            public void SetColorInit()
            {
                modifyr = 0.0f;
                modifya = 0.0f;
                modifyb = 0.0f;
                modifyg = 0.0f;
            }

            private float modifyr;
            public float ModifyR
            {
                get { return modifyr; }
                set { modifyr = value; }
            }
            private float modifyg;
            public float ModifyG
            {
                get { return modifyg; }
                set { modifyg = value; }
            }
            private float modifyb;
            public float ModifyB
            {
                get { return modifyb; }
                set { modifyb = value; }
            }
            private float modifya;
            public float ModifyA
            {
                get { return modifya; }
                set { modifya = value; }
            }

            #region 
            private float startr;
            public float StartColorR
            {
                get { return startr; }
                set { startr = value; }
            }
            private float startg;
            public float StartColorG
            {
                get { return startg; }
                set { startg = value; }
            }
            private float startb;
            public float StartColorB
            {
                get { return startb; }
                set { startb = value; }
            }
            private float starta;
            public float StartColorA
            {
                get { return starta; }
                set { starta = value; }
            }

            private float finishr;
            public float FinishColorR
            {
                get { return finishr; }
                set { finishr = value; }
            }
            private float finishg;
            public float FinishColorG
            {
                get { return finishg; }
                set { finishg = value; }
            }
            private float finishb;
            public float FinishColorB
            {
                get { return finishb; }
                set { finishb = value; }
            }
            private float finisha;
            public float FinishColorA
            {
                get { return finisha; }
                set { finisha = value; }
            }
            #endregion
        }
        public class ParticleLocation
        {
            private float UpPointX;
            public float UpX
            {
                get { return UpPointX; }
                set { UpPointX = value; }
            }

            private float UpPointY;
            public float UpY
            {
                get { return UpPointY; }
                set { UpPointY = value; }
            }

            private float DownPointX;
            public float DownX
            {
                get { return DownPointX; }
                set { DownPointX = value; }
            }

            private float DownPointY;
            public float DownY
            {
                get { return DownPointY; }
                set { DownPointY = value; }
            }

            private float startsize;
            public float StartSize
            {
                get { return startsize; }
                set { startsize = value; }
            }

            private float endsize;
            public float EndSize
            {
                get { return endsize; }
                set { endsize = value; }
            }


            private float particlesize;
            public float ParticleSize
            {
                get { return particlesize; }
                set { particlesize = value; }
            }

            public ParticleLocation()
            {

            }

            public void SetSize(float _fStart, float _fEnd)
            {
                startsize = _fStart;
                endsize = _fEnd;
            }
            public void SetSizeModify(float _fDivide) // LifeTime 단위, 하나의 파티클 = 평균 life 단위 정도 루프
            {
                float fSize = 0.0f;
                bool bMark = true; // true +, false -

                if (startsize > endsize)
                {
                    fSize = (startsize - endsize) / _fDivide;
                    bMark = true;
                }
                else
                {
                    fSize = (endsize - startsize) / _fDivide;
                    bMark = false;
                }

                if (!bMark)
                    fSize = -fSize;

                particlesize = fSize;
            }
        }
    }

    ////////
    public class ParticleData
    {
        public ParticleData()
        {
            particleInit = false;
            textureInit = false;

            texture = "img_SampleCircle.png";
            backgroundr = 0.0f;
            backgroundg = 0.0f;
            backgroundb = 0.0f;

            emittertype = "Gravity";
            maxparticles = 50;
            lifespan = 5.0f * 1.5f;
            lifespanvariance = 0.0f;
            startsize = 0.2f;
            startsizevariance = 0.0f;
            finishsize = 0.0f;
            finishsizevariance = 0.0f;
            emitterangle = 0.0f;
            anglevariance = 0.0f;
            startrot = 0.0f;
            startrotvar = 0.0f;
            endrot = 0.0f;
            endrotvar = 0.0f;

            xvariance = 0.0f;
            yvariance = 0.0f;
            speed = 0.0f;
            speedvariance = 0.0f;
            gravityx = 0.0f;
            gravityy = 0.0f;
            tanacc = 0.0f;
            tanaccvar = 0.0f;
            radacc = 0.0f;
            radaccvar = 0.0f;
            maxradius = 0.0f;
            maxradiusvariance = 0.0f;
            minradius = 0.0f;
            degsec = 0.0f;
            degsecvar = 0.0f;

            colorstartr = 1.0f;
            colorstartg = 0.2f;
            colorstartb = 0.0f;
            colorstarta = 0.5f;
            colorfinishr = 1.0f;
            colorfinishg = 0.2f;
            colorfinishb = 0.0f;
            colorfinisha = 0.0f;

            colorstartvarr = 0.0f;
            colorstartvarg = 0.0f;
            colorstartvarb = 0.0f;
            colorstartvara = 0.0f;
            colorfinishvarr = 0.0f;
            colorfinishvarg = 0.0f;
            colorfinishvarb = 0.0f;
            colorfinishvara = 0.0f;
            source = "Src Alpha";
            dest = "One";
        }

        ///////////////

        private bool particleInit;
        public bool ParticleInit
        {
            get { return particleInit; }
            set { particleInit = value; }
        }

        private bool textureInit;
        public bool TextureInit
        {
            get { return textureInit; }
            set { textureInit = value; }
        }
        
        ////////////
        
        private int maxparticles;
        public int MaxParticles
        {
            get { return maxparticles; }
            set { maxparticles = value; }
        }
        private float lifespan;
        public float Lifespan
        {
            get { return lifespan; }
            set { lifespan = value; }
        }
        private float lifespanvariance;
        public float LifespanVariance
        {
            get { return lifespanvariance; }
            set { lifespanvariance = value; }
        }
        private float startsize;
        public float StartSize
        {
            get { return startsize; }
            set { startsize = value; }
        }
        private float startsizevariance;
        public float StartSizeVariance
        {
            get { return startsizevariance; }
            set { startsizevariance = value; }
        }
        private float finishsize;
        public float FinishSize
        {
            get { return finishsize; }
            set { finishsize = value; }
        }
        private float finishsizevariance;
        public float FinishSizeVariance
        {
            get { return finishsizevariance; }
            set { finishsizevariance = value; }
        }
        private float emitterangle;
        public float EmitterAngle
        {
            get { return emitterangle; }
            set { emitterangle = value; }
        }
        private float anglevariance;
        public float AngleVariance
        {
            get { return anglevariance; }
            set { anglevariance = value; }
        }
        private float startrot;
        public float StartRot
        {
            get { return startrot; }
            set { startrot = value; }
        }
        private float startrotvar;
        public float StartRotVar
        {
            get { return startrotvar; }
            set { startrotvar = value; }
        }
        private float endrot;
        public float EndRot
        {
            get { return endrot; }
            set { endrot = value; }
        }
        private float endrotvar;
        public float EndRotVar
        {
            get { return endrotvar; }
            set { endrotvar = value; }
        }
        private float backgroundr;
        public float BackgroundR
        {
            get { return backgroundr; }
            set { backgroundr = value; }
        }
        private float backgroundg;
        public float BackgroundG
        {
            get { return backgroundg; }
            set { backgroundg = value; }
        }
        private float backgroundb;
        public float BackgroundB
        {
            get { return backgroundb; }
            set { backgroundb = value; }
        }
        private string texture;
        public string Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        private string emittertype;
        public string EmitterType
        {
            get { return emittertype; }
            set { emittertype = value; }
        }
        private float xvariance;
        public float XVariance
        {
            get { return xvariance; }
            set { xvariance = value; }
        }
        private float yvariance;
        public float YVariance
        {
            get { return yvariance; }
            set { yvariance = value; }
        }
        private float speed;
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private float speedvariance;
        public float SpeedVariance
        {
            get { return speedvariance; }
            set { speedvariance = value; }
        }
        private float gravityx;
        public float GravityX
        {
            get { return gravityx; }
            set { gravityx = value; }
        }
        private float gravityy;
        public float GravityY
        {
            get { return gravityy; }
            set { gravityy = value; }
        }
        private float tanacc;
        public float TanAcc
        {
            get { return tanacc; }
            set { tanacc = value; }
        }
        private float tanaccvar;
        public float TanAccVar
        {
            get { return tanaccvar; }
            set { tanaccvar = value; }
        }
        private float radacc;
        public float RadAcc
        {
            get { return radacc; }
            set { radacc = value; }
        }
        private float radaccvar;
        public float RadAccVar
        {
            get { return radaccvar; }
            set { radaccvar = value; }
        }
        private float maxradius;
        public float MaxRadius
        {
            get { return maxradius; }
            set { maxradius = value; }
        }
        private float maxradiusvariance;
        public float MaxRadiusVariance
        {
            get { return maxradiusvariance; }
            set { maxradiusvariance = value; }
        }
        private float minradius;
        public float MinRadius
        {
            get { return minradius; }
            set { minradius = value; }
        }
        private float degsec;
        public float DegSec
        {
            get { return degsec; }
            set { degsec = value; }
        }
        private float degsecvar;
        public float DegSecVar
        {
            get { return degsecvar; }
            set { degsecvar = value; }
        }

        private float colorstartr;
        public float ColorStartR
        {
            get { return colorstartr; }
            set { colorstartr = value; }
        }
        private float colorstartg;
        public float ColorStartG
        {
            get { return colorstartg; }
            set { colorstartg = value; }
        }
        private float colorstartb;
        public float ColorStartB
        {
            get { return colorstartb; }
            set { colorstartb = value; }
        }
        private float colorstarta;
        public float ColorStartA
        {
            get { return colorstarta; }
            set { colorstarta = value; }
        }
        private float colorfinishr;
        public float ColorFinishR
        {
            get { return colorfinishr; }
            set { colorfinishr = value; }
        }
        private float colorfinishg;
        public float ColorFinishG
        {
            get { return colorfinishg; }
            set { colorfinishg = value; }
        }
        private float colorfinishb;
        public float ColorFinishB
        {
            get { return colorfinishb; }
            set { colorfinishb = value; }
        }
        private float colorfinisha;
        public float ColorFinishA
        {
            get { return colorfinisha; }
            set { colorfinisha = value; }
        }


        private float colorstartvarr;
        public float ColorStartVarR
        {
            get { return colorstartvarr; }
            set { colorstartvarr = value; }
        }
        private float colorstartvarg;
        public float ColorStartVarG
        {
            get { return colorstartvarg; }
            set { colorstartvarg = value; }
        }
        private float colorstartvarb;
        public float ColorStartVarB
        {
            get { return colorstartvarb; }
            set { colorstartvarb = value; }
        }
        private float colorstartvara;
        public float ColorStartVarA
        {
            get { return colorstartvara; }
            set { colorstartvara = value; }
        }
        private float colorfinishvarr;
        public float ColorFinishVarR
        {
            get { return colorfinishvarr; }
            set { colorfinishvarr = value; }
        }
        private float colorfinishvarg;
        public float ColorFinishVarG
        {
            get { return colorfinishvarg; }
            set { colorfinishvarg = value; }
        }
        private float colorfinishvarb;
        public float ColorFinishVarB
        {
            get { return colorfinishvarb; }
            set { colorfinishvarb = value; }
        }
        private float colorfinishvara;
        public float ColorFinishVarA
        {
            get { return colorfinishvara; }
            set { colorfinishvara = value; }
        }
        private string source;
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        private string dest;
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }
    }
}
