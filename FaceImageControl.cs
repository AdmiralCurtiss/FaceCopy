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
        public FaceImage Face;
        private ContextMenu RightClickMenu;
        private MenuItem[] RightClickMenuItems;
        private FaceImageListControl FaceControlParent;

        public FaceImageControl(FaceImage Face, FaceImageListControl FaceControlParent)
        {
            this.Face = Face;
            this.FaceControlParent = FaceControlParent;
            InitializeComponent();

            SetBounds(0, 0, Face.Face.Width, Face.Face.Height);

            List<MenuItem> menuitems = new List<MenuItem>();

            MenuItem mi;
            mi = new MenuItem("Edit URL");
            mi.Click += new EventHandler(mi_EditURL_Click);
            menuitems.Add(mi);

            mi = new MenuItem("Edit Name");
            mi.Click += new EventHandler(mi_EditName_Click);
            menuitems.Add(mi);

            mi = new MenuItem("Delete");
            mi.Click += new EventHandler(mi_Delete_Click);
            menuitems.Add(mi);


            RightClickMenuItems = menuitems.ToArray();
            RightClickMenu = new System.Windows.Forms.ContextMenu(RightClickMenuItems);
        }

        void mi_EditURL_Click(object sender, EventArgs e)
        {
            InputBoxResult r = InputBox.Show("URL:", "Image URL", this.Face.URL, null, false);
            if (r.OK)
            {
                this.Face.URL = r.Text;
            }
        }
        void mi_EditName_Click(object sender, EventArgs e)
        {
			InputBoxResult r = InputBox.Show( "Name:", "Image Name", this.Face.Name, null, false );
            if (r.OK)
            {
                this.Face.Name = r.Text;
            }
        }

        void mi_Delete_Click(object sender, EventArgs e)
        {
            FaceControlParent.Remove(this, true);
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
                    RightClickMenu.GetContextMenu().Show(this, new Point(me.X, me.Y));
                }
                else
                {
                    // default behavior, copy URL to clipboard
					if ( FaceControlParent.GetParentFaceForm().IsImgTagChecked ) {
						Clipboard.SetText( "[img]" + Face.URL + "[/img]" );
					} else {
						Clipboard.SetText( Face.URL );
					}
                }
            } catch ( InvalidCastException ) {
                // was apparently not a mouse click!
            }
        }

        public override bool Equals(object obj)
        {
            try
            {
                FaceImageControl fic = (FaceImageControl)obj;
                bool equal = this.Face == fic.Face;
                return equal;
            }
            catch (InvalidCastException)
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return this.Face.GetHashCode();
        }
    }
}
