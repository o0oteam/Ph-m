using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemUI : MonoBehaviour {

	#region Fields
	public int RoomID;
	public Text Text_RoomName;
	public Text Text_User;

	#endregion Fields

	#region Helper Methods
	public void OnItemClick()
	{
		CustomEventManager.OnButtonWithIDClicked (ButtonName.ENTER_GAME_PHOM, RoomID);

		//~~~~~
		MainUIManager.InstanceMainUI.ChangUIByName(UIName.Phom);
	}

	public void SetRoomInfo(string room_name, string current_user, string max_user)
	{
		Text_RoomName.text = room_name;
		Text_User.text = current_user + "/" + max_user;
	}

	#endregion Helper Methods
}
