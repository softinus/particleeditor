namespace ParticleEditor
{
    partial class UC_ParticleMain
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnView = new System.Windows.Forms.Panel();
            this.pnControl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnView
            // 
            this.pnView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnView.Location = new System.Drawing.Point(0, 0);
            this.pnView.Name = "pnView";
            this.pnView.Size = new System.Drawing.Size(179, 534);
            this.pnView.TabIndex = 3;
            // 
            // pnControl
            // 
            this.pnControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnControl.Location = new System.Drawing.Point(179, 0);
            this.pnControl.Name = "pnControl";
            this.pnControl.Size = new System.Drawing.Size(261, 534);
            this.pnControl.TabIndex = 2;
            // 
            // UC_ParticleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnView);
            this.Controls.Add(this.pnControl);
            this.Name = "UC_ParticleMain";
            this.Size = new System.Drawing.Size(440, 534);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnView;
        private System.Windows.Forms.Panel pnControl;

    }
}
