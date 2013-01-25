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
    public partial class UC_ParticleControl : UserControl
    {
        public UC_ParticleControl()
        {
            InitializeComponent();

            ControlInit();
        }
        private void ControlInit()
        {
            cbSelectTexture.SelectedIndex = 0;
            cbEmitter.SelectedIndex = 0;
            cbTab05Source.SelectedIndex = 0;
            cbTab05Dest.SelectedIndex = 0;

            trbDegSec.Value = 3600;
        }

        public void SetTextuerImage(Image _imgSample)
        {
            pbSample.Image = _imgSample;
        }

        //BarToBox
        #region

        //Tab01
        private void SetBarToBoxR()
        {
            float fData = trbR.Value * 0.1f;
            tbR.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewBackR(fData);
        }
        private void SetBarToBoxG()
        {
            float fData = trbG.Value * 0.1f;
            tbG.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewBackG(fData);
        }
        private void SetBarToBoxB()
        {
            float fData = trbB.Value * 0.1f;
            tbB.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewBackB(fData);
        }

        private void SetTexture()
        {
            string szData = cbSelectTexture.SelectedItem.ToString();

            if ((MainForm)this.ParentForm != null)
            ((MainForm)this.ParentForm).SetViewTexture(szData);
        }

        //Tab02
        
        private void SetEmitter()
        {
            string szData = cbEmitter.SelectedItem.ToString();

            if ((MainForm)this.ParentForm != null)
            ((MainForm)this.ParentForm).SetViewEmitterType(szData);
        }
        private void SetBarToBoxMaxParticles()
        {
            float fData = trbMaxParticles.Value * 0.1f;
            tbMaxParticles.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewMaxParticles(fData);
        }
        private void SetBarToBoxLifespan()
        {
            float fData = trbLifespan.Value * 0.1f;
            tbLifespan.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewLifespan(fData);
        }
        private void SetBarToBoxLifespanVar()
        {
            float fData = trbLifespanVar.Value * 0.1f;
            tbLifespanVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewLifespanVar(fData);
        }
        private void SetBarToBoxStartSize()
        {
            float fData = trbStartSize.Value * 0.1f;
            tbStartSize.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewLifespanVar(fData);
        }
        private void SetBarToBoxStartSizeVar()
        {
            float fData = trbStartSizeVar.Value * 0.1f;
            tbStartSizeVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartSizeVar(fData);
        }
        private void SetBarToBoxFinishSize()
        {
            float fData = trbFinishSize.Value * 0.1f;
            tbFinishSize.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartSize(fData);
        }
        private void SetBarToBoxFinishSizeVar()
        {
            float fData = trbFinishSizeVar.Value * 0.1f;
            tbFinishSizeVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartSize(fData);
        }
        private void SetBarToBoxEmitterAngle()
        {
            float fData = trbEmitter.Value * 0.1f;
            tbFinishSizeVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewEmitterAngle(fData);
        }
        private void SetBarToBoxAngleVar()
        {
            float fData = trbAngle.Value * 0.1f;
            tbAngle.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewAngleVar(fData);
        }
        private void SetBarToBoxStartRot()
        {
            float fData = trbStart.Value * 0.1f;
            tbStart.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartRot(fData);
        }
        private void SetBarToBoxStartRotVar()
        {
            float fData = trbStartVar.Value * 0.1f;
            tbStartVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartRotVar(fData);
        }
        private void SetBarToBoxEndRot()
        {
            float fData = trbEnd.Value * 0.1f;
            tbEnd.Text = string.Format("{0:F1}", (trbEnd.Value * 0.1));

            ((MainForm)this.ParentForm).SetViewEndRot(fData);
        }
        private void SetBarToBoxEndRotVar()
        {
            float fData = trbEndVar.Value * 0.1f;
            tbEndVar.Text = string.Format("{0:F1}", (trbEndVar.Value * 0.1));

            ((MainForm)this.ParentForm).SetViewEndRotVar(fData);
        }

        //Tab03
        private void SetBarToBoxXVariance()
        {
            float fData = trbXVar.Value * 0.1f;
            tbXVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewXVariance(fData);
        }
        private void SetBarToBoxYVariance()
        {
            float fData = trbYVar.Value * 0.1f;
            tbYVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewYVariance(fData);
        }
        private void SetBarToBoxSpeed()
        {
            float fData = trbSpeed.Value * 0.1f;
            tbSpeed.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewSpeed(fData);
        }
        private void SetBarToBoxSpeedVariance()
        {
            float fData = trbSpeedVariance.Value * 0.1f;
            tbSpeedVariance.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewSpeedVariance(fData);
        }
        private void SetBarToBoxGravityX()
        {
            float fData = trbGravityX.Value * 0.1f;
            tbGravityX.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewGravityX(fData);
        }
        private void SetBarToBoxGravityY()
        {
            float fData = trbGravityY.Value * 0.1f;
            tbGravityY.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewGravityY(fData);
        }
        private void SetBarToBoxTanAcc()
        {
            float fData = trbTanAcc.Value * 0.1f; 
            tbTanAcc.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewTanAcc(fData);
        }
        private void SetBarToBoxTanAccVar()
        {
            float fData = trbTanAccVar.Value * 0.1f;
            tbTanAccVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewTanAccVar(fData);
        }
        private void SetBarToBoxRadAcc()
        {
            float fData = trbRadAcc.Value * 0.1f;
            tbRadAcc.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewRadAcc(fData);
        }
        private void SetBarToBoxRadAccVar()
        {
            float fData = trbRadAccVar.Value * 0.1f;
            tbRadAccVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewRadAccVar(fData);
        }

        private void SetBarToBoxMaxRadius()
        {
            float fData = trbMaxRadius.Value * 0.1f;
            tbMaxRadius.Text = string.Format("{0:F1}", (trbMaxRadius.Value * 0.1));

            ((MainForm)this.ParentForm).SetViewMaxRadius(fData);
        }
        private void SetBarToBoxMaxRadiusVar()
        {
            float fData = trbMaxRadiusVar.Value * 0.1f;
            tbMaxRadiusVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewMaxRadiusVar(fData);
        }
        private void SetBarToBoxMinRadius()
        {
            float fData = trbMinRadius.Value * 0.1f;
            tbMinRadius.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewMinRadius(fData);
        }

        private void SetBarToBoxDegSec()
        {
            float fCenter = trbDegSec.Maximum / 2.0f;
            float fData = ((trbDegSec.Value) - fCenter ) * 0.1f;

            tbDegSec.Text = string.Format("{0:F1}", (fData));

            if ((MainForm)this.ParentForm != null)
                ((MainForm)this.ParentForm).SetViewDegSec(fData);
        }
        private void SetBarToBoxDegSecVar()
        {
            float fData = trbDegSecVar.Value * 0.1f;
            tbDegSecVar.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewDegSecVar(fData);
        }

        //Tab04
        private void SetBarToBoxStartR()
        {
            float fData = trbStartR.Value * 0.1f;
            tbStartR.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartR(fData);
        }
        private void SetBarToBoxStartG()
        {
            float fData = trbStartG.Value * 0.1f;
            tbStartG.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartG(fData);
        }
        private void SetBarToBoxStartB()
        {
            float fData = trbStartB.Value * 0.1f;
            tbStartB.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartB(fData);
        }
        private void SetBarToBoxStartA()
        {
            float fData = trbStartA.Value * 0.1f;
            tbStartA.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartA(fData);
        }
        private void SetBarToBoxFinishR()
        {
            float fData = trbFinishR.Value * 0.1f;
            tbFinishR.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishR(fData);
        }
        private void SetBarToBoxFinishG()
        {
            float fData = trbFinishG.Value * 0.1f;
            tbFinishG.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishG(fData);
        }
        private void SetBarToBoxFinishB()
        {
            float fData = trbFinishB.Value * 0.1f;
            tbFinishB.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishB(fData);
        }
        private void SetBarToBoxFinishA()
        {
            float fData = trbFinishA.Value * 0.1f;
            tbFinishA.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishA(fData);
        }

        //Tab05

        private void SetBarToBoxStartVarR()
        {
            float fData = trbStartVarR.Value * 0.1f;
            tbStartVarR.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartVarR(fData);
        }
        private void SetBarToBoxStartVarG()
        {
            float fData = trbStartVarG.Value * 0.1f;
            tbStartVarG.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartVarG(fData);
        }
        private void SetBarToBoxStartVarB()
        {
            float fData = trbStartVarB.Value * 0.1f;
            tbStartVarB.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartVarB(fData);
        }
        private void SetBarToBoxStartVarA()
        {
            float fData = trbStartA.Value * 0.1f;
            tbStartVarA.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewStartVarA(fData);
        }
        private void SetBarToBoxFinishVarR()
        {
            float fData = trbFinishVarR.Value * 0.1f;
            tbFinishVarR.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishVarR(fData);
        }
        private void SetBarToBoxFinishVarG()
        {
            float fData = trbFinishVarG.Value * 0.1f;
            tbFinishVarG.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishVarG(fData);
        }
        private void SetBarToBoxFinishVarB()
        {
            float fData = trbFinishVarB.Value * 0.1f;
            tbFinishVarB.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishVarB(fData);
        }
        private void SetBarToBoxFinishVarA()
        {
            float fData = trbFinishVarA.Value * 0.1f;
            tbFinishVarA.Text = string.Format("{0:F1}", (fData));

            ((MainForm)this.ParentForm).SetViewFinishVarA(fData);
        }

        bool m_bSource = false;
        bool m_bDest = false;

        private void SetSource()
        {
            if (!m_bSource)
            {
                m_bSource = true;
                return;
            }
            string szData = cbTab05Source.SelectedItem.ToString();

            ((MainForm)this.ParentForm).SetViewSource(szData);
        }
        private void SetDest()
        {
            if (!m_bDest)
            {
                m_bDest = true;
                return;
            }
            string szData = cbTab05Dest.SelectedItem.ToString();

            ((MainForm)this.ParentForm).SetViewDest(szData);
        }


        #endregion




        //Tab01 Event
        private void trbR_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxR();
            
        }

        private void trbG_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxG();
        }

        private void trbB_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxB();
        }

        //Tab02 Event
        private void trbMaxParticles_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxMaxParticles();
        }

        private void trbLifespan_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxLifespan();
        }

        private void trbLifespanVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxLifespanVar();
        }


        private void trbStartSize_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartSize();
        }

        private void trbStartSizeVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartSizeVar();
        }

        private void trbFinishSize_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishSize();
        }

        private void trbFinishSizeVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishSizeVar();
        }

        private void trbEmitter_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxEmitterAngle();
        }

        private void trbAngle_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxAngleVar();
        }

        private void trbStart_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartRot();
        }

        private void trbStartVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartRotVar();
        }

        private void trbEnd_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxEndRot();
        }

        private void trbEndVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxEndRotVar();
        }

        //Tab03 Event

        private void trbXVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxXVariance();
        }

        private void trbYVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxYVariance();
        }

        private void trbSpeed_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxSpeed();
        }

        private void trbSpeedVariance_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxSpeedVariance();
        }

        private void trbGravityX_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxGravityX();
        }

        private void trbGravityY_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxGravityY();
        }

        private void trbTanAcc_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxTanAcc();
        }

        private void trbTanAccVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxTanAccVar();
        }

        private void trbRadAcc_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxRadAcc();
        }

        private void trbRadAccVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxRadAccVar();
        }

        private void trbMaxRadius_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxMaxRadius();
        }

        private void trbMaxRadiusVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxMaxRadiusVar();
        }

        private void trbMinRadius_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxMinRadius();
        }

        private void trbDegSec_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxDegSec();
        }

        private void trbDegSecVar_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxDegSecVar();
        }

        private void trbStartR_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartR();
        }

        private void trbStartG_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartG();
        }

        private void trbStartB_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartB();
        }

        private void trbStartA_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartA();
        }

        private void trbFinishR_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishR();
        }

        private void trbFinishG_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishG();
        }

        private void trbFinishB_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishB();
        }

        private void trbFinishA_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishA();
        }


        private void trbStartVarR_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartVarR();
        }

        private void trbStartVarG_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartVarG();
        }

        private void trbStartVarB_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartVarB();
        }

        private void trbStartVarA_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxStartVarA();
        }

        private void trbFinishVarR_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishVarR();
        }

        private void trbFinishVarG_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishVarG();
        }

        private void trbFinishVarB_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishVarB();
        }

        private void trbFinishVarA_ValueChanged(object sender, EventArgs e)
        {
            SetBarToBoxFinishVarA();
        }

        private void UC_ParticleControl_Load(object sender, EventArgs e)
        {
            //ControlInit();
        }

        private void cbSelectTexture_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTexture();
        }

        private void cbEmitter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEmitter();
        }

        private void cbTab05Source_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSource();
        }

        private void cbTab05Dest_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDest();
        }


        //TextBox 유효성검사
        #region

        string m_szOriData = string.Empty;
        private bool StringEffectivenessTest(ref string _szTest, ref float _fMaxData, int iSelect)
        {
            if (iSelect == 0)
            {
                int iCommaCount = 0;
                bool bResult = true;

                foreach (char cValue in _szTest)
                {
                    if (!(((48 <= cValue) && (57 >= cValue)) || (cValue == 46)))
                    {
                        return false;
                    }
                    else
                    {
                        if (cValue == 46)
                            iCommaCount++;

                        if (iCommaCount == 2)
                            return false;
                    }

                }

                switch (_szTest.Length)
                {
                    case 0:
                        bResult = false;
                        break;
                    case 1:
                        if (_szTest[0] == 46)
                            bResult = false;

                        break;
                    default:
                        if (((_szTest.Length >= 2) && (_szTest[0] == 48) && (_szTest[1] != 46)) || ((_szTest[0] == 48) && (_szTest[1] == 48)) || (_szTest[0] == 46))
                        {
                            bResult = false;
                        }

                        break;
                }

                if (bResult)
                {
                    double dConvert = Convert.ToDouble(_szTest);

                    if (dConvert > _fMaxData)
                    {
                        bResult = false;
                    }
                }

                return bResult;
            }
            else if (iSelect == 1)
            {
                int iCommaCount = 0;

                foreach (char cValue in _szTest)
                {
                    if (!(((48 <= cValue) && (57 >= cValue)) || (cValue == 46)))
                    {
                        return false;
                    }
                    else
                    {
                        if (cValue == 46)
                            iCommaCount++;

                        if (iCommaCount == 2)
                            return false;
                    }
                }

                return true;
            }

            return true;
        }

        private void tbR_MouseDown(object sender, MouseEventArgs e)
        {
            //m_szOriData = tbR.Text;
        }

        private void tbR_KeyDown(object sender, KeyEventArgs e)
        {
            //string szTest = tbR.Text.ToString();
            //bool bResult = true;
            //float fMaxData = trbR.Maximum * 0.1f;

            //if (e.KeyCode == Keys.Enter)
            //{
            //    bResult = true;

            //    bResult = StringEffectivenessTest(ref szTest, ref fMaxData, 0);

            //    if (bResult)
            //    {
            //        tbR.Text = string.Format("{0:F1}", (Convert.ToDouble(szTest)));
            //    }
            //    else
            //        tbR.Text = m_szOriData;
            //}
        }

        #endregion

        private void btnUpLoadTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PNG Files|*.png|JPG Files|*.jpg|BMP Files|*.bmp";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap normalBmp = new Bitmap(openFileDialog1.FileName);

                pbSample.Image = normalBmp;
                // Assign the cursor in the Stream to the Form's Cursor property.
                //this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

    }
}
