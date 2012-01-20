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
    public partial class FaceControl : UserControl
    {
        FaceXML XML;
        String Category;
        List<FaceImage> ImageList;

        public FaceControl(String Category, List<FaceImage> ImageList)
        {
            InitializeComponent();

            this.Category = Category;
            this.ImageList = ImageList;
            this.XML = null;
            FillViewFromList();
        }
        public FaceControl(FaceXML XML)
        {
            InitializeComponent();

            this.Category = null;
            this.ImageList = null;
            this.XML = XML;
            FillViewFromXML();
        }

        public void Add(FaceImage Face)
        {
            if (ImageList != null)
            {
                ImageList.Add(Face);
            }

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Add(new FaceImageControl(Face));
            flowLayoutPanel1.ResumeLayout(true);
            flowLayoutPanel1.Refresh();
        }


        public void FillViewFromList()
        {
            this.flowLayoutPanel1.SuspendLayout();

            foreach (FaceImage f in ImageList)
            {
                flowLayoutPanel1.Controls.Add(new FaceImageControl(f));
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
                    flowLayoutPanel1.Controls.Add(new FaceImageControl(f));
                }
            }

            this.flowLayoutPanel1.ResumeLayout(false);
        }
    }
}
