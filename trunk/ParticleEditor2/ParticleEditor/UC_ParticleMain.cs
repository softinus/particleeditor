using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParticleEditor
{
    public partial class UC_ParticleMain : UserControl
    {
        UC_ParticleControl m_UC_ParticleControl = null;
        UC_ParticleView m_UC_ParticleView = null;

        List<Image> m_ltImage = new List<Image>();

        public UC_ParticleMain()
        {
            InitializeComponent();

            m_UC_ParticleControl = new UC_ParticleControl();
            m_UC_ParticleControl.Dock = DockStyle.Fill;
            m_UC_ParticleControl.Parent = this.pnControl;

            m_UC_ParticleView = new UC_ParticleView();
            m_UC_ParticleView.Dock = DockStyle.Fill;
            m_UC_ParticleView.Parent = this.pnView;

            m_ltImage.Add(ParticleEditor.Properties.Resources.img_SampleCircle);
            m_ltImage.Add(ParticleEditor.Properties.Resources.img_SampleStart);
            m_ltImage.Add(ParticleEditor.Properties.Resources.img_SampleBlob);
            m_ltImage.Add(ParticleEditor.Properties.Resources.img_SampleHeart);

            m_UC_ParticleControl.SetTextuerImage(m_ltImage[0]);
        }
        //
        string m_szPath = string.Empty;

        public void SetCustomImage(string _szPath, Bitmap _bmpTexture)
        {
            m_szPath = _szPath;

            if (m_ltImage.Count() != 5)
                m_ltImage.Add((Image)_bmpTexture);
            else
            {
                m_ltImage.RemoveAt(4);
                m_ltImage.Add((Image)_bmpTexture);
            }
        }
        //SendView
        internal void SetViewBackR(float _fBackR)
        {
            m_UC_ParticleView.SetBackR(_fBackR);
        }
        internal void SetViewBackG(float _fBackG)
        {
            m_UC_ParticleView.SetBackG(_fBackG);
        }
        internal void SetViewBackB(float _fBackB)
        {
            m_UC_ParticleView.SetBackB(_fBackB);
        }
        internal void SetViewTexture(string _szTexture, int _iIndex)
        {
            if (_iIndex != 4)
            {
                m_UC_ParticleControl.SetTextuerImage(m_ltImage[_iIndex]);
                m_UC_ParticleView.SetTexture(_szTexture, false);
            }
            else
            {
                if (m_ltImage.Count == 5)
                {
                    m_UC_ParticleControl.SetTextuerImage(m_ltImage[4]);
                    m_UC_ParticleView.SetTexture(m_szPath, true);
                }
            }
        }

        //Tab02 14
        internal void SetViewEmitterType(string _szEmitterType)
        {
            m_UC_ParticleView.SetEmitterType(_szEmitterType);
        }
        internal void SetViewMaxParticles(float _fMaxParticles)
        {
            m_UC_ParticleView.SetMaxParticles(_fMaxParticles);
        }
        internal void SetViewBarToBoxLifespan(float _fLifespan)
        {
            m_UC_ParticleView.SetBarToBoxLifespan(_fLifespan);
        }
        internal void SetViewLifespanVar(float _fLifespanVar)
        {
            m_UC_ParticleView.SetLifespanVar(_fLifespanVar);
        }
        internal void SetViewStartSize(float _fStartSize)
        {
            m_UC_ParticleView.SetStartSize(_fStartSize);
        }
        internal void SetViewStartSizeVar(float _fStartSizeVar)
        {
            m_UC_ParticleView.SetStartSizeVar(_fStartSizeVar);
        }
        internal void SetViewFinishSize(float _fFinishSize)
        {
            m_UC_ParticleView.SetFinishSize(_fFinishSize);
        }
        internal void SetViewFinishSizeVar(float _fFinishSizeVar)
        {
            m_UC_ParticleView.SetFinishSizeVar(_fFinishSizeVar);
        }
        internal void SetViewEmitterAngle(float _fEmitterAngle)
        {
            m_UC_ParticleView.SetEmitterAngle(_fEmitterAngle);
        }
        internal void SetViewAngleVar(float _fAngleVar)
        {
            m_UC_ParticleView.SetAngleVar(_fAngleVar);
        }
        internal void SetViewStartRot(float _fStartRot)
        {
            m_UC_ParticleView.SetStartRot(_fStartRot);
        }
        internal void SetViewStartRotVar(float _fStartRotVar)
        {
            m_UC_ParticleView.SetStartRotVar(_fStartRotVar);
        }
        internal void SetViewEndRot(float _fEndRot)
        {
            m_UC_ParticleView.SetEndRot(_fEndRot);
        }
        internal void SetViewEndRotVar(float _fEndRotVar)
        {
            m_UC_ParticleView.SetEndRotVar(_fEndRotVar);
        }

        //Tab03 15
        internal void SetViewXVariance(float _fXVariance)
        {
            m_UC_ParticleView.SetXVariance(_fXVariance);
        }
        internal void SetViewYVariance(float _fYVariance)
        {
            m_UC_ParticleView.SetYVariance(_fYVariance);
        }
        internal void SetViewSpeed(float _fSpeed)
        {
            m_UC_ParticleView.SetSpeed(_fSpeed);
        }
        internal void SetViewSpeedVariance(float _fSpeedVar)
        {
            m_UC_ParticleView.SetSpeedVariance(_fSpeedVar);
        }
        internal void SetViewGravityX(float _fGravityX)
        {
            m_UC_ParticleView.SetGravityX(_fGravityX);
        }
        internal void SetViewGravityY(float _fGravityY)
        {
            m_UC_ParticleView.SetGravityY(_fGravityY);
        }
        internal void SetViewTanAcc(float _fTanAcc)
        {
            m_UC_ParticleView.SetTanAcc(_fTanAcc);
        }
        internal void SetViewTanAccVar(float _fTanAccVar)
        {
            m_UC_ParticleView.SetTanAccVar(_fTanAccVar);
        }
        internal void SetViewRadAcc(float _fRadAcc)
        {
            m_UC_ParticleView.SetRadAcc(_fRadAcc);
        }
        internal void SetViewRadAccVar(float _fRadAccVar)
        {
            m_UC_ParticleView.SetRadAccVar(_fRadAccVar);
        }
        internal void SetViewMaxRadius(float _fMaxRadius)
        {
            m_UC_ParticleView.SetMaxRadius(_fMaxRadius);
        }
        internal void SetViewMaxRadiusVar(float _fMaxRadiusVar)
        {
            m_UC_ParticleView.SetMaxRadiusVar(_fMaxRadiusVar);
        }
        internal void SetViewMinRadius(float _fMinRadius)
        {
            m_UC_ParticleView.SetMinRadius(_fMinRadius);
        }
        internal void SetViewDegSec(float _fDegSec)
        {
            m_UC_ParticleView.SetDegSec(_fDegSec);
        }
        internal void SetViewDegSecVar(float _fDegSecVar)
        {
            m_UC_ParticleView.SetDegSecVar(_fDegSecVar);
        }

        //Tab04
        internal void SetViewStartR(float _fStartR)
        {
            m_UC_ParticleView.SetStartR(_fStartR);
        }
        internal void SetViewStartG(float _fStartG)
        {
            m_UC_ParticleView.SetStartG(_fStartG);
        }
        internal void SetViewStartB(float _fStartB)
        {
            m_UC_ParticleView.SetStartB(_fStartB);
        }
        internal void SetViewStartA(float _fStartA)
        {
            m_UC_ParticleView.SetStartA(_fStartA);
        }
        internal void SetViewFinishR(float _fFinishR)
        {
            m_UC_ParticleView.SetFinishR(_fFinishR);
        }
        internal void SetViewFinishG(float _fFinishG)
        {
            m_UC_ParticleView.SetFinishG(_fFinishG);
        }
        internal void SetViewFinishB(float _fFinishB)
        {
            m_UC_ParticleView.SetFinishB(_fFinishB);
        }
        internal void SetViewFinishA(float _fFinishA)
        {
            m_UC_ParticleView.SetFinishA(_fFinishA);
        }

        //Tab05

        internal void SetViewStartVarR(float _fStartVarR)
        {
            m_UC_ParticleView.SetStartVarR(_fStartVarR);
        }
        internal void SetViewStartVarG(float _fStartVarG)
        {
            m_UC_ParticleView.SetStartVarG(_fStartVarG);
        }
        internal void SetViewStartVarB(float _fStartVarB)
        {
            m_UC_ParticleView.SetStartVarB(_fStartVarB);
        }
        internal void SetViewStartVarA(float _fStartVarA)
        {
            m_UC_ParticleView.SetStartVarA(_fStartVarA);
        }
        internal void SetViewFinishVarR(float _fFinishVarR)
        {
            m_UC_ParticleView.SetFinishVarR(_fFinishVarR);
        }
        internal void SetViewFinishVarG(float _fFinishVarG)
        {
            m_UC_ParticleView.SetFinishVarG(_fFinishVarG);
        }
        internal void SetViewFinishVarB(float _fFinishVarB)
        {
            m_UC_ParticleView.SetFinishVarB(_fFinishVarB);
        }
        internal void SetViewFinishVarA(float _fFinishVarA)
        {
            m_UC_ParticleView.SetFinishVarA(_fFinishVarA);
        }
        internal void SetViewSource(string _szSource)
        {
            m_UC_ParticleView.SetSource(_szSource);
        }
        internal void SetViewDest(string _szDest)
        {
            m_UC_ParticleView.SetDest(_szDest);
        }

        internal void SetTextureSelect()
        {
            m_UC_ParticleControl.SetTextureSelect();
        }
    }
}
