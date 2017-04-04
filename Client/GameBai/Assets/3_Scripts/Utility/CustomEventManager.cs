using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventManager : MonoBehaviour
{
	#region Fields

	public static Action<string> OnButtonClicked;
	public static Action<string, int> OnButtonWithIDClicked;

	#endregion Fields

	#region Init

	#endregion Init

	#region Helper Methods

	public static void ClickButton (string button_name)
	{
		Debug.Log ("Button " + button_name + " clicked!!");
		if (OnButtonClicked != null)
			OnButtonClicked (button_name);
	}

	public static void ClickButtonWithID (string button_name, int id)
	{
		Debug.Log ("Button " + button_name + " with ID:" + id + " clicked!!");
		if (OnButtonWithIDClicked != null)
			OnButtonWithIDClicked (button_name, id);
	}

	#endregion Helper Methods
}
