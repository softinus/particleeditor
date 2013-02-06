using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParticleEditor
{
    public partial class MainForm : Form
    {
        public enum Buttons { TitleBar = 0 };
        public enum TitleBarButton { Min, Max, Close };

        UC_ParticleMain m_ParticleMain = null;

        public MainForm()
        {
            InitializeComponent();

            m_ParticleMain = new UC_ParticleMain();
            m_ParticleMain.Dock = DockStyle.Fill;
            m_ParticleMain.Parent = this.pnCenter;


        }


        //SendView
        internal void SetViewBackR(float _fBackR)
        {
            m_ParticleMain.SetViewBackR(_fBackR);
        }
        internal void SetViewBackG(float _fBackG)
        {
            m_ParticleMain.SetViewBackG(_fBackG);
        }
        internal void SetViewBackB(float _fBackB)
        {
            m_ParticleMain.SetViewBackB(_fBackB);
        }
        internal void SetViewTexture(string _szTexture, int _iIndex)
        {
            m_ParticleMain.SetViewTexture(_szTexture, _iIndex);
        }

        //Tab02 14
        internal void SetViewEmitterType(string _szEmitterType)
        {
            m_ParticleMain.SetViewEmitterType(_szEmitterType);
        }
        internal void SetViewMaxParticles(float _fMaxParticles)
        {
            m_ParticleMain.SetViewMaxParticles(_fMaxParticles);
        }
        internal void SetViewLifespan(float _fLifespan)
        {
            m_ParticleMain.SetViewBarToBoxLifespan(_fLifespan);
        }
        internal void SetViewLifespanVar(float _fLifespanVar)
        {
            m_ParticleMain.SetViewLifespanVar(_fLifespanVar);
        }
        internal void SetViewStartSize(float _fStartSize)
        {
            m_ParticleMain.SetViewStartSize(_fStartSize);
        }
        internal void SetViewStartSizeVar(float _fStartSizeVar)
        {
            m_ParticleMain.SetViewStartSizeVar(_fStartSizeVar);
        }
        internal void SetViewFinishSize(float _fFinishSize)
        {
            m_ParticleMain.SetViewFinishSize(_fFinishSize);
        }
        internal void SetViewFinishSizeVar(float _fFinishSizeVar)
        {
            m_ParticleMain.SetViewFinishSizeVar(_fFinishSizeVar);
        }
        internal void SetViewEmitterAngle(float _fEmitterAngle)
        {
            m_ParticleMain.SetViewEmitterAngle(_fEmitterAngle);
        }
        internal void SetViewAngleVar(float _fAngleVar)
        {
            m_ParticleMain.SetViewAngleVar(_fAngleVar);
        }
        internal void SetViewStartRot(float _fStartRot)
        {
            m_ParticleMain.SetViewStartRot(_fStartRot);
        }
        internal void SetViewStartRotVar(float _fStartRotVar)
        {
            m_ParticleMain.SetViewStartRotVar(_fStartRotVar);
        }
        internal void SetViewEndRot(float _fEndRot)
        {
            m_ParticleMain.SetViewEndRot(_fEndRot);
        }
        internal void SetViewEndRotVar(float _fEndRotVar)
        {
            m_ParticleMain.SetViewEndRotVar(_fEndRotVar);
        }

        //Tab03 15
        internal void SetViewXVariance(float _fXVariance)
        {
            m_ParticleMain.SetViewXVariance(_fXVariance);
        }
        internal void SetViewYVariance(float _fYVariance)
        {
            m_ParticleMain.SetViewYVariance(_fYVariance);
        }
        internal void SetViewSpeed(float _fSpeed)
        {
            m_ParticleMain.SetViewSpeed(_fSpeed);
        }
        internal void SetViewSpeedVariance(float _fSpeedVar)
        {
            m_ParticleMain.SetViewSpeedVariance(_fSpeedVar);
        }
        internal void SetViewGravityX(float _fGravityX)
        {
            m_ParticleMain.SetViewGravityX(_fGravityX);
        }
        internal void SetViewGravityY(float _fGravityY)
        {
            m_ParticleMain.SetViewGravityY(_fGravityY);
        }
        internal void SetViewTanAcc(float _fTanAcc)
        {
            m_ParticleMain.SetViewTanAcc(_fTanAcc);
        }
        internal void SetViewTanAccVar(float _fTanAccVar)
        {
            m_ParticleMain.SetViewTanAccVar(_fTanAccVar);
        }
        internal void SetViewRadAcc(float _fRadAcc)
        {
            m_ParticleMain.SetViewRadAcc(_fRadAcc);
        }
        internal void SetViewRadAccVar(float _fRadAccVar)
        {
            m_ParticleMain.SetViewRadAccVar(_fRadAccVar);
        }
        internal void SetViewMaxRadius(float _fMaxRadius)
        {
            m_ParticleMain.SetViewMaxRadius(_fMaxRadius);
        }
        internal void SetViewMaxRadiusVar(float _fMaxRadiusVar)
        {
            m_ParticleMain.SetViewMaxRadiusVar(_fMaxRadiusVar);
        }
        internal void SetViewMinRadius(float _fMinRadius)
        {
            m_ParticleMain.SetViewMinRadius(_fMinRadius);
        }
        internal void SetViewDegSec(float _fDegSec)
        {
            m_ParticleMain.SetViewDegSec(_fDegSec);
        }
        internal void SetViewDegSecVar(float _fDegSecVar)
        {
            m_ParticleMain.SetViewDegSecVar(_fDegSecVar);
        }

        //Tab04
        internal void SetViewStartR(float _fStartR)
        {
            m_ParticleMain.SetViewStartR(_fStartR);
        }
        internal void SetViewStartG(float _fStartG)
        {
            m_ParticleMain.SetViewStartG(_fStartG);
        }
        internal void SetViewStartB(float _fStartB)
        {
            m_ParticleMain.SetViewStartB(_fStartB);
        }
        internal void SetViewStartA(float _fStartA)
        {
            m_ParticleMain.SetViewStartA(_fStartA);
        }
        internal void SetViewFinishR(float _fFinishR)
        {
            m_ParticleMain.SetViewFinishR(_fFinishR);
        }
        internal void SetViewFinishG(float _fFinishG)
        {
            m_ParticleMain.SetViewFinishG(_fFinishG);
        }
        internal void SetViewFinishB(float _fFinishB)
        {
            m_ParticleMain.SetViewFinishB(_fFinishB);
        }
        internal void SetViewFinishA(float _fFinishA)
        {
            m_ParticleMain.SetViewFinishA(_fFinishA);
        }

        //Tab05

        internal void SetViewStartVarR(float _fStartVarR)
        {
            m_ParticleMain.SetViewStartVarR(_fStartVarR);
        }
        internal void SetViewStartVarG(float _fStartVarG)
        {
            m_ParticleMain.SetViewStartVarG(_fStartVarG);
        }
        internal void SetViewStartVarB(float _fStartVarB)
        {
            m_ParticleMain.SetViewStartVarB(_fStartVarB);
        }
        internal void SetViewStartVarA(float _fStartVarA)
        {
            m_ParticleMain.SetViewStartVarA(_fStartVarA);
        }
        internal void SetViewFinishVarR(float _fFinishVarR)
        {
            m_ParticleMain.SetViewFinishVarR(_fFinishVarR);
        }
        internal void SetViewFinishVarG(float _fFinishVarG)
        {
            m_ParticleMain.SetViewFinishVarG(_fFinishVarG);
        }
        internal void SetViewFinishVarB(float _fFinishVarB)
        {
            m_ParticleMain.SetViewFinishVarB(_fFinishVarB);
        }
        internal void SetViewFinishVarA(float _fFinishVarA)
        {
            m_ParticleMain.SetViewFinishVarA(_fFinishVarA);
        }
        internal void SetViewSource(string _szSource)
        {
            m_ParticleMain.SetViewSource(_szSource);
        }
        internal void SetViewDest(string _szDest)
        {
            m_ParticleMain.SetViewDest(_szDest);
        }

        private bool m_bTopMoiseDown = false;
        private Point m_ptMoveStart = new Point(0, 0);
        private int m_iType = -1;
        private Point m_ptSizingStartPoint = new Point(0, 0);
        bool m_bMainMouseDown = false;
        Size m_szCurrent = new Size(0, 0);

        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            m_bTopMoiseDown = true;
            m_ptMoveStart = this.PointToScreen(new Point(e.X, e.Y));
        }

        private void pnTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bTopMoiseDown)
            {
                Point ptTarget = this.PointToScreen(new Point(e.X, e.Y));

                this.Location = new Point(this.Location.X + (ptTarget.X - m_ptMoveStart.X), this.Location.Y + (ptTarget.Y - m_ptMoveStart.Y));
                m_ptMoveStart = ptTarget;
            }
        }

        private void pnTop_MouseUp(object sender, MouseEventArgs e)
        {
            m_bTopMoiseDown = false;
        }

        private void Main_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            m_bMainMouseDown = false;
            m_ptSizingStartPoint = this.PointToScreen(new Point(e.X, e.Y));
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            m_bMainMouseDown = false;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bMainMouseDown)
            {
                Size szCurrent = this.Size;
                Point ptLocation = this.Location;

                Point ptTarget = this.PointToScreen(new Point(e.X, e.Y));

                int iXGap = (ptTarget.X - m_ptSizingStartPoint.X);
                int iYGap = (ptTarget.Y - m_ptSizingStartPoint.Y);

                //int iTopBottom = ((m_iType == 1) || (m_iType == 2) || (m_iType == 3) || (m_iType == 4) || (m_iType == 6)) ? 0 : 1;

                //if (iTopBottom == 0)
                //{
                //    if ((iXGap > 0) && (this.Width == this.MinimumSize.Width))
                //        return;
                //}
                //else
                //{
                //    if ((iYGap > 0) && (this.Height == this.MinimumSize.Height))
                //        return;
                //}

                // 1: Top, 2: Top-Left, 3: Top-Right, 4: Left, 5: Right, 6: Bottom-Left, 7: Bottom-Right, 8: Bottom
               
                //


                switch (m_iType)
                {
                    case 1:
                        if (this.Size.Height - iYGap < this.MinimumSize.Height)
                            return;

                        szCurrent = new Size(this.Size.Width, this.Size.Height - iYGap);
                        ptLocation = new Point(this.Location.X, this.Location.Y + iYGap); 
                        break;
                    case 2:
                        if ((this.Size.Height - iYGap > this.MinimumSize.Height) && (this.Size.Width - iXGap > this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width - iXGap, this.Size.Height - iYGap);
                            ptLocation = new Point(this.Location.X + iXGap, this.Location.Y + iYGap); 
                        }
                        else if ((this.Size.Height - iYGap > this.MinimumSize.Height) && (this.Size.Width - iXGap < this.MinimumSize.Width))
                        {
                            //szCurrent = new Size(this.Size.Width - iXGap, this.Size.Height);

                            szCurrent = new Size(this.Size.Width, this.Size.Height - iYGap);
                            ptLocation = new Point(this.Location.X, this.Location.Y + iYGap);
                        }
                        else if ((this.Size.Height - iYGap < this.MinimumSize.Height) && (this.Size.Width - iXGap > this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width - iXGap, this.Size.Height);
                            ptLocation = new Point(this.Location.X + iXGap, this.Location.Y);                             
                        }
                        break;
                    case 3:
                        if ((this.Size.Height - iYGap > this.MinimumSize.Height) && (this.Size.Width + iXGap > this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width + iXGap, this.Size.Height - iYGap);
                            ptLocation = new Point(this.Location.X, this.Location.Y + iYGap);
                        }
                        else if ((this.Size.Height - iYGap > this.MinimumSize.Height) && (this.Size.Width + iXGap < this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width, this.Size.Height - iYGap);
                            ptLocation = new Point(this.Location.X, this.Location.Y + iYGap);
                        }
                        else if ((this.Size.Height - iYGap < this.MinimumSize.Height) && (this.Size.Width + iXGap > this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width + iXGap, this.Size.Height);
                            ptLocation = new Point(this.Location.X, this.Location.Y);
                        }
                        break;
                    case 4:
                        if (this.Size.Width - iXGap < this.MinimumSize.Width)
                            return;

                        szCurrent = new Size(this.Size.Width - iXGap, this.Size.Height);
                        ptLocation = new Point(this.Location.X + iXGap, this.Location.Y);
                        break;
                    case 5:
                        if (this.Size.Width + iXGap < this.MinimumSize.Width)
                            return;

                        szCurrent = new Size(this.Size.Width + iXGap, this.Size.Height);
                        break;
                    case 6:
                        //this.Location = new Point(this.Location.X + iXGap, this.Location.Y);
                        szCurrent = new Size(this.Size.Width - iXGap, this.Size.Height + iYGap);

                        if ((szCurrent.Height > this.MinimumSize.Height) && (szCurrent.Width > this.MinimumSize.Width))
                            ptLocation = new Point(this.Location.X + iXGap, this.Location.Y);
                        else if ((szCurrent.Height <= this.MinimumSize.Height) && (szCurrent.Width > this.MinimumSize.Width))
                            ptLocation = new Point(this.Location.X + iXGap, this.Location.Y);
                        else if ((szCurrent.Height > this.MinimumSize.Height) && (szCurrent.Width <= this.MinimumSize.Width))
                            ptLocation = new Point(this.Location.X, this.Location.Y);

                        break;
                    case 7:
                        if ((this.Size.Height + iYGap > this.MinimumSize.Height) && (this.Size.Width + iXGap > this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width + iXGap, this.Size.Height + iYGap);
                            ptLocation = new Point(this.Location.X - iXGap, this.Location.Y);
                        }
                        else if ((this.Size.Height + iYGap > this.MinimumSize.Height) && (this.Size.Width + iXGap < this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width, this.Size.Height + iYGap);
                            ptLocation = new Point(this.Location.X, this.Location.Y - iYGap);
                        }
                        else if ((this.Size.Height + iYGap < this.MinimumSize.Height) && (this.Size.Width + iXGap > this.MinimumSize.Width))
                        {
                            szCurrent = new Size(this.Size.Width + iXGap, this.Size.Height);
                            ptLocation = new Point(this.Location.X-  iXGap, this.Location.Y);
                        }
                        break;
                    case 8:
                        if (this.Size.Height + iYGap < this.MinimumSize.Height)
                            return;

                        szCurrent = new Size(this.Size.Width, this.Size.Height + iYGap);
                        break;
                    case 0:
                    default:
                        return;
                }

                this.Location = ptLocation;
                this.Size = szCurrent;
                

                m_ptSizingStartPoint = ptTarget;
                
            }
            else
            SetCursorType(e.X, e.Y);
        }

        private void SetCursorType(int iX, int iY)
        {
            int iWidth = this.ClientRectangle.Width;
            int iHeight = this.ClientRectangle.Height;

            int iPositionX = (iX < 10) ? 0 : ((iX > (iWidth - 10) ? 2 : 1));
            int iPositionY = (iY < 10) ? 0 : ((iY > (iHeight - 10) ? 2 : 1));

            switch (iPositionX)
            {
                case 0:
                    switch (iPositionY)
                    {
                        case 0:
                            m_iType = 2;
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                        case 1:
                            m_iType = 4;
                            this.Cursor = Cursors.SizeWE;
                            break;
                        case 2:
                            m_iType = 6;
                            this.Cursor = Cursors.SizeNESW;
                            break;
                    }
                    break;
                case 1:
                    switch (iPositionY)
                    {
                        case 0:
                            m_iType = 1;
                            this.Cursor = Cursors.SizeNS;
                            break;
                        case 1:
                            m_iType = 0;
                            this.Cursor = Cursors.Default;
                            break;
                        case 2:
                            m_iType = 8;
                            this.Cursor = Cursors.SizeNS;
                            break;
                    }
                    break;
                case 2:
                    switch (iPositionY)
                    {
                        case 0:
                            m_iType = 3;
                            this.Cursor = Cursors.SizeNESW;
                            break;
                        case 1:
                            m_iType = 5;
                            this.Cursor = Cursors.SizeWE;
                            break;
                        case 2:
                            m_iType = 7;
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                    }
                    break;
            }
        }

        private void lbClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void lbMax_MouseUp(object sender, MouseEventArgs e)
        {
            FormWindowState wsCurrent = this.WindowState;
            m_szCurrent = this.Size;

            switch (wsCurrent)
            {
                case FormWindowState.Normal:
                    this.WindowState = FormWindowState.Maximized;

                    break;
                case FormWindowState.Maximized:
                    this.WindowState = FormWindowState.Normal;
                    break;

            }
        }
        
        private void lbMin_MouseUp(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnTop_DoubleClick(object sender, EventArgs e)
        {
            FormWindowState wsCurrent = this.WindowState;
            m_szCurrent = this.Size;

            switch (wsCurrent)
            {
                case FormWindowState.Normal :
                    this.WindowState = FormWindowState.Maximized;
                    
                    break;
                case FormWindowState.Maximized :
                    this.WindowState = FormWindowState.Normal;
                    break;

            }
        }

        private void lbMin_MouseMove(object sender, MouseEventArgs e)
        {
            lbMin.Image = ParticleEditor.Properties.Resources.img_minimize_over;
        }

        private void lbMin_MouseLeave(object sender, EventArgs e)
        {
            lbMin.Image = ParticleEditor.Properties.Resources.img_minimize_nor;
        }

        private void lbMax_MouseMove(object sender, MouseEventArgs e)
        {
            lbMax.Image = ParticleEditor.Properties.Resources.img_maximize_over;
        }

        private void lbMax_MouseLeave(object sender, EventArgs e)
        {
            lbMax.Image = ParticleEditor.Properties.Resources.img_maximize_nor;
        }

        private void lbClose_MouseMove(object sender, MouseEventArgs e)
        {
            lbClose.Image = ParticleEditor.Properties.Resources.img_close_over;
        }

        private void lbClose_MouseLeave(object sender, EventArgs e)
        {
            lbClose.Image = ParticleEditor.Properties.Resources.img_close_nor;
        }

        private void lbAbout_MouseHover(object sender, EventArgs e)
        {
            //lbAbout.Image = ParticleEditor.Properties.Resources.img_About_over;
        }

        private void lbAbout_MouseLeave(object sender, EventArgs e) 
        {
            this.Cursor = Cursors.Default;
            lbAbout.Image = ParticleEditor.Properties.Resources.img_About_nor;
        }

        private void lbAbout_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lbAbout.Image = ParticleEditor.Properties.Resources.img_About_over;
        }

        private void lbAbout_MouseClick(object sender, MouseEventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
            aboutForm.Location = new Point(this.Location.X + (this.Width / 2) - (aboutForm.Width / 2), this.Location.Y + (this.Height / 2) - (aboutForm.Height / 2));
        }
    }
}
