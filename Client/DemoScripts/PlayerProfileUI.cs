using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class PlayerProfileUI : UIDialog
{
	
	#region Fields

	public static PlayerProfileUI Instance;

	[Header ("Profile")]
	public Texture DefaultTexture;
	public RawImage RImg_Avatar;
	public Text Text_Username;
	public Text Text_Level;
	public Text Text_Exp;
	public Image Img_ExpFill;

	[Header ("Squad")]
	public Image Img_SquadIcon;
	public Text Text_SquadName;
	public Text Text_NoneSquad;

	[Header ("Performance")]
	public Text Text_Match;
	public Text Text_Win;
	public Text Text_Killstreak;
	public Text Text_Kill;
	public Text Text_Death;
	public Text Text_Assist;

	[Header ("Rank")]
	public RankItemUI CurrentRank;
	public RankItemUI PreviousRank;
	public RankItemUI BestRank;

	[Header ("Most Played Character")]
	public List<MostPlayUI> ListMostPlay;

	#endregion Fields

	#region Init

	void Awake ()
	{
		Instance = GetComponent<PlayerProfileUI> ();
	}

	#endregion Init

	#region Helper Methods

	public void SetPlayerInfo ()
	{
		GetAvatarFromFB ();
		Text_Username.text = SGPlayersManager.Instance.PlayerMe.Nickname;

		int level = SGPlayersManager.Instance.PlayerMe.Property.Level;
		Text_Level.text = "" + level;

		int maxExp = SGConfigManager.configLevel.GetLevelInfo (level).expRequired;
		int exp = SGPlayersManager.Instance.PlayerMe.Property.Exp;
		Text_Exp.text = exp + "/" + maxExp;
		Img_ExpFill.fillAmount = exp * 1.0f / maxExp;
	}

	public void SetSquadInfo (Sprite icon, string squadname)
	{
		Text_NoneSquad.gameObject.SetActive (squadname == "");
		Text_SquadName.gameObject.SetActive (squadname != "");

		if (squadname != "") {
			Img_SquadIcon.sprite = icon;
			Text_SquadName.text = squadname;
		}
	}

	public void SetPerformance (string match, string win_count, string killstreak, string kill, string death, string assist)
	{
		Text_Match.text = match;
		Text_Win.text = win_count;
		Text_Killstreak.text = killstreak;
		Text_Kill.text = kill;
		Text_Death.text = death;
		Text_Assist.text = assist;
	}

	public void GetAvatarFromFB ()
	{
		if (!FB.IsInitialized)
			FB.Init (this.InitCallBack);
		else
			InitCallBack ();
	}

	public void InitCallBack ()
	{
		if (DefaultTexture != null)
			FB.API ("/me/picture?redirect=false&type=large", HttpMethod.GET, ProfilePhotoCallback);
		else
			RImg_Avatar.texture = DefaultTexture;
	}

	public void ProfilePhotoCallback (IGraphResult result)
	{
		if (string.IsNullOrEmpty (result.Error) && !result.Cancelled) {
			IDictionary data = result.ResultDictionary ["data"] as IDictionary;
			string photoURL = data ["url"] as string;
			StartCoroutine (GetTextureFromLink (photoURL));
		} else
			Debug.Log (result.Error);
	}

	IEnumerator GetTextureFromLink (string url)
	{
		WWW w = new WWW (url);
		yield return w;
		RImg_Avatar.texture = w.texture;
		DefaultTexture = w.texture;
	}

	#endregion Helper Methods
}
