using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex1
{
    public partial class Preview : Control
    {
        Emitter emitter = new Emitter(200);
        public Preview()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here
            Rectangle r = new Rectangle();
            r.X = 0;
            r.Width = Width;
            r.Y = 0;
            r.Height = Height;
            pe.Graphics.FillRectangle(Brushes.White, r);
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        protected override void WndProc(ref Message m)
        {
            emitter.Update();
            emitter.Render();
            base.WndProc(ref m);
        }

    }
}
