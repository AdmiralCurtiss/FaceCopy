using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceCopy
{
    public partial class FaceImageControl : Control
    {
        private FaceImage Face;

        public FaceImageControl(FaceImage Face)
        {
            this.Face = Face;
            InitializeComponent();

            SetBounds(0, 0, Face.Face.Width, Face.Face.Height);
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.DrawImage(Face.Face, 0, 0);
        }

        private void FaceImageControl_Click(object sender, EventArgs e)
        {
            try {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    // spawn menu to delete/modify

                }
                else
                {
                    // default behavior, copy URL to clipboard
                    Clipboard.SetText("[img]" + Face.URL + "[/img]");
                }
            } catch ( InvalidCastException ) {
                // was apparently not a mouse click!
            }
        }
    }
}
