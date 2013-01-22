using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceCopy {
	public class CustomFlowLayoutPanel : System.Windows.Forms.FlowLayoutPanel {
		protected override System.Drawing.Point ScrollToControl( System.Windows.Forms.Control activeControl ) {
			// Returning the current location prevents the panel from
			// scrolling to the active control when the panel loses and regains focus
			return this.DisplayRectangle.Location;
		}
	}

}
