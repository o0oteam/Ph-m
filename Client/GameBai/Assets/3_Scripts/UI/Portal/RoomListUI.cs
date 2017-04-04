using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListUI : UIComponent {
	#region Fields
	public RoomItemUI RoomItemPrefab;
	public GameObject RoomItemContent;
	public int RoomCount = 12;
	public List<RoomItemUI> ListRoomItem;
	#endregion Fields

	#region Init
	void Awake()
	{
		ClearRoom ();

		for (int i = 0; i < RoomCount; i++) {
			RoomItemUI RI = CreateNewRoomItem ();
			RI.transform.SetParent (RoomItemContent.transform);
			RI.gameObject.SetActive (true);
		}
	}
	#endregion Init

	#region Helper Methods

	public RoomItemUI CreateNewRoomItem()
	{
		for (int i = 0; i < ListRoomItem.Count; i++) {
			if (!ListRoomItem [i].gameObject.activeInHierarchy)
				return ListRoomItem [i];
		}

		RoomItemUI RI = CustomUtility.CustomInstantiate (RoomItemPrefab.gameObject).GetComponent<RoomItemUI> ();
		RI.RoomID = ListRoomItem.Count + 1;
		RI.SetRoomInfo ("Room " + RI.RoomID, "0", "4");
		ListRoomItem.Add (RI);

		return RI;
	}

	public void ClearRoom()
	{
		for (int i = 0; i < ListRoomItem.Count; i++)
			if(ListRoomItem[i] != null)
				Destroy (ListRoomItem[i].gameObject);
		ListRoomItem.Clear ();
	}

	#endregion Helper Methods
}
