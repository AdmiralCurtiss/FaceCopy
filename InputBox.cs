using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FaceCopy {
	/// <summary>
	/// The InputBox class is used to show a prompt in a dialog box using the static method Show().
	/// </summary>
	public class InputBox : System.Windows.Forms.Form {
		protected System.Windows.Forms.Button buttonOK;
		protected System.Windows.Forms.Button buttonCancel;
		protected System.Windows.Forms.Label labelPrompt;
		protected System.Windows.Forms.TextBox textBoxText;
		protected System.Windows.Forms.ErrorProvider errorProviderText;
		private IContainer components;

		/// <summary>
		/// Delegate used to validate the object
		/// </summary>
		private InputBoxValidatingHandler _validator;

		private InputBox() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if ( disposing ) {
				if ( components != null ) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxText = new System.Windows.Forms.TextBox();
			this.labelPrompt = new System.Windows.Forms.Label();
			this.errorProviderText = new System.Windows.Forms.ErrorProvider( this.components );
			( (System.ComponentModel.ISupportInitialize)( this.errorProviderText ) ).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point( 284, 67 );
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size( 75, 23 );
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.buttonCancel.CausesValidation = false;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point( 372, 67 );
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler( this.buttonCancel_Click );
			// 
			// textBoxText
			// 
			this.textBoxText.Location = new System.Drawing.Point( 16, 32 );
			this.textBoxText.Name = "textBoxText";
			this.textBoxText.Size = new System.Drawing.Size( 416, 20 );
			this.textBoxText.TabIndex = 1;
			this.textBoxText.TextChanged += new System.EventHandler( this.textBoxText_TextChanged );
			this.textBoxText.Validating += new System.ComponentModel.CancelEventHandler( this.textBoxText_Validating );
			// 
			// labelPrompt
			// 
			this.labelPrompt.AutoSize = true;
			this.labelPrompt.Location = new System.Drawing.Point( 15, 15 );
			this.labelPrompt.Name = "labelPrompt";
			this.labelPrompt.Size = new System.Drawing.Size( 39, 13 );
			this.labelPrompt.TabIndex = 0;
			this.labelPrompt.Text = "prompt";
			// 
			// errorProviderText
			// 
			this.errorProviderText.ContainerControl = this;
			this.errorProviderText.DataMember = "";
			// 
			// InputBox
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size( 460, 99 );
			this.Controls.Add( this.labelPrompt );
			this.Controls.Add( this.textBoxText );
			this.Controls.Add( this.buttonCancel );
			this.Controls.Add( this.buttonOK );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputBox";
			this.Text = "Title";
			( (System.ComponentModel.ISupportInitialize)( this.errorProviderText ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}
		#endregion

		private void buttonCancel_Click( object sender, System.EventArgs e ) {
			this.Validator = null;
			this.Close();
		}

		private void buttonOK_Click( object sender, System.EventArgs e ) {
			this.Close();
		}

		/// <summary>
		/// Displays a prompt in a dialog box, waits for the user to input text or click a button.
		/// </summary>
		/// <param name="prompt">String expression displayed as the message in the dialog box</param>
		/// <param name="title">String expression displayed in the title bar of the dialog box</param>
		/// <param name="defaultResponse">String expression displayed in the text box as the default response</param>
		/// <param name="validator">Delegate used to validate the text</param>
		/// <param name="xpos">Numeric expression that specifies the distance of the left edge of the dialog box from the left edge of the screen.</param>
		/// <param name="ypos">Numeric expression that specifies the distance of the upper edge of the dialog box from the top of the screen</param>
		/// <returns>An InputBoxResult object with the Text and the OK property set to true when OK was clicked.</returns>
		public static InputBoxResult Show( string prompt, string title, string defaultResponse, InputBoxValidatingHandler validator, int xpos, int ypos, bool multiline ) {
			using ( InputBox form = new InputBox() ) {
				if ( multiline ) {
					form.textBoxText.Multiline = true;
					form.textBoxText.Height += 300;
					form.Height += 300;
				}

				form.labelPrompt.Text = prompt;
				form.Text = title;
				form.textBoxText.Text = defaultResponse;
				if ( xpos >= 0 && ypos >= 0 ) {
					form.StartPosition = FormStartPosition.Manual;
					form.Left = xpos;
					form.Top = ypos;
				}
				form.Validator = validator;

				DialogResult result = form.ShowDialog();

				InputBoxResult retval = new InputBoxResult();
				if ( result == DialogResult.OK ) {
					retval.Text = form.textBoxText.Text;
					retval.OK = true;
				}
				return retval;
			}
		}

		/// <summary>
		/// Displays a prompt in a dialog box, waits for the user to input text or click a button.
		/// </summary>
		/// <param name="prompt">String expression displayed as the message in the dialog box</param>
		/// <param name="title">String expression displayed in the title bar of the dialog box</param>
		/// <param name="defaultResponse">String expression displayed in the text box as the default response</param>
		/// <param name="validator">Delegate used to validate the text</param>
		/// <returns>An InputBoxResult object with the Text and the OK property set to true when OK was clicked.</returns>
		public static InputBoxResult Show( string prompt, string title, string defaultText, InputBoxValidatingHandler validator, bool multiline ) {
			return Show( prompt, title, defaultText, validator, -1, -1, multiline );
		}


		/// <summary>
		/// Reset the ErrorProvider
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBoxText_TextChanged( object sender, System.EventArgs e ) {
			errorProviderText.SetError( textBoxText, "" );
		}

		/// <summary>
		/// Validate the Text using the Validator
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBoxText_Validating( object sender, System.ComponentModel.CancelEventArgs e ) {
			if ( Validator != null ) {
				InputBoxValidatingArgs args = new InputBoxValidatingArgs();
				args.Text = textBoxText.Text;
				Validator( this, args );
				if ( args.Cancel ) {
					e.Cancel = true;
					errorProviderText.SetError( textBoxText, args.Message );
				}
			}
		}

		protected InputBoxValidatingHandler Validator {
			get {
				return ( this._validator );
			}
			set {
				this._validator = value;
			}
		}
	}

	/// <summary>
	/// Class used to store the result of an InputBox.Show message.
	/// </summary>
	public class InputBoxResult {
		public bool OK;
		public string Text;
	}

	/// <summary>
	/// EventArgs used to Validate an InputBox
	/// </summary>
	public class InputBoxValidatingArgs : EventArgs {
		public string Text;
		public string Message;
		public bool Cancel;
	}

	/// <summary>
	/// Delegate used to Validate an InputBox
	/// </summary>
	public delegate void InputBoxValidatingHandler( object sender, InputBoxValidatingArgs e );

}