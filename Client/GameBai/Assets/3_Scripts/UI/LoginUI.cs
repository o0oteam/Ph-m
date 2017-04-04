using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUI : UIComponent
{
	#region Fields

	#endregion Fields

	#region Init

	#endregion Init

	#region Helper Methods

	public override void HandleButtonClicked (string button_name)
	{
		switch (button_name) {
		case ButtonName.LOGIN_FB:
			OnButtonLoginFBClicked ();
			break;

		case ButtonName.LOGIN_GUEST:
			OnButtonLoginGuestClicked ();
			break;

		default:
			break;

		}
	}

	void OnButtonLoginFBClicked ()
	{
		//TODO Log in FB
		UIManagerComponent.Instance.ChangUIByName (UIName.Portal);
	}

	void OnButtonLoginGuestClicked ()
	{
		//TODO Log in Guest
		UIManagerComponent.Instance.ChangUIByName (UIName.Portal);
	}

	#endregion Helper Methods

	#region Facebook Methods

	#endregion Facebook Methods
}
