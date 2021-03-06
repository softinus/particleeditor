﻿namespace ParticleEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAbout = new System.Windows.Forms.Label();
            this.pnTopBox = new System.Windows.Forms.Panel();
            this.lbClose = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.pnMain.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.pnTopBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.AutoSize = true;
            this.pnMain.Controls.Add(this.pnCenter);
            this.pnMain.Controls.Add(this.pnTop);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(2, 2);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(3);
            this.pnMain.Size = new System.Drawing.Size(682, 754);
            this.pnMain.TabIndex = 1;
            // 
            // pnCenter
            // 
            this.pnCenter.BackColor = System.Drawing.SystemColors.Control;
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(3, 33);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(676, 718);
            this.pnCenter.TabIndex = 3;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnTop.BackgroundImage = global::ParticleEditor.Properties.Resources.img_windowbar1;
            this.pnTop.Controls.Add(this.label1);
            this.pnTop.Controls.Add(this.lbAbout);
            this.pnTop.Controls.Add(this.pnTopBox);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnTop.Size = new System.Drawing.Size(676, 30);
            this.pnTop.TabIndex = 0;
            this.pnTop.DoubleClick += new System.EventHandler(this.pnTop_DoubleClick);
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            this.pnTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseMove);
            this.pnTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "ParticleEditor";
            // 
            // lbAbout
            // 
            this.lbAbout.BackColor = System.Drawing.Color.Transparent;
            this.lbAbout.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbAbout.Image = global::ParticleEditor.Properties.Resources.img_About_nor;
            this.lbAbout.Location = new System.Drawing.Point(528, 5);
            this.lbAbout.Name = "lbAbout";
            this.lbAbout.Size = new System.Drawing.Size(86, 20);
            this.lbAbout.TabIndex = 11;
            this.lbAbout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbAbout_MouseClick);
            this.lbAbout.MouseLeave += new System.EventHandler(this.lbAbout_MouseLeave);
            this.lbAbout.MouseHover += new System.EventHandler(this.lbAbout_MouseHover);
            this.lbAbout.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbAbout_MouseMove);
            // 
            // pnTopBox
            // 
            this.pnTopBox.Controls.Add(this.lbClose);
            this.pnTopBox.Controls.Add(this.lbMax);
            this.pnTopBox.Controls.Add(this.lbMin);
            this.pnTopBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnTopBox.Location = new System.Drawing.Point(614, 5);
            this.pnTopBox.Name = "pnTopBox";
            this.pnTopBox.Size = new System.Drawing.Size(57, 20);
            this.pnTopBox.TabIndex = 10;
            // 
            // lbClose
            // 
            this.lbClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbClose.Image = global::ParticleEditor.Properties.Resources.img_close_nor;
            this.lbClose.Location = new System.Drawing.Point(38, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(19, 20);
            this.lbClose.TabIndex = 11;
            this.lbClose.MouseLeave += new System.EventHandler(this.lbClose_MouseLeave);
            this.lbClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbClose_MouseMove);
            this.lbClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbClose_MouseUp);
            // 
            // lbMax
            // 
            this.lbMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMax.Image = global::ParticleEditor.Properties.Resources.img_maximize_nor;
            this.lbMax.Location = new System.Drawing.Point(19, 0);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(19, 20);
            this.lbMax.TabIndex = 10;
            this.lbMax.MouseLeave += new System.EventHandler(this.lbMax_MouseLeave);
            this.lbMax.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbMax_MouseMove);
            this.lbMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbMax_MouseUp);
            // 
            // lbMin
            // 
            this.lbMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMin.Image = global::ParticleEditor.Properties.Resources.img_minimize_nor;
            this.lbMin.Location = new System.Drawing.Point(0, 0);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(19, 20);
            this.lbMin.TabIndex = 9;
            this.lbMin.MouseLeave += new System.EventHandler(this.lbMin_MouseLeave);
            this.lbMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbMin_MouseMove);
            this.lbMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbMin_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(686, 758);
            this.Controls.Add(this.pnMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(686, 758);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Main_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.pnMain.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.pnTopBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnCenter;
        private System.Windows.Forms.Panel pnTopBox;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbAbout;
        private System.Windows.Forms.Label label1;
    }
}

