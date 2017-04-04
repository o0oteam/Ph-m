using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUIManager : UIManagerComponent
{
	#region Fields

	public static PortalUIManager InstancePortalUI;

	#endregion Fields

	#region Init

	public override void Awake ()
	{
		InstancePortalUI = GetComponent<PortalUIManager> ();
		_CurrentUI = UIName.GameList;
	}

	#endregion Init
}
