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
    public partial class FaceForm : Form
    {
        FaceXML XML;
        FaceControl AllFacesControl;
        Dictionary<String, FaceControl> FaceControls;

        public FaceForm()
        {
            InitializeComponent();

            XML = new FaceXML();
            AllFacesControl = new FaceControl(XML);
            FaceControls = new Dictionary<string, FaceControl>();
        }

        public FaceForm(FaceXML XML)
        {
            InitializeComponent();

            LoadXML(XML);
            this.Height++;
        }

        public void LoadXML(FaceXML XML)
        {
            this.XML = XML;

            this.tabControl1.Controls.Clear();
            this.tabPage1.Controls.Clear();
            this.tabControl1.Controls.Add(tabPage1);

            int width = tabPage1.Size.Width;
            int height = tabPage1.Size.Height;

            FaceControl f = new FaceControl(XML);
            f.Size = new Size(width, height);
            f.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.tabPage1.Controls.Add(f);

            AllFacesControl = f;
            FaceControls = new Dictionary<string, FaceControl>();

            foreach (KeyValuePair<String, List<FaceImage>> KVP in XML.Categories)
            {
                TabPage p = new TabPage(KVP.Key);
                p.Size = new Size(width, height);
                f = new FaceControl(KVP.Key, KVP.Value);
                f.Size = new Size(width, height);
                f.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                p.Controls.Add(f);
                this.tabControl1.Controls.Add(p);

                FaceControls.Add(KVP.Key, f);
            }
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1) return;

            OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "Images (*.png, *.jpg, *.gif)|*.png;*.jpg;*.jpeg;*.gif|All Files|*.*";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InputBoxResult r = InputBox.Show("URL:", "Image URL", "", null);
                if (r.OK)
                {
                    String CurrentCategory = tabControl1.SelectedTab.Text;
                    FaceImage Image = new FaceImage(CurrentCategory, r.Text, dialog.FileName);
                    AllFacesControl.SuspendLayout();
                    AllFacesControl.Add(Image);
                    AllFacesControl.ResumeLayout(true);
                    AllFacesControl.Refresh();
                    FaceControls[CurrentCategory].SuspendLayout();
                    FaceControls[CurrentCategory].Add(Image);
                    FaceControls[CurrentCategory].ResumeLayout(true);

                    this.Refresh();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "XML File (*.xml)|*.xml|Any File|*.*";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String sXML = XML.ToXML();
                System.IO.File.WriteAllText(dialog.FileName, sXML);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                this.buttonAddImage.Enabled = false;
            }
            else
            {
                this.buttonAddImage.Enabled = true;
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            InputBoxResult r = InputBox.Show("New category name:", "Add Category", "", null);
            if (r.OK && !String.IsNullOrEmpty(r.Text))
            {
                if (FaceControls.Keys.Contains(r.Text))
                {
                    return;
                }

                List<FaceImage> l = new List<FaceImage>();

                TabPage p = new TabPage(r.Text);
                p.Size = new Size(tabPage1.Size.Width, tabPage1.Size.Height);
                FaceControl f = new FaceControl(r.Text, l);
                f.Size = new Size(tabPage1.Size.Width, tabPage1.Size.Height);
                f.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                p.Controls.Add(f);
                this.tabControl1.Controls.Add(p);

                FaceControls.Add(r.Text, f);

                XML.AddCategory(r.Text, l);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "XML Files (*.xml)|*.xml|Any File|*.*";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.SuspendLayout();
                LoadXML(new FaceXML(dialog.FileName));
                this.buttonAddImage.Enabled = false;
                this.ResumeLayout(true);
            }
        }
    }
}
