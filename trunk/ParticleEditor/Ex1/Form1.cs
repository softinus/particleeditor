using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGD;
using Microsoft.DirectX.Direct3D;
using System.IO;
using System.Xml;

namespace Ex1
{
    public partial class Form1 : Form
    {
        ManagedDirect3D D3D = ManagedDirect3D.Instance;
        ManagedTextureManager TM = ManagedTextureManager.Instance;
        Emitter emitter;
        Color ParticleViewBGColor = new Color();
        int SrcBlend;
        int DestBlend;
        int ResH = 768;
        int ResW = 1024;
        float Version = 0.4f;

        string szFilePath;
        string szImagePath;

        public enum EMIT_MODE { STREAM, BURST };
        public enum ANIMATION_TYPE { SINGLE, CONTINUOUS };
        int ParticleViewBackgroundImgID = new int();
        long NowTime;
        long LastTime;
        bool IsPlaying;

        /// <summary>
        /// IsEmitting
        /// </summary>
        /// <returns>true if the emitter is playing</returns>
        public bool IsEmitting
        {
            get { return IsPlaying; }
            set { IsPlaying = value; }
        }

        /// <summary>
        /// ParticleCountLabel
        /// </summary>
        /// <returns>label text for particle count</returns>
        public Label ParticleCountLabel
        {
            set { lblParticleCount = value; }
            get { return lblParticleCount; }
        }

        public Form1()
        {
            int NumParticles = 200;
            InitializeComponent();
            D3D.InitManagedDirect3D(pictureBox1, pictureBox1.Width, pictureBox1.Height, true, false);
            TM.InitManagedTextureManager(D3D.Device, D3D.Sprite);
            emitter = new Emitter(NumParticles, this);
            szImagePath = "Graphics\\EBAT_PARTICLE.png";
            emitter.ImageID = TM.LoadTexture(szImagePath, 0);
            timer1.Start();
            tmrParticleStream.Start();
            NowTime = System.DateTime.Now.Ticks;
            LastTime = System.DateTime.Now.Ticks;


            //Adjust all controls to the current effect
            emitter.NumberParticles = NumParticles;
            ImgParticle.Image = Image.FromFile(szImagePath);
            SrcBlend = (int)Blend.SourceAlpha;
            DestBlend = (int)Blend.DestinationAlpha;

            UpdateControls();

        }


        /// <summary>
        /// Updates all the control info on the form
        /// </summary>
        /// <returns>void</returns>
        public void UpdateControls()
        {
            AstrtRGB.Value = emitter.StartColor.A;
            RstrtRGB.Value = emitter.StartColor.R;
            GstrtRGB.Value = emitter.StartColor.G;
            BstrtRGB.Value = emitter.StartColor.B;
            AendRGB.Value = emitter.EndColor.A;
            RendRGB.Value = emitter.EndColor.R;
            GendRGB.Value = emitter.EndColor.G;
            BendRGB.Value = emitter.EndColor.B;
            NUDGravity.Value = (int)emitter.Gravity;
            NUDInertia.Value = (int)emitter.Inertia;
            TBmaxVelX.Value = (int)emitter.MaxVelocityX;
            TBmaxVelY.Value = (int)emitter.MaxVelocityY;
            TBminVelX.Value = (int)emitter.MinVelocityX;
            TBminVelY.Value = (int)emitter.MinVelocityY;
            
            NUDendmaxScale.Value = (decimal)emitter.EndMaxScale;
            NUDendminScale.Value = (decimal)emitter.EndMinScale;
            NUDstrtmaxScale.Value = (decimal)emitter.StartMaxScale;
            NUDstrtminScale.Value = (decimal)emitter.StartMinScale;
            
            NUDmaxLife.Value = (decimal)emitter.MaxLife;
            NUDminLife.Value = (decimal)emitter.MinLife;
            NUDemitterHeight.Value = emitter.Height;
            NUDemitterWidth.Value = emitter.Width;
            NUDemitterX.Value = emitter.Position.X;
            NUDemitterY.Value = emitter.Position.Y;
            NUDnumParticles.Value = emitter.NumberParticles;
            NUDEmissionSpeed.Value = emitter.EmissionSpeed;
            ParticleViewBGColor = Color.FromArgb(255, 0, 0, 0);
            ParticleViewBackgroundImgID = -1;
            IsPlaying = true;
            UpdateLabels();

            switch (SrcBlend)
            {
                case (int)Blend.Zero:
                    lstbxStartBlend.SelectedIndex = 0;
                    break;
                case (int)Blend.One:
                    lstbxStartBlend.SelectedIndex = 1;
                    break;
                case (int)Blend.SourceColor:
                    lstbxStartBlend.SelectedIndex = 2;
                    break;
                case (int)Blend.InvSourceColor:
                    lstbxStartBlend.SelectedIndex = 3;
                    break;
                case (int)Blend.SourceAlpha:
                    lstbxStartBlend.SelectedIndex = 4;
                    break;
                case (int)Blend.InvSourceAlpha:
                    lstbxStartBlend.SelectedIndex = 5;
                    break;
                case (int)Blend.SourceAlphaSat:
                    lstbxStartBlend.SelectedIndex = 6;
                    break;
                case (int)Blend.BothSourceAlpha:
                    lstbxStartBlend.SelectedIndex = 7;
                    break;
                case (int)Blend.BothInvSourceAlpha:
                    lstbxStartBlend.SelectedIndex = 8;
                    break;
                case (int)Blend.BlendFactor:
                    lstbxStartBlend.SelectedIndex = 9;
                    break;
                case (int)Blend.InvBlendFactor:
                    lstbxStartBlend.SelectedIndex = 10;
                    break;
            }
            //Zero = 1,
            //One = 2,
            //SourceColor = 3,
            //InvSourceColor = 4,
            //SourceAlpha = 5,
            //InvSourceAlpha = 6,
            //SourceAlphaSat = 11,
            //BothSourceAlpha = 12,
            //BothInvSourceAlpha = 13,
            //BlendFactor = 14,
            //InvBlendFactor = 15,  


            switch (DestBlend)
            {
                case (int)Blend.DestinationAlpha:
                    lstbxDestBlend.SelectedIndex = 0;
                    break;
                case (int)Blend.InvDestinationAlpha:
                    lstbxDestBlend.SelectedIndex = 1;
                    break;
                case (int)Blend.DestinationColor:
                    lstbxDestBlend.SelectedIndex = 2;
                    break;
                case (int)Blend.InvDestinationColor:
                    lstbxDestBlend.SelectedIndex = 3;
                    break;

            }
            //DestinationAlpha = 7,
            //InvDestinationAlpha = 8,
            //DestinationColor = 9,
            //InvDestinationColor = 10

            lstActiveEvents.Items.Clear();
            for (int i = 0; i < emitter.Events.Count; ++i)
            {
                string LstText = emitter.Events[i].EventID;
                if (emitter.Events[i].PlayAtBirth && emitter.Events[i].PlayAtDeath)
                {
                    LstText += "[Birth/Death]";
                }
                else if (emitter.Events[i].PlayAtDeath)
                {
                    LstText += "[Death]";
                }
                else if (emitter.Events[i].PlayAtBirth)
                {
                    LstText += "[Birth]";
                }

                lstActiveEvents.Items.Add(LstText);
            }
        }

