using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleEditor
{
    class Particle
    {
        public Particle()
        {
            texture = "Circle";
            backgroundr = 0.0f;
            backgroundg = 0.0f;
            backgroundb = 0.0f;

            emittertype = "Gravity";
            maxparticles = 0.0f;
            lifespan = 0.0f;
            lifespanvariance = 0.0f;
            startsize = 0.0f;
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

            colorstartr = 0.0f;
            colorstartg = 0.0f;
            colorstartb = 0.0f;
            colorstarta = 0.0f;
            colorfinishr = 0.0f;
            colorfinishg = 0.0f;
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

        private float maxparticles;
        public float MaxParticles
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
