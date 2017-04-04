using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : UIManagerComponent {
	#region Fields
	public static MainUIManager InstanceMainUI;
	#endregion Fields

	#region Init

	public override void Awake ()
	{
		InstanceMainUI = GetComponent<MainUIManager> ();
		//		_CurrentUI = UIName.Login;
	}

	#endregion Init

	#region Helper Methods
	#endregion Helper Methods
}