        /// <summary>
        /// ParticleTimer
        /// </summary>
        /// <returns>Timer control for the particle system</returns>
        public Timer ParticleTimer
        {
            get { return tmrParticleStream; }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void GendRGB_Scroll(object sender, EventArgs e)
        {
            emitter.EndColor = Color.FromArgb(emitter.EndColor.R, GendRGB.Value, emitter.EndColor.B);
            UpdateLabels();
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void BendRGB_Scroll(object sender, EventArgs e)
        {
            emitter.EndColor = Color.FromArgb(emitter.EndColor.R, emitter.EndColor.G, BendRGB.Value);
            UpdateLabels();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Tick of the particle timer where the magic happens.
        /// </summary>
        /// <returns>void</returns>
        private void timer1_Tick(object sender, EventArgs e)
        {
            float dt = 0;

            // calc timestep
            NowTime = System.DateTime.Now.Ticks;
            dt = (NowTime - LastTime) * 0.0000001f;
            LastTime = System.DateTime.Now.Ticks;

            emitter.Update(dt);

            D3D.Clear(ParticleViewBGColor.R, ParticleViewBGColor.G, ParticleViewBGColor.B);
            D3D.DeviceBegin();
            D3D.SpriteBegin();

            //Draw Background
            if (ParticleViewBackgroundImgID != -1)
                TM.Draw(ParticleViewBackgroundImgID, pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width / TM.GetTextureWidth(ParticleViewBackgroundImgID), pictureBox1.Height / TM.GetTextureHeight(ParticleViewBackgroundImgID), Rectangle.Empty, 0, 0, 0, Color.FromArgb(255, 255, 255, 255).ToArgb());
            D3D.SpriteEnd();


            D3D.SpriteBegin();

            if(SrcBlend != -1)
            D3D.Device.RenderState.SourceBlend = (Blend)SrcBlend;

            if(DestBlend != -1)
            D3D.Device.RenderState.DestinationBlend = (Blend)DestBlend;
            //Draw Particles
            emitter.Render();

            D3D.SpriteEnd();
            D3D.DeviceEnd();
            D3D.Present();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }


        /// <summary>
        /// Manages moving the particle emitter with the mouse
        /// </summary>
        /// <returns>void</returns>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            emitter.X = e.X;
            emitter.Y = e.Y;

            if (emitter.X < 0)
                emitter.X = 0;
            else if (emitter.X > ResW)
                emitter.X = ResW;

            if (emitter.Y < 0)
                emitter.Y = 0;
            else if (emitter.Y > ResH)
                emitter.Y = ResH;

            NUDemitterX.Value = emitter.X;
            NUDemitterY.Value = emitter.Y;
            UpdateLabels();
            base.OnMouseDown(e);
        }


        /// <summary>
        /// Manages control over the number of particles
        /// </summary>
        /// <returns>void</returns>
        private void NUDnumParticles_ValueChanged(object sender, EventArgs e)
        {
            emitter.NumberParticles = (int)NUDnumParticles.Value;

            if (NUDnumParticles.Value >= emitter.ParticleList.Count)
            {
                emitter.NumberParticles = (int)NUDnumParticles.Value;
            }
            else
            {
                int limit = emitter.ParticleList.Count - (int)NUDnumParticles.Value;
                for (int i = 0; i < limit; ++i)
                {
                    emitter.ParticleList.Remove(emitter.ParticleList[emitter.ParticleList.Count - 1]);
                }
            }

        }

        /// <summary>
        /// Controls the scroll bar that manages minimum X velocity
        /// </summary>
        /// <returns>void</returns> 
        private void TBminVelX_Scroll(object sender, EventArgs e)
        {
            emitter.MinVelocityX = TBminVelX.Value;
        }

        /// <summary>
        /// Controls the scroll bar that manages maximum X velocity
        /// </summary>
        /// <returns>void</returns> 
        private void TBmaxVelX_Scroll(object sender, EventArgs e)
        {
            emitter.MaxVelocityX = TBmaxVelX.Value;
        }

        /// <summary>
        /// Controls the scroll bar that manages minimum Y velocity
        /// </summary>
        /// <returns>void</returns> 
        private void TBminVelY_Scroll(object sender, EventArgs e)
        {
            emitter.MinVelocityY = TBminVelY.Value;
        }

        /// <summary>
        /// Controls the scroll bar that manages maximum Y velocity
        /// </summary>
        /// <returns>void</returns> 
        private void TBmaxVelY_Scroll(object sender, EventArgs e)
        {
            emitter.MaxVelocityY = TBmaxVelY.Value;
        }

        private void TBGravity_Scroll(object sender, EventArgs e)
        {
        }

        private void TBminScale_Scroll(object sender, EventArgs e)
        {
        }

        private void TBmaxScale_Scroll(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Controls the scroll bar that manages particle coloring
        /// </summary>
        /// <returns>void</returns> 
        private void RstrtRGB_Scroll(object sender, EventArgs e)
        {
            emitter.StartColor = Color.FromArgb(emitter.StartColor.A, RstrtRGB.Value, emitter.StartColor.G, emitter.StartColor.B);
            UpdateLabels();
        }

        /// <summary>
        /// Controls the scroll bar that manages particle coloring
        /// </summary>
        /// <returns>void</returns> 
        private void GstrtRGB_Scroll(object sender, EventArgs e)
        {
            emitter.StartColor = Color.FromArgb(emitter.StartColor.A, emitter.StartColor.R, GstrtRGB.Value, emitter.StartColor.B);
            UpdateLabels();
        }

        /// <summary>
        /// Controls the scroll bar that manages particle coloring
        /// </summary>
        /// <returns>void</returns> 
        private void BstrtRGB_Scroll(object sender, EventArgs e)
        {
            emitter.StartColor = Color.FromArgb(emitter.StartColor.A, emitter.StartColor.R, emitter.StartColor.G, BstrtRGB.Value);
            UpdateLabels();
        }

        private void TBminLife_Scroll(object sender, EventArgs e)
        {

        }

        private void TBmaxLife_Scroll(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Controls the scroll bar that manages particle coloring
        /// </summary>
        /// <returns>void</returns> 
        private void RendRGB_Scroll(object sender, EventArgs e)
        {
            emitter.EndColor = Color.FromArgb(RendRGB.Value, emitter.EndColor.G, emitter.EndColor.B);
            UpdateLabels();
        }

        /// <summary>
        /// Controls managing changes in x position of the emitter
        /// </summary>
        /// <returns>void</returns> 
        private void NUDemitterX_ValueChanged(object sender, EventArgs e)
        {
            emitter.X = (int)NUDemitterX.Value;
            UpdateLabels();
        }
        /// <summary>
        /// Controls managing changes in x position of the emitter
        /// </summary>
        /// <returns>void</returns> 
        private void NUDemitterY_ValueChanged(object sender, EventArgs e)
        {
            emitter.Y = (int)NUDemitterY.Value;
            UpdateLabels();
        }

        /// <summary>
        /// Controls managing changes in width of the emitter
        /// </summary>
        /// <returns>void</returns> 
        private void NUDemitterWidth_ValueChanged(object sender, EventArgs e)
        {
            emitter.Width = (int)NUDemitterWidth.Value;
            UpdateLabels();
        }

        /// <summary>
        /// Controls managing changes in height of the emitter
        /// </summary>
        /// <returns>void</returns> 
        private void NUDemitterHeight_ValueChanged(object sender, EventArgs e)
        {
            emitter.Height = (int)NUDemitterHeight.Value;
            UpdateLabels();
        }

        private void TBminVelX_MouseHover(object sender, EventArgs e)
        {
        }

        private void TBminVelX_MouseEnter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Controls the scroll bar that manages changes to the minimum x velocity 
        /// </summary>
        /// <returns>void</returns> 
        private void TBminVelX_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(TBminVelX, emitter.MinVelocityX.ToString());
        }

        /// <summary>
        /// Controls the scroll bar that manages changes to the maximum x velocity 
        /// </summary>
        /// <returns>void</returns> 
        private void TBmaxVelX_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(TBmaxVelX, emitter.MaxVelocityX.ToString());
        }

        /// <summary>
        /// Controls the scroll bar that manages changes to the max Y velocity 
        /// </summary>
        /// <returns>void</returns> 
        private void TBmaxVelY_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(TBmaxVelY, emitter.MaxVelocityY.ToString());
        }

        /// <summary>
        /// Controls the scroll bar that manages changes to the minimum Y velocity 
        /// </summary>
        /// <returns>void</returns> 
        private void TBminVelY_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(TBminVelY, emitter.MinVelocityY.ToString());
        }

