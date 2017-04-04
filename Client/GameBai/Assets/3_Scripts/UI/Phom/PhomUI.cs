using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhomUI : UIComponent {
	#region Fields
	#endregion Fields

	#region Init
	#endregion Init

	#region Helper Methods
	public override void HandleButtonClicked (string button_name)
	{
		switch (button_name) {
		case ButtonName.BACK_TO_PORTAL:
			OnButtonBackToPortalClicked ();
			break;

		default:
			break;

		}
	}

	void OnButtonBackToPortalClicked()
	{
		MainUIManager.InstanceMainUI.ChangUIByName (UIName.Portal);
	}

	#endregion Helper Methods
}
