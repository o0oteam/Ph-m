public class DefineData
{
}

public enum UIName
{
	None = 0,
	Login = 1,
	Portal = 2,

	GameList = 20,
	RoomList = 21,
}

public class ButtonName
{
	#region Login Buttons

	public const string LOGIN_FB = "LoginFB";
	public const string LOGIN_GUEST = "LoginGuest";

	#endregion Login Buttons

	#region Enter Game Room Buttons

	public const string BACK_TO_GAME_LIST = "BackToGameList";

	public const string ENTER_GAME_ROOM_PHOM = "EnterRoomPhom";
	public const string ENTER_GAME_ROOM_POKER = "EnterRoomPoker";
	public const string ENTER_GAME_ROOM_TIENLEN = "EnterRoomTienLen";

	#endregion Enter Game Room Buttons
}

public class GameTime
{
}