        private void TBGravity_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void tmrParticleStream_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void AstrtRGB_Scroll(object sender, EventArgs e)
        {
            emitter.StartColor = Color.FromArgb(AstrtRGB.Value, emitter.StartColor.R, emitter.StartColor.G, emitter.StartColor.B);
            UpdateLabels();
        }
        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void AendRGB_Scroll(object sender, EventArgs e)
        {
            emitter.EndColor = Color.FromArgb(AendRGB.Value, emitter.EndColor.R, emitter.EndColor.G, emitter.EndColor.B);
            UpdateLabels();
        }

        private void RdoBtnExplode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RdoBtnImplode_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// for changing the particle image
        /// </summary>
        /// <returns>void</returns>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.DefaultExt = "png";
            opn.Filter = "Image files (*.png;*jpg;*bmp;)|*.png;*jpg;*bmp;";
            opn.InitialDirectory = "Paricles\\";

            if (DialogResult.OK == opn.ShowDialog())
            {
                SGD.ManagedTextureManager.Instance.ReleaseTexture(emitter.ImageID);
                emitter.ImageID = (SGD.ManagedTextureManager.Instance.LoadTexture(opn.FileName, 0));

                //ImgParticle.Image = Image.FromFile(opn.FileName);
                szImagePath = opn.FileName;
            }


        }

