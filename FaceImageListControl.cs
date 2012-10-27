using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceCopy
{
    public partial class FaceImageListControl : UserControl
    {
        FaceXML XML;
        String Category;
        List<FaceImage> ImageList;

        // the control for the "all" category
        FaceImageListControl AllControl;
		FaceForm ParentFaceForm;

        public FaceImageListControl(String Category, List<FaceImage> ImageList, FaceImageListControl AllControl, FaceForm ParentForm)
        {
            InitializeComponent();

            this.Category = Category;
            this.ImageList = ImageList;
            this.XML = null;
            this.AllControl = AllControl;
            this.ParentFaceForm = ParentForm;
            FillViewFromList();
        }
        public FaceImageListControl(FaceXML XML, FaceForm ParentForm)
        {
            InitializeComponent();

            this.Category = null;
            this.ImageList = null;
            this.XML = XML;
            this.AllControl = null;
            this.ParentFaceForm = ParentForm;
            FillViewFromXML();
        }

		public FaceForm GetParentFaceForm() {
			return ParentFaceForm;
		}

        public void Add(FaceImage Face)
        {
            if (ImageList != null)
            {
                ImageList.Add(Face);
            }

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Add(new FaceImageControl(Face, this));
            flowLayoutPanel1.ResumeLayout(true);
            flowLayoutPanel1.Refresh();
        }


        public void FillViewFromList()
        {
            this.flowLayoutPanel1.SuspendLayout();

            foreach (FaceImage f in ImageList)
            {
                flowLayoutPanel1.Controls.Add(new FaceImageControl(f, this));
            }

            this.flowLayoutPanel1.ResumeLayout(false);
        }

        public void FillViewFromXML()
        {
            this.flowLayoutPanel1.SuspendLayout();

            foreach (List<FaceImage> l in XML.Categories.Values)
            {
                foreach (FaceImage f in l)
                {
                    flowLayoutPanel1.Controls.Add(new FaceImageControl(f, this));
                }
            }

            this.flowLayoutPanel1.ResumeLayout(false);
        }

        public void Remove(FaceImageControl faceImageControl, bool AllowRecursiveRemove)
        {
            flowLayoutPanel1.SuspendLayout();

            // no idew how this internally compares stuff, apparently not with Equals() which is fucking dumb but oh well
            //flowLayoutPanel1.Controls.Remove(faceImageControl);
            // let's do this manually then... *sigh*
            foreach (FaceImageControl c in flowLayoutPanel1.Controls)
            {
                if (c.Face == faceImageControl.Face)
                {
                    flowLayoutPanel1.Controls.Remove(c);
                }
            }


            if (XML != null)
            {
                // is the "all" control
                XML.Remove(faceImageControl.Face.Category, faceImageControl.Face);
                if (AllowRecursiveRemove)
                {
                    // delete from category it belongs to as well
                    ParentFaceForm.FaceControls[faceImageControl.Face.Category].Remove(faceImageControl, false);
                }
            }
            else
            {
                // is a category
                ImageList.Remove(faceImageControl.Face);
                if (AllowRecursiveRemove)
                {
                    // delete from all control as well
                    AllControl.Remove(faceImageControl, false);
                }
            }
            flowLayoutPanel1.ResumeLayout(true);
            flowLayoutPanel1.Refresh();
        }


    }
}
