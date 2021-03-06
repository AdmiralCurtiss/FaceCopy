﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceCopy {
	public partial class FaceForm : Form {
		public FaceXML XML;
		public FaceImageListControl AllFacesControl;
		public Dictionary<String, FaceImageListControl> FaceControls;

		public bool IsImgTagChecked {
			get { return checkBoxImgTags.Checked; }
		}
		public bool IsSelectedCategoryAllCategory {
			get { return tabControl1.SelectedTab == tabPage1 || tabControl1.SelectedTab == null; }
		}

		public FaceForm() {
			InitializeComponent();
			Initialize( new FaceXML() );
		}

		public FaceForm( FaceXML XML ) {
			InitializeComponent();
			Initialize( XML );
		}

		public void Initialize( FaceXML XML ) {
			LoadXML( XML );
			this.Height++;
			AllFacesControl.Focus();
		}

		public void LoadXML( FaceXML XML ) {
			this.XML = XML;

			this.tabControl1.Controls.Clear();
			this.tabPage1.Controls.Clear();
			this.tabControl1.Controls.Add( tabPage1 );

			int width = tabPage1.Size.Width;
			int height = tabPage1.Size.Height;

			FaceImageListControl f = new FaceImageListControl( XML, this );
			f.Size = new Size( width, height );
			f.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.tabPage1.Controls.Add( f );

			AllFacesControl = f;
			FaceControls = new Dictionary<string, FaceImageListControl>();

			foreach ( KeyValuePair<String, List<FaceImage>> KVP in XML.Categories ) {
				TabPage p = new TabPage( KVP.Key );
				p.Size = new Size( width, height );
				f = new FaceImageListControl( KVP.Key, KVP.Value, AllFacesControl, this );
				f.Size = new Size( width, height );
				f.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				p.Controls.Add( f );
				this.tabControl1.Controls.Add( p );

				FaceControls.Add( KVP.Key, f );
			}
		}

		private void buttonAddImage_Click( object sender, EventArgs e ) {
			if ( tabControl1.SelectedTab == tabPage1 ) return;

			OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
			dialog.Filter = "Images (*.png, *.jpg, *.gif)|*.png;*.jpg;*.jpeg;*.gif|All Files|*.*";
			DialogResult result = dialog.ShowDialog();
			if ( result == DialogResult.OK ) {
				InputBoxResult r = InputBox.Show( "URL:", "Image URL", "", null, false );
				if ( r.OK ) {
					String CurrentCategory = tabControl1.SelectedTab.Text;
					FaceImage Image = new FaceImage( CurrentCategory, r.Text, dialog.FileName, "" );
					AllFacesControl.SuspendLayout();
					AllFacesControl.Add( Image );
					AllFacesControl.ResumeLayout( true );
					AllFacesControl.Refresh();
					FaceControls[CurrentCategory].SuspendLayout();
					FaceControls[CurrentCategory].Add( Image );
					FaceControls[CurrentCategory].ResumeLayout( true );
					FaceControls[CurrentCategory].Refresh();

					this.Refresh();
				}
			}
		}

		private void buttonSave_Click( object sender, EventArgs e ) {
			SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
			dialog.Filter = "XML File (*.xml)|*.xml|Any File|*.*";
			DialogResult result = dialog.ShowDialog();
			if ( result == DialogResult.OK ) {
				String sXML = XML.ToXML();
				System.IO.File.WriteAllText( dialog.FileName, sXML );
			}
		}

		private void tabControl1_SelectedIndexChanged( object sender, EventArgs e ) {
			if ( tabControl1.SelectedTab == tabPage1 || tabControl1.SelectedTab == null ) {
				// All category
				this.buttonAddImage.Enabled = false;
				this.buttonAddMultiUrl.Enabled = false;
				AllFacesControl.Refresh();
				AllFacesControl.Focus();
			} else {
				// any category
				this.buttonAddImage.Enabled = true;
				this.buttonAddMultiUrl.Enabled = true;
				FaceControls[tabControl1.SelectedTab.Text].Refresh();
				FaceControls[tabControl1.SelectedTab.Text].Focus();
			}
		}

		private void buttonAddCategory_Click( object sender, EventArgs e ) {
			InputBoxResult r = InputBox.Show( "New category name:", "Add Category", "", null, false );
			if ( r.OK && !String.IsNullOrEmpty( r.Text ) ) {
				if ( FaceControls.Keys.Contains( r.Text ) ) {
					return;
				}

				List<FaceImage> l = new List<FaceImage>();

				TabPage p = new TabPage( r.Text );
				p.Size = new Size( tabPage1.Size.Width, tabPage1.Size.Height );
				FaceImageListControl f = new FaceImageListControl( r.Text, l, AllFacesControl, this );
				f.Size = new Size( tabPage1.Size.Width, tabPage1.Size.Height );
				f.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				p.Controls.Add( f );
				this.tabControl1.Controls.Add( p );

				FaceControls.Add( r.Text, f );

				XML.AddCategory( r.Text, l );
			}
		}

		private void buttonOpen_Click( object sender, EventArgs e ) {
			OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
			dialog.Filter = "XML Files (*.xml)|*.xml|Any File|*.*";
			DialogResult result = dialog.ShowDialog();
			if ( result == DialogResult.OK ) {
				this.SuspendLayout();
				LoadXML( new FaceXML( dialog.FileName ) );
				this.buttonAddImage.Enabled = false;
				this.ResumeLayout( true );
			}
		}

		private void buttonReplaceInUpdate_Click( object sender, EventArgs e ) {
			OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
			dialog.Filter = "Text file (*.txt)|*.txt|Any File|*.*";
			DialogResult result = dialog.ShowDialog();
			if ( result == DialogResult.OK ) {
				this.XML.ReplaceInUpdate( dialog.FileName );
			}
		}

		private void buttonAddMultiUrl_Click( object sender, EventArgs e ) {
			if ( tabControl1.SelectedTab == tabPage1 ) return;

			InputBoxResult r = InputBox.Show( "Copy-paste URL list from Rightload:", "Image URLs", "", null, true );
			if ( r.OK ) {
				String CurrentCategory = tabControl1.SelectedTab.Text;

				AllFacesControl.SuspendLayout();
				FaceControls[CurrentCategory].SuspendLayout();
				foreach ( string url in r.Text.Split( new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries ) ) {
					FaceImage Image = new FaceImage( CurrentCategory, url, "", "" );
					AllFacesControl.Add( Image );
					FaceControls[CurrentCategory].Add( Image );
				}
				AllFacesControl.ResumeLayout( true );
				AllFacesControl.Refresh();
				FaceControls[CurrentCategory].ResumeLayout( true );
				FaceControls[CurrentCategory].Refresh();

				this.Refresh();
			}

		}

		private void FaceForm_Scroll( object sender, ScrollEventArgs e ) {
		}

		private void FaceForm_MouseEnter( object sender, EventArgs e ) {
			if ( IsSelectedCategoryAllCategory ) {
				if ( !AllFacesControl.Focused ) {
					AllFacesControl.Focus();
				}
			} else {
				if ( !FaceControls[tabControl1.SelectedTab.Text].Focused ) {
					FaceControls[tabControl1.SelectedTab.Text].Focus();
				}
			}
		}

		private void FaceForm_MouseLeave( object sender, EventArgs e ) {
		}

		private void tabControl1_MouseClick( object sender, MouseEventArgs e ) {
			try {
				MouseEventArgs me = (MouseEventArgs)e;
				if ( !IsSelectedCategoryAllCategory && me.Button == MouseButtons.Right ) {
					MenuItem mi;
					mi = new MenuItem( "Delete Category: " + tabControl1.SelectedTab.Text );
					mi.Click += new EventHandler( mi_Delete_Click );

					var TabRightClickMenu = new System.Windows.Forms.ContextMenu( new MenuItem[] { mi } );
					TabRightClickMenu.GetContextMenu().Show( this, new Point( me.X + tabControl1.Location.X, me.Y + tabControl1.Location.Y ) );
				}
			} catch ( InvalidCastException ) {
				// was apparently not a mouse click!
			}
		}

		void mi_Delete_Click( object sender, EventArgs e ) {
			string categoryName = tabControl1.SelectedTab.Text;

			FaceImageListControl fc = FaceControls[categoryName];
			fc.RemoveAllImages( true );
			XML.RemoveCategory( categoryName );

			TabPage tabToRemove = tabControl1.SelectedTab;
			tabControl1.DeselectTab( tabToRemove );
			tabControl1.Controls.Remove( tabToRemove );
		}
	}
}