        /// <summary>
        /// for changing the particle preview background
        /// </summary>
        /// <returns>void</returns>
        private void btnBackGrnd_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();

            if (DialogResult.OK == clr.ShowDialog())
            {
                ImgParticle.BackColor = clr.Color;

            }
        }

        /// <summary>
        /// for changing the min scale
        /// </summary>
        /// <returns>void</returns>
        private void NUDminScale_ValueChanged(object sender, EventArgs e)
        {
            emitter.StartMinScale = (float)NUDstrtminScale.Value;

            if (NUDstrtminScale.Value > NUDstrtmaxScale.Value)
            {
                NUDstrtmaxScale.Value = NUDstrtminScale.Value;
            }
        }

        /// <summary>
        /// for changing the max scale
        /// </summary>
        /// <returns>void</returns>
        private void NUDmaxScale_ValueChanged(object sender, EventArgs e)
        {
            emitter.StartMaxScale = (float)NUDstrtmaxScale.Value;

            if (NUDstrtmaxScale.Value < NUDstrtminScale.Value)
            {
                NUDstrtminScale.Value = NUDstrtmaxScale.Value;
            }
        }

        /// <summary>
        /// for changing the emission speed
        /// </summary>
        /// <returns>void</returns>
        private void NUDEmissionSpeed_ValueChanged(object sender, EventArgs e)
        {
            emitter.EmissionSpeed = (int)NUDEmissionSpeed.Value;
        }

        /// <summary>
        /// for changing the particle preview background
        /// </summary>
        /// <returns>void</returns>
        private void btnFill_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();

            if (DialogResult.OK == clr.ShowDialog())
            {
                ParticleViewBGColor = clr.Color;
            }
        }

        private void TBWind_Scroll(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// for changing inertia
        /// </summary>
        /// <returns>void</returns>

        private void NUDInertia_ValueChanged(object sender, EventArgs e)
        {
            emitter.Inertia = (float)NUDInertia.Value;
        }

        /// <summary>
        /// for changing gravity
        /// </summary>
        /// <returns>void</returns>

        private void NUDGravity_ValueChanged(object sender, EventArgs e)
        {
            emitter.Gravity = (float)NUDGravity.Value;

        }

        private void TBminLife_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void TBmaxLife_MouseMove(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// for changing min life
        /// </summary>
        /// <returns>void</returns>

        private void NUDminLife_ValueChanged(object sender, EventArgs e)
        {
            emitter.MinLife = (float)NUDminLife.Value;
            if (emitter.MinLife > emitter.MaxLife)
            {
                emitter.MaxLife = emitter.MinLife;
                NUDmaxLife.Value = (decimal)emitter.MaxLife;
            }
        }

        /// <summary>
        /// for changing max life
        /// </summary>
        /// <returns>void</returns>

        private void NUDmaxLife_ValueChanged(object sender, EventArgs e)
        {
            emitter.MaxLife = (float)NUDmaxLife.Value;

            if (emitter.MaxLife < emitter.MinLife)
            {
                emitter.MinLife = emitter.MaxLife;
                NUDminLife.Value = (decimal)emitter.MinLife;
            }
        }

        /// <summary>
        /// for changing wind
        /// </summary>
        /// <returns>void</returns>

        private void NUDWind_ValueChanged(object sender, EventArgs e)
        {
            emitter.Wind = (float)NUDWind.Value;
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void AstrtRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(AstrtRGB, emitter.StartColor.A.ToString());
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void RstrtRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(RstrtRGB, emitter.StartColor.R.ToString());
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void GstrtRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(GstrtRGB, emitter.StartColor.G.ToString());
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void BstrtRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(BstrtRGB, emitter.StartColor.B.ToString());
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void AendRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(AendRGB, emitter.EndColor.A.ToString());
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void RendRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(RendRGB, emitter.EndColor.R.ToString());
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void GendRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(GendRGB, emitter.EndColor.G.ToString());
        }

        /// <summary>
        /// Controls the scroll bar for particle coloring 
        /// </summary>
        /// <returns>void</returns>
        private void BendRGB_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(BendRGB, emitter.EndColor.B.ToString());

        }

        /// <summary>
        /// sets end max scale
        /// </summary>
        /// <returns>void</returns>

        private void NUDendmaxScale_ValueChanged(object sender, EventArgs e)
        {
            emitter.EndMaxScale = (float)NUDendmaxScale.Value;
        }

        /// <summary>
        /// sets end min scale
        /// </summary>
        /// <returns>void</returns>

        private void NUDendminScale_ValueChanged(object sender, EventArgs e)
        {
            emitter.EndMinScale = (float)NUDendminScale.Value;
        }

        /// <summary>
        /// randomizes the particle emitter 
        /// </summary>
        /// <returns>void</returns>

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            if (chkEndARGB.Checked)
            {
                emitter.EndColor = Color.FromArgb(emitter.RandInt(0, 255), emitter.RandInt(0, 255), emitter.RandInt(0, 255), emitter.RandInt(0, 255));

                AendRGB.Value = emitter.EndColor.A;
                RendRGB.Value = emitter.EndColor.R;
                GendRGB.Value = emitter.EndColor.G;
                BendRGB.Value = emitter.EndColor.B;
            }
            if (chkStartARGB.Checked)
            {
                emitter.StartColor = Color.FromArgb(emitter.RandInt(0, 255), emitter.RandInt(0, 255), emitter.RandInt(0, 255), emitter.RandInt(0, 255));

                AstrtRGB.Value = emitter.StartColor.A;
                RstrtRGB.Value = emitter.StartColor.R;
                GstrtRGB.Value = emitter.StartColor.G;
                BstrtRGB.Value = emitter.StartColor.B;
            }
            if (chkMinVelX.Checked)
            {
                emitter.MinVelocityX = emitter.RandFloat(TBminVelX.Minimum, TBminVelX.Maximum);
                TBminVelX.Value = (int)emitter.MinVelocityX;
            }
            if (chkMaxVelX.Checked)
            {
                emitter.MaxVelocityX = emitter.RandFloat(TBmaxVelX.Minimum, TBmaxVelX.Maximum);
                TBmaxVelX.Value = (int)emitter.MaxVelocityX;
            }
            if (chkGravity.Checked)
            {
                emitter.Gravity = emitter.RandFloat((float)NUDGravity.Minimum, (float)NUDGravity.Maximum);
                NUDGravity.Value = (decimal)emitter.Gravity;
            }
            if (chkInertia.Checked)
            {
                emitter.Inertia = emitter.RandFloat((float)NUDInertia.Minimum, (float)NUDInertia.Maximum);
                NUDInertia.Value = (decimal)emitter.Inertia;
            }
            if (chkMaxEndScale.Checked)
            {
                emitter.EndMaxScale = emitter.RandFloat((float)NUDendmaxScale.Minimum, (float)NUDendmaxScale.Maximum);
                NUDendmaxScale.Value = (decimal)emitter.EndMaxScale;
            }
            if (chkMinEndScale.Checked)
            {
                emitter.EndMinScale = emitter.RandFloat((float)NUDendminScale.Minimum, (float)NUDendminScale.Maximum);
                NUDendminScale.Value = (decimal)emitter.EndMinScale;
            }
            if (chkMaxStartScale.Checked)
            {
                emitter.StartMaxScale = emitter.RandFloat((float)NUDstrtmaxScale.Minimum, (float)NUDstrtmaxScale.Maximum);
                NUDstrtmaxScale.Value = (decimal)emitter.StartMaxScale;
            }
            if (chkMinStartScale.Checked)
            {
                emitter.StartMinScale = emitter.RandFloat((float)NUDstrtminScale.Minimum, (float)NUDstrtminScale.Maximum);
                NUDstrtminScale.Value = (decimal)emitter.StartMinScale;
            }
            if (chkWind.Checked)
            {
                emitter.Wind = emitter.RandFloat((float)NUDWind.Minimum, (float)NUDWind.Maximum);
                NUDWind.Value = (decimal)emitter.Wind;
            }
            if (chkNumberParticles.Checked)
            {
                emitter.NumberParticles = emitter.RandInt((int)NUDnumParticles.Minimum, (int)NUDnumParticles.Maximum);
                NUDnumParticles.Value = emitter.NumberParticles;
            }
            if (chkMaxLife.Checked)
            {
                emitter.MaxLife = emitter.RandFloat((float)NUDminLife.Value, (float)NUDmaxLife.Maximum);
                NUDmaxLife.Value = (decimal)emitter.MaxLife;
            }
            if (chkMinLife.Checked)
            {
                float min = (float)NUDminLife.Minimum;
                float max = (float)NUDmaxLife.Value;
                emitter.MinLife = emitter.RandFloat(min, max);
                NUDminLife.Value = (decimal)emitter.MinLife;
            }
            UpdateLabels();
        }

        /// <summary>
        /// changes the background on the particle preview control
        /// </summary>
        /// <returns>void</returns>
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            if (DialogResult.OK == opn.ShowDialog())
            {
                if (ParticleViewBackgroundImgID != -1)
                    TM.ReleaseTexture(ParticleViewBackgroundImgID);

                ParticleViewBackgroundImgID = TM.LoadTexture(opn.FileName, 0);
                btnClearImage.Enabled = true;
            }

        }

        /// <summary>
        /// removes the background image in the particle preview
        /// </summary>
        /// <returns>void</returns>

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            TM.ReleaseTexture(ParticleViewBackgroundImgID);
            ParticleViewBackgroundImgID = -1;
            btnClearImage.Enabled = false;
        }

        /// <summary>
        /// Stops emission
        /// </summary>
        /// <returns>void</returns>

        private void btnStop_Click(object sender, EventArgs e)
        {
            IsPlaying = false;
        }

        /// <summary>
        /// resumes emission
        /// </summary>
        /// <returns>void</returns>

        private void btnPlay_Click(object sender, EventArgs e)
        {
            IsPlaying = true;
        }

        /// <summary>
        /// sets emission mode
        /// </summary>
        /// <returns>void</returns>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            emitter.EmitMode = cmbEmitMode.SelectedIndex;
        }

        /// <summary>
        /// sets blending mode
        /// </summary>
        /// <returns>void</returns>

        private void lstbxStartBlend_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstbxStartBlend.SelectedIndex)
            {
                case 0:
                    SrcBlend = (int)Blend.Zero;
                    break;
                case 1:
                    SrcBlend = (int)Blend.One;
                    break;
                case 2:
                    SrcBlend = (int)Blend.SourceColor;
                    break;
                case 3:
                    SrcBlend = (int)Blend.InvSourceColor;
                    break;
                case 4:
                    SrcBlend = (int)Blend.SourceAlpha;
                    break;
                case 5:
                    SrcBlend = (int)Blend.InvSourceAlpha;
                    break;
                case 6:
                    SrcBlend = (int)Blend.SourceAlphaSat;
                    break;
                case 7:
                    SrcBlend = (int)Blend.BothSourceAlpha;
                    break;
                case 8:
                    SrcBlend = (int)Blend.BothInvSourceAlpha;
                    break;
                case 9:
                    SrcBlend = (int)Blend.BlendFactor;
                    break;
                case 10:
                    SrcBlend = (int)Blend.InvBlendFactor;
                    break;
                case 11:
                    SrcBlend = -1;
                    break;

            }
            //Zero = 1,
            //One = 2,
            //SourceColor = 3,
            //InvSourceColor = 4,
            //SourceAlpha = 5,
            //InvSourceAlpha = 6,
            //SourceAlphaSat = 11,
            //BothSourceAlpha = 12,
            //BothInvSourceAlpha = 13,
            //BlendFactor = 14,
            //InvBlendFactor = 15,
        }

        /// <summary>
        /// sets blending mode 
        /// </summary>
        /// <returns>void</returns>

        private void lstbxDestBlend_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstbxDestBlend.SelectedIndex)
            {
                case 0:
                    DestBlend = (int)Blend.DestinationAlpha;
                    break;
                case 1:
                    DestBlend = (int)Blend.InvDestinationAlpha;
                    break;
                case 2:
                    DestBlend = (int)Blend.DestinationColor;
                    break;
                case 3:
                    DestBlend = (int)Blend.InvDestinationColor;
                    break;
                case 4:
                    DestBlend = -1;
                    break;


                //DestinationAlpha = 7,
                //InvDestinationAlpha = 8,
                //DestinationColor = 9,
                //InvDestinationColor = 10
            }

        }

        private void btnSndBrowse_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// adds an event
        /// </summary>
        /// <returns>void</returns>
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (txtEventID.Text != String.Empty)
            {

                if (chkPlayBirth.Checked || chkPlayDeath.Checked)
                {
                    emitter.Events.Add(new Event(txtEventID.Text, chkPlayDeath.Checked, chkPlayBirth.Checked));
                    string LstText = txtEventID.Text;
                    if (chkPlayBirth.Checked && chkPlayDeath.Checked)
                    {
                        LstText += "[Birth/Death]";
                    }
                    else if (chkPlayDeath.Checked)
                    {
                        LstText += "[Death]";
                    }
                    else if (chkPlayBirth.Checked)
                    {
                        LstText += "[Birth]";
                    }

                    lstActiveEvents.Items.Add(LstText);
                    txtEventID.Text = "";
                    chkPlayBirth.Checked = false;
                    chkPlayDeath.Checked = false;
                }
                else
                {
                    //post error
                }
            }
            else
            {
                //Post error
            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// allows dynamic emitter movement
        /// </summary>
        /// <returns>void</returns>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                emitter.X = e.X;
                emitter.Y = e.Y;

                if (emitter.X < 0)
                    emitter.X = 0;
                else if (emitter.X > ResW)
                    emitter.X = ResW;

                if (emitter.Y < 0)
                    emitter.Y = 0;
                else if (emitter.Y > ResH)
                    emitter.Y = ResH;

                NUDemitterX.Value = emitter.X;
                NUDemitterY.Value = emitter.Y;
            }
            UpdateLabels();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// exits the program
        /// </summary>
        /// <returns>void</returns>

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// saves in XML
        /// </summary>
        /// <returns>void</returns>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == szFilePath)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = "xml";
                save.Filter = "Xml Files (*.xml)|*.xml|All Files (*.*)|*.*";
                save.FilterIndex = 1;

                if (DialogResult.OK == save.ShowDialog())
                {
                    szFilePath = save.FileName;
                }
                else
                    return;
            }

            Save();
        }

        /// <summary>
        /// opens in XML 
        /// </summary>
        /// <returns>void</returns>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.DefaultExt = "xml";
                dlg.Filter = "Xml Files (*.xml)|*.xml|All Files (*.*)|*.*";
                dlg.FilterIndex = 1;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    szFilePath = dlg.FileName;
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ConformanceLevel = ConformanceLevel.Document;
                    settings.IgnoreComments = true;
                    settings.IgnoreWhitespace = true;

                    using (XmlReader reader = XmlReader.Create(dlg.FileName, settings))
                    {
                        if (reader.IsStartElement("Emitter"))
                        {
                            reader.ReadStartElement("Emitter");

                            reader.MoveToFirstAttribute();
                            if (reader.ReadContentAsFloat() != Version)
                            {
                                MessageBox.Show("Bad File.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                                return;
                            }
                            reader.ReadStartElement("Version");

                            reader.MoveToFirstAttribute();
                            string szTemp = reader.ReadContentAsString();
                            if(szTemp != "Default")
                            ImgParticle.Image = Image.FromFile(szImagePath);
                            reader.ReadStartElement("ImagePath");
                            
                            reader.MoveToFirstAttribute();
                            emitter.X = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            emitter.Y = reader.ReadContentAsInt();
                            reader.ReadStartElement("Position");

                            reader.MoveToFirstAttribute();
                            emitter.Width = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            emitter.Height = reader.ReadContentAsInt();
                            reader.ReadStartElement("Dimensions");

                            reader.MoveToFirstAttribute();
                            emitter.MaxLife = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.MinLife = reader.ReadContentAsFloat();
                            reader.ReadStartElement("Life");

                            reader.MoveToFirstAttribute();
                            emitter.MinVelocityX = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.MinVelocityY = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.MaxVelocityX = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.MaxVelocityY = reader.ReadContentAsFloat();
                            reader.ReadStartElement("Velocity");

                            reader.MoveToFirstAttribute();
                            emitter.NumberParticles = reader.ReadContentAsInt();
                            reader.ReadStartElement("ParticleAmount");

                            reader.MoveToFirstAttribute();
                            int a = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            int r = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            int g = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            int b = reader.ReadContentAsInt();
                            emitter.StartColor = Color.FromArgb(a, r, g, b);
                            reader.ReadStartElement("StartARGB");

                            reader.MoveToFirstAttribute();
                            a = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            r = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            g = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            b = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            emitter.EndColor = Color.FromArgb(a, r, g, b);
                            reader.ReadStartElement("EndARGB");

                            reader.MoveToFirstAttribute();
                            emitter.StartMaxScale = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.StartMinScale = reader.ReadContentAsFloat();
                            reader.ReadStartElement("StartScale");

                            reader.MoveToFirstAttribute();
                            emitter.EndMaxScale = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.EndMinScale = reader.ReadContentAsFloat();
                            reader.ReadStartElement("EndScale");

                            reader.MoveToFirstAttribute();
                            emitter.Gravity = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.Wind = reader.ReadContentAsFloat();
                            reader.MoveToNextAttribute();
                            emitter.Inertia = reader.ReadContentAsFloat();
                            reader.ReadStartElement("Force");

                            reader.MoveToFirstAttribute();
                            emitter.EmissionSpeed = reader.ReadContentAsInt();
                            reader.ReadStartElement("Emission");

                            reader.MoveToFirstAttribute();
                            SrcBlend = reader.ReadContentAsInt();
                            reader.MoveToNextAttribute();
                            DestBlend = reader.ReadContentAsInt();
                            reader.ReadStartElement("Blending");


                            reader.MoveToFirstAttribute();
                            int j = reader.ReadContentAsInt();
                            reader.ReadStartElement("Events");

                            emitter.Events.Clear();
                            for (int i = 0; i < j; ++i)
                            {
                                reader.MoveToFirstAttribute();

                                string EvID = reader.ReadContentAsString();
                                
                                reader.MoveToNextAttribute();
                                
                                bool OnDeath;
                                if (reader.ReadContentAsString() == "True")
                                    OnDeath = true;
                                else
                                    OnDeath = false;

                                reader.MoveToNextAttribute();

                                bool OnBirth;
                                if ("True" == reader.ReadContentAsString())
                                    OnBirth = true;
                                else
                                    OnBirth = false;

                                reader.ReadStartElement("Event");

                                emitter.Events.Add(new Event(EvID,OnDeath,OnBirth));
                            }
                        }
                    }
                }

                UpdateControls();
        }

        /// <summary>
        /// Conduncts save as function
        /// </summary>
        /// <returns>void</returns>

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "xml";
            save.Filter = "Xml Files (*.xml)|*.xml|All Files (*.*)|*.*";
            save.FilterIndex = 1;

            if (DialogResult.OK == save.ShowDialog())
            {
                szFilePath = save.FileName;
                Save();
            }



        }

        /// <summary>
        /// conducts save mechanism
        /// </summary>
        /// <returns>void</returns>
        private void Save()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(szFilePath, settings))
            {                

                writer.WriteStartElement("Emitter");
                
                writer.WriteStartElement("Version");
                writer.WriteAttributeString("Revision", Version.ToString());
                writer.WriteEndElement();
                
                writer.WriteStartElement("ImagePath");
                if (szImagePath != "Particles\\Particle.png")
                    writer.WriteAttributeString("SRC", szImagePath);
                else
                    writer.WriteAttributeString("SRC", "Default");
                writer.WriteEndElement();

                writer.WriteStartElement("Position");
                writer.WriteAttributeString("X", emitter.X.ToString());
                writer.WriteAttributeString("Y", emitter.Y.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Dimensions");
                writer.WriteAttributeString("Width", emitter.Width.ToString());
                writer.WriteAttributeString("Height", emitter.Height.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Life");
                writer.WriteAttributeString("MaxLife", emitter.MaxLife.ToString());
                writer.WriteAttributeString("MinLife", emitter.MinLife.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Velocity");
                writer.WriteAttributeString("MinVelocityX", emitter.MinVelocityX.ToString());
                writer.WriteAttributeString("MinVelocityY", emitter.MinVelocityY.ToString());
                writer.WriteAttributeString("MaxVelocityX", emitter.MaxVelocityX.ToString());
                writer.WriteAttributeString("MaxVelocityY", emitter.MaxVelocityY.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("ParticleAmount");
                writer.WriteAttributeString("Count", emitter.NumberParticles.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("StartARGB");
                writer.WriteAttributeString("Alpha", emitter.StartColor.A.ToString());
                writer.WriteAttributeString("Red", emitter.StartColor.R.ToString());
                writer.WriteAttributeString("Green", emitter.StartColor.G.ToString());
                writer.WriteAttributeString("Blue", emitter.StartColor.B.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("EndARGB");
                writer.WriteAttributeString("Alpha", emitter.EndColor.A.ToString());
                writer.WriteAttributeString("Red", emitter.EndColor.R.ToString());
                writer.WriteAttributeString("Green", emitter.EndColor.G.ToString());
                writer.WriteAttributeString("Blue", emitter.EndColor.B.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("StartScale");
                writer.WriteAttributeString("MaxScale", emitter.StartMaxScale.ToString());
                writer.WriteAttributeString("MinScale", emitter.StartMinScale.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("EndScale");
                writer.WriteAttributeString("MaxScale", emitter.EndMaxScale.ToString());
                writer.WriteAttributeString("MinScale", emitter.EndMinScale.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Force");
                writer.WriteAttributeString("Gravity", emitter.Gravity.ToString());
                writer.WriteAttributeString("Wind", emitter.Wind.ToString());
                writer.WriteAttributeString("Inertia", emitter.Inertia.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Emission");
                writer.WriteAttributeString("EmissionSpeed", emitter.EmissionSpeed.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Blending");
                writer.WriteAttributeString("SourceBlend", ((int)SrcBlend).ToString());
                writer.WriteAttributeString("DestinationBlend", ((int)DestBlend).ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Events");
                writer.WriteAttributeString("Count", emitter.Events.Count.ToString());
                for(int i = 0; i < emitter.Events.Count; ++i)
                {
                    writer.WriteStartElement("Event");
                    writer.WriteAttributeString("EventID", emitter.Events[i].EventID);
                    writer.WriteAttributeString("PlayOnDeath", emitter.Events[i].PlayAtDeath.ToString());
                    writer.WriteAttributeString("PlayOnBirth", emitter.Events[i].PlayAtBirth.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Updates all the labels
        /// </summary>
        /// <returns>void</returns>

        private void UpdateLabels()
        {
            lblEmitterH.Text = emitter.Height.ToString();
            lblEmitterW.Text = emitter.Height.ToString();
            lblEmitterX.Text = emitter.X.ToString();
            lblEmitterY.Text = emitter.Y.ToString();
            lblEndAlpha.Text = emitter.EndColor.A.ToString();
            lblEndRed.Text = emitter.EndColor.R.ToString();
            lblEndBlue.Text = emitter.EndColor.B.ToString();
            lblEndGreen.Text = emitter.EndColor.G.ToString();
            lblStartAlpha.Text = emitter.StartColor.A.ToString();
            lblStartRed.Text = emitter.StartColor.R.ToString();
            lblStartGreen.Text = emitter.StartColor.G.ToString();
            lblStartBlue.Text = emitter.StartColor.B.ToString();
            lblParticleCount.Text = emitter.ParticleList.Count.ToString();
        }

        /// <summary>
        /// exports to binary
        /// </summary>
        /// <returns>void</returns>

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "mmp";
            dlg.Filter = "Monster Mash Particle Files (*.mmp)|*.mmp|All Files (*.*)|*.*";
            dlg.FilterIndex = 1;
            if (DialogResult.OK == dlg.ShowDialog())
            {

                FileStream fs = new FileStream(dlg.FileName, FileMode.Create);
                BinaryWriter w = new BinaryWriter(fs);

                w.Write(emitter.StartColor.A);
                w.Write(emitter.StartColor.R);
                w.Write(emitter.StartColor.G);
                w.Write(emitter.StartColor.B);

                w.Write(emitter.EndColor.A);
                w.Write(emitter.EndColor.R);
                w.Write(emitter.EndColor.G);
                w.Write(emitter.EndColor.B);

                w.Write(emitter.StartMaxScale);
                w.Write(emitter.StartMinScale);
                w.Write(emitter.EndMaxScale);
                w.Write(emitter.EndMinScale);

                w.Write(emitter.MaxLife);
                w.Write(emitter.MinLife);

                w.Write(emitter.NumberParticles);

                w.Write(emitter.Inertia);
                w.Write(emitter.Gravity);
                w.Write(emitter.Wind);

                w.Write(szImagePath.Length);
                w.Write(szImagePath); //Paticle Image FilePath
                w.Write(emitter.EmissionSpeed);
                w.Write(emitter.EmitMode);

                w.Write(emitter.MinVelocityX);
                w.Write(emitter.MaxVelocityX);
                w.Write(emitter.MinVelocityY);
                w.Write(emitter.MaxVelocityY);

                w.Write(emitter.Width);
                w.Write(emitter.Height);

                w.Write(SrcBlend);
                w.Write(DestBlend);
                //
                w.Write(IsEmitting);
                w.Write(emitter.EmitMode);
                w.Write(emitter.AnimationType);
                

                w.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// Imports from binary
        /// </summary>
        /// <returns>void</returns>

        private void importBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.DefaultExt = "mmp";
            opn.Filter = "Monster Mash Particle Files (*.mmp)|*.mmp|All Files (*.*)|*.*";
            opn.FilterIndex = 1;

            if (DialogResult.OK == opn.ShowDialog())
            {
                FileStream fs = new FileStream(opn.FileName, FileMode.Open);
                BinaryReader r = new BinaryReader(fs);

                Byte A = r.ReadByte();
                Byte R = r.ReadByte();
                Byte G = r.ReadByte();
                Byte B = r.ReadByte();
                emitter.StartColor = Color.FromArgb(A, R, G, B);

                A = r.ReadByte();
                R = r.ReadByte();
                G = r.ReadByte();
                B = r.ReadByte();
                emitter.EndColor = Color.FromArgb(A, R, G, B);

                emitter.StartMaxScale = r.ReadSingle();
                emitter.StartMinScale = r.ReadSingle();
                emitter.EndMaxScale = r.ReadSingle();
                emitter.EndMinScale = r.ReadSingle();

                emitter.MaxLife = r.ReadSingle();
                emitter.MinLife = r.ReadSingle();

                emitter.NumberParticles = r.ReadInt32();

                emitter.Inertia = r.ReadSingle();
                emitter.Gravity = r.ReadSingle();
                emitter.Wind = r.ReadSingle();

                int StringSize = r.ReadInt32(); //read in the size of the image path
                szImagePath = r.ReadString();
                emitter.EmissionSpeed = r.ReadInt32();
                emitter.EmitMode = r.ReadInt32();

                emitter.MinVelocityX = r.ReadSingle();
                emitter.MaxVelocityX = r.ReadSingle();
                emitter.MinVelocityY = r.ReadSingle();
                emitter.MaxVelocityY = r.ReadSingle();

                emitter.Width = r.ReadInt32();
                emitter.Height = r.ReadInt32();

                SrcBlend = r.ReadInt32();
                DestBlend = r.ReadInt32();

                IsEmitting = r.ReadBoolean();

                emitter.EmitMode = r.ReadInt32();
                emitter.AnimationType = r.ReadInt32();

                UpdateControls();

                r.Close();
                fs.Close();
                
            }
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            emitter.AnimationType = (int)ANIMATION_TYPE.SINGLE;
        }

        private void btnContinuous_Click(object sender, EventArgs e)
        {
            emitter.AnimationType = (int)ANIMATION_TYPE.CONTINUOUS;
        }
    }
}
