using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUI : UIComponent
{
	#region Fields

	#endregion Fields

	#region Init

	#endregion Init

	#region Helper Methods

	public override void HandleButtonClicked (string button_name)
	{
		switch (button_name) {
		case ButtonName.BACK_TO_GAME_LIST:
			OnButtonBackToGameListClicked ();
			break;

		case ButtonName.ENTER_GAME_ROOM_PHOM:
			OnButtonEnterGameRoomPhomClicked ();
			break;

		default:
			break;

		}
	}

	void OnButtonEnterGameRoomPhomClicked ()
	{
		//TODO load Room Phom info
		PortalUIManager.InstancePortalUI.ChangUIByName (UIName.RoomList);
	}

	void OnButtonEnterGameRoomPokerClicked ()
	{
		//TODO load Room Poker info
		PortalUIManager.InstancePortalUI.ChangUIByName (UIName.RoomList);
	}

	void OnButtonEnterGameRoomTienLenClicked ()
	{
		//TODO load Room Tien Len info
		PortalUIManager.InstancePortalUI.ChangUIByName (UIName.RoomList);
	}

	void OnButtonBackToGameListClicked ()
	{
		PortalUIManager.InstancePortalUI.ChangUIByName (UIName.GameList);
	}

	#endregion Helper Methods
}
