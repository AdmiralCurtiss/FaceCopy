namespace FaceCopy
{
    partial class FaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonAddImage = new System.Windows.Forms.Button();
			this.buttonAddCategory = new System.Windows.Forms.Button();
			this.buttonReplaceInUpdate = new System.Windows.Forms.Button();
			this.buttonAddMultiUrl = new System.Windows.Forms.Button();
			this.checkBoxImgTags = new System.Windows.Forms.CheckBox();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(717, 296);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "All";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(13, 13);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(725, 322);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonOpen.Location = new System.Drawing.Point(17, 342);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(75, 23);
			this.buttonOpen.TabIndex = 1;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSave.Location = new System.Drawing.Point(98, 342);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 2;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonAddImage
			// 
			this.buttonAddImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddImage.Enabled = false;
			this.buttonAddImage.Location = new System.Drawing.Point(663, 342);
			this.buttonAddImage.Name = "buttonAddImage";
			this.buttonAddImage.Size = new System.Drawing.Size(75, 23);
			this.buttonAddImage.TabIndex = 3;
			this.buttonAddImage.Text = "Add Image";
			this.buttonAddImage.UseVisualStyleBackColor = true;
			this.buttonAddImage.Click += new System.EventHandler(this.buttonAddImage_Click);
			// 
			// buttonAddCategory
			// 
			this.buttonAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddCategory.Location = new System.Drawing.Point(577, 342);
			this.buttonAddCategory.Name = "buttonAddCategory";
			this.buttonAddCategory.Size = new System.Drawing.Size(80, 23);
			this.buttonAddCategory.TabIndex = 4;
			this.buttonAddCategory.Text = "Add Category";
			this.buttonAddCategory.UseVisualStyleBackColor = true;
			this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
			// 
			// buttonReplaceInUpdate
			// 
			this.buttonReplaceInUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonReplaceInUpdate.Location = new System.Drawing.Point(179, 342);
			this.buttonReplaceInUpdate.Name = "buttonReplaceInUpdate";
			this.buttonReplaceInUpdate.Size = new System.Drawing.Size(113, 23);
			this.buttonReplaceInUpdate.TabIndex = 5;
			this.buttonReplaceInUpdate.Text = "Replace in Update";
			this.buttonReplaceInUpdate.UseVisualStyleBackColor = true;
			this.buttonReplaceInUpdate.Click += new System.EventHandler(this.buttonReplaceInUpdate_Click);
			// 
			// buttonAddMultiUrl
			// 
			this.buttonAddMultiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddMultiUrl.Enabled = false;
			this.buttonAddMultiUrl.Location = new System.Drawing.Point(452, 342);
			this.buttonAddMultiUrl.Name = "buttonAddMultiUrl";
			this.buttonAddMultiUrl.Size = new System.Drawing.Size(119, 23);
			this.buttonAddMultiUrl.TabIndex = 6;
			this.buttonAddMultiUrl.Text = "Add Images from URL";
			this.buttonAddMultiUrl.UseVisualStyleBackColor = true;
			this.buttonAddMultiUrl.Click += new System.EventHandler(this.buttonAddMultiUrl_Click);
			// 
			// checkBoxImgTags
			// 
			this.checkBoxImgTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxImgTags.AutoSize = true;
			this.checkBoxImgTags.Checked = true;
			this.checkBoxImgTags.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxImgTags.Location = new System.Drawing.Point(398, 346);
			this.checkBoxImgTags.Name = "checkBoxImgTags";
			this.checkBoxImgTags.Size = new System.Drawing.Size(48, 17);
			this.checkBoxImgTags.TabIndex = 7;
			this.checkBoxImgTags.Text = "[img]";
			this.checkBoxImgTags.UseVisualStyleBackColor = true;
			// 
			// FaceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(750, 377);
			this.Controls.Add(this.checkBoxImgTags);
			this.Controls.Add(this.buttonAddMultiUrl);
			this.Controls.Add(this.buttonReplaceInUpdate);
			this.Controls.Add(this.buttonAddCategory);
			this.Controls.Add(this.buttonAddImage);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.tabControl1);
			this.Name = "FaceForm";
			this.Text = "FaceCopy v1.41";
			this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FaceForm_Scroll);
			this.MouseEnter += new System.EventHandler(this.FaceForm_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.FaceForm_MouseLeave);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.Button buttonReplaceInUpdate;
		private System.Windows.Forms.Button buttonAddMultiUrl;
		private System.Windows.Forms.CheckBox checkBoxImgTags;



    }
}