using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//
//using Sfs2X;
//using Sfs2X.Logging;
//using Sfs2X.Util;
//using Sfs2X.Entities;
//using Sfs2X.Entities.Data;
//using Sfs2X.Core;
//using Sfs2X.Requests;
//
//using Facebook.Unity;
//
public class LoginUIController : MonoBehaviour {}
//
//	enum TypeLogin{
//		GUESS,
//		FACEBOOK,
//		USERNAME,
//	}
//	TypeLogin currentTypeLogin = TypeLogin.GUESS;
//
//	public GameObject mode;
//	public GameObject registerUI;
//	public GameObject testLogin;
//	public GameObject loginObj;
//
//	public InputField userName;
//	public InputField inputUsername;
//
//	public Text lbVersion;
//
//	[Header("Download Asset")]
//	private ProcessDownloadAsset process;
//
//#if UNITY_EDITOR
//	public int StartingTutorialStep = 0;
//#endif
//
//	private SmartFox sfs;
//	[HideInInspector]public string fbid = "";
//	private string nickname = "";
//	private bool connectSFSFailed = false;
//	private bool isLoggedIn = false;
//
//	void Awake()
//	{
//		process = GetComponent<ProcessDownloadAsset> ();
//	}
//
//	// Use this for initialization
//	void Start () {
//		QualitySettings.vSyncCount = 1;//force the game to only update frames in sync with the refresh rate of the monitor/screen
//		Application.targetFrameRate = 60;
//		OpenCubeUI.isFromLoginScene = true;
//	
//		lbVersion.text = "Version: " + OverloadSFS.Instance.version;
//		mode.SetActive (false);
//#if USING_ASSET
//		StartCoroutine(process.Download());
//#else
//		OnClickedMultiplayer ();
//#endif
//	}
//
//	void OnDisable()
//	{
//		if (OverloadSFS.Instance != null && OverloadSFS.Instance.SFS != null) {
//			OverloadSFS.Instance.OnConnectionListener -= OnConnection;
//			OverloadSFS.Instance.OnConnectionLostListener -= OnConnectionError;
//			OverloadSFS.Instance.OnLoginListener -= OnLogin;
//			OverloadSFS.Instance.OnLoginErrorListener -= OnLoginError;
//		}
//	}
//
//	IEnumerator SaveStepTutorial(int _step)
//	{
//		yield return new WaitForSeconds (0.5f);
//		OverloadSFS.Instance.Request<SaveStepTutorialResponse>(new SaveStepTutorialRequest(_step), (res, state, unit) =>
//			{
//				if(state == SUGA.SFS2X.Network.SGSFRequestUnit.State.Completed)
//				{
//					Debug.Log(res.ErrorCode);
//					if (res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.OK)
//						Debug.Log("Step tutorial " + res.stepTutorial);
//				}
//			}, null, 15);
//	}
//
//	IEnumerator DoConnect(TypeLogin typeLogin, string _nickname = "") {
////		Debug.Log ("DoConnect");
//		OverloadSFS.Instance.OnConnectionListener += OnConnection;
//		OverloadSFS.Instance.OnConnectionLostListener += OnConnectionError;
//		OverloadSFS.Instance.OnLoginListener += OnLogin;
//		OverloadSFS.Instance.OnLoginErrorListener += OnLoginError;
//
//		UIManager.ShowLoading ();
//		connectSFSFailed = false;
//		currentTypeLogin = typeLogin;
//		OverloadSFS.Instance.Connect ();
//		while (OverloadSFS.Instance.SFS.IsConnected == false) {
//			yield return null;
//			if (connectSFSFailed)
//				yield break;
//		}
//
//		if (typeLogin == TypeLogin.GUESS)
//			DoLoginAsGuest ();
//		else if (typeLogin == TypeLogin.FACEBOOK)
//			DoLoginUsingFB ();
//		else if (typeLogin == TypeLogin.USERNAME)
//			DoLoginUsingUsername (_nickname);
//	}
//
//	public void OnConnection(bool isConnected) 
//	{
////		UIManage.HideLoading ();
////		bool success = (bool)evt.Params["success"];
//		
//		if (isConnected) 
//		{
//			Debug.Log("Connect SFS success");
//		} 
//		else 
//		{
//			Debug.LogError("Could not connect to server");
//			UIManager.HideLoading ();
//			connectSFSFailed = true;
//			OverloadSFS.Instance.ResetSubcriber ();
//			UIManager.ShowMessage ("Could not connect to server", "", MessageBox.Buttons.RetryOffline, call => {
//				if(call == MessageBox.DialogResult.Retry){//back to login scene
//					OverloadSFS.Instance.OnDestroy();
//					OverloadSFS.Instance.SFS = null;
//					OverloadSFS.Instance.InitSFS();
//					SceneManager.LoadScene(SceneName.Login);
//				}
//				else if(call == MessageBox.DialogResult.Cancel){//play offline
//					OnClickedOffline();
//				}
//				return true;
//			});
//
//		}
//	}
//
//	private void OnConnectionError(string error)
//	{
//		Debug.Log (error);
//		OverloadSFS.isResponseDisconnected = true;
//	}
//
//	private void DoLoginAsGuest()
//	{
//		string uid = SGLocalDataManager.LoadData<string> (LocalDataType.uid);
//		if (uid == "") {
//			uid = System.Guid.NewGuid ().ToString ();
//			SGLocalDataManager.SaveData<string> (LocalDataType.uid, uid);
//		}
////		Debug.Log ("Login as Guess: " + uid);
//		if (!isLoggedIn) {
//			ISFSObject data = new SFSObject ();
//			data.PutUtfString ("version", OverloadSFS.Instance.version);
//			sfs.Send (new LoginRequest (uid, "", OverloadSFS.Instance.zone, data));
//		} else {
//			RandomName ();
//			registerUI.gameObject.SetActive (true);
//		}
//	}
//
//	private void DoLoginUsingFB()
//	{
//		string uid = SGLocalDataManager.LoadData<string> (LocalDataType.uid);
//		if (uid == "") {
//			uid = System.Guid.NewGuid ().ToString ();
//			SGLocalDataManager.SaveData<string> (LocalDataType.uid, uid);
//		}
//		ISFSObject data = new SFSObject ();
//		data.PutUtfString ("fbid", fbid);
//		data.PutUtfString ("version", OverloadSFS.Instance.version);
//		sfs.Send(new LoginRequest(uid, "", OverloadSFS.Instance.zone, data));
//	}
//
//	private void DoLoginUsingUsername(string _username)
//	{
//		if (sfs.MySelf == null) {
//			string uid = System.Guid.NewGuid ().ToString ();
//			SGLocalDataManager.SaveData (LocalDataType.uid, uid);
//
//			ISFSObject data = new SFSObject ();
//			data.PutUtfString ("testUserName", _username);
//			data.PutUtfString ("version", OverloadSFS.Instance.version);
//			sfs.Send (new LoginRequest (uid, "", OverloadSFS.Instance.zone, data));
//		} else {
//			SendRequestLoginByUsername (_username);
//		}
//	}
//
//	private void OnLogin(string zone, User user, ISFSObject data) {
//		// Initialize UDP communication
////		Debug.Log ("User " + user.Name + " login SFS Success!");
//
////		loginStatus.gameObject.SetActive (true);
////		loginObj.SetActive (false);
//		isLoggedIn = true;
//		string username = (nickname != "") ? nickname : user.Name;
//		SGPlayersManager.Instance.CreatePlayerMe (user, username, username, fbid, 0);
//
//		if (data != null && data.ContainsKey ("relogin")) {
//			LoadToGarage (isRelogin: true);
//		} else {
//			if (fbid != "") {
//				#region LOGIN USING FBID (CACHED FROM PLAYER_PREF)
//				OverloadSFS.Instance.Request<LoginViaFBResponse> (new LoginViaFBRequest (fbid, Application.systemLanguage.ToString()), (res, state, unit) => {
//					if(state == SUGA.SFS2X.Network.SGSFRequestUnit.State.Completed){
//						if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.OK){
//							SGPlayersManager.Instance.PlayerMe.Nickname = res.nickname;
//							if(SGPlayersManager.Instance.PlayerMe.SetUserDataFromLogin(res.userdata, this))
//								LoadToGarage();
//						}
//						else if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.CHANGE_UID){
//							string _newUID = res.uid;
//							SGLocalDataManager.SaveData<string>(LocalDataType.uid, _newUID);
//							Relogin(_newUID);
//						}
//						else{
//							UIManager.HideLoading();
//							if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.REQUIRE_REGISTER)
//								registerUI.SetActive(true);
//							else
//								UIManager.ShowMessage(string.Format("Something went wrong (ErrorCode = {0})", (int)res.ErrorCode));
//						}
//					}
//				}, null, 15);
//				#endregion
//			}
//			else{
//				#region LOGIN USING FBID
//				if(data != null && data.ContainsKey("fbid")){
//					fbid = data.GetUtfString("fbid");
//					OverloadSFS.Instance.Request<LoginViaFBResponse> (new LoginViaFBRequest (fbid, Application.systemLanguage.ToString()), (res, state, unit) => {
//						if(state == SUGA.SFS2X.Network.SGSFRequestUnit.State.Completed){
//							if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.OK){
//								SGPlayersManager.Instance.PlayerMe.Nickname = res.nickname;
//								if(SGPlayersManager.Instance.PlayerMe.SetUserDataFromLogin(res.userdata, this))
//									LoadToGarage();
//							}
//							else if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.CHANGE_UID){
//								string _newUID = res.uid;
//								SGLocalDataManager.SaveData<string>(LocalDataType.uid, _newUID);
//								Relogin(_newUID);
//							}
//							else{
//								UIManager.HideLoading();
//								if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.REQUIRE_REGISTER)
//									registerUI.SetActive(true);
//								else
//									UIManager.ShowMessage(string.Format("Something went wrong (ErrorCode = {0})", (int)res.ErrorCode));
//							}
//						}
//					}, null, 15);
//				}
//				#endregion
//				else{
//					#region LOGIN USING USER_NAME (ONLY TEST)
//					if (data != null && data.ContainsKey ("testUserName")) {
//						string _testUsername = data.GetUtfString("testUserName");
//						SendRequestLoginByUsername(_testUsername);
//					} 
//					#endregion
//
//					#region LOGIN VIA GUESS
//					else {
//						OverloadSFS.Instance.Request<LoginViaGuessResponse> (new LoginViaGuessRequest (Application.systemLanguage.ToString()), (res, state, unit) => {
//							if(state == SUGA.SFS2X.Network.SGSFRequestUnit.State.Completed){
//								if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.OK){
//									SGPlayersManager.Instance.PlayerMe.Nickname = res.nickname;
//									if(SGPlayersManager.Instance.PlayerMe.SetUserDataFromLogin(res.userdata, this))
//										LoadToGarage();
//								}
//								else{
//									UIManager.HideLoading();
//									if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.REQUIRE_REGISTER){
//										RandomName();
//										registerUI.SetActive(true);
//									}
//									else
//										UIManager.ShowMessage(string.Format("Something went wrong (ErrorCode = {0})", (int)res.ErrorCode));
//								}
//							}
//						}, null, 15);
//					}
//					#endregion
//				}
//			}
//		}
//	}
//
//	private void OnLoginError(string error) {
//		UIManager.HideLoading ();
//		// Show error message
//		Debug.LogError("Login failed: " + error);
//		if (error.Contains ("already logged")) {
//			UIManager.ShowMessage ("User " + userName.text + " is already logged in", "Error", call => {
//				userName.text = "";
//				return true;
//			});
//		} else if (error.Contains ("Maintenance")) {
//			UIManager.ShowMessage ("Server is under maintenance\nPlease try again later.", call => {
//				Application.Quit ();
//				return true;
//			});
//		} else if ( error.Contains("Version not match")){
//			UIManager.ShowMessage("Please update to new version", call => {
//#if UNITY_ANDROID
//				Application.OpenURL("http://playoverload.io/");
//#elif UNITY_IOS
////				Application.OpenURL("itms-services://?action=download-manifest&url=https://dl.dropboxusercontent.com/s/1vmo2u72inn73em/manifest.plist");
//				Application.OpenURL("http://playoverload.io/");
//#endif
//				return true;
//			});
//		}
//		else
//			loginObj.SetActive (true);
//	}
//
//	public void OnClickedLoginAsGuest()
//	{
//		if (OverloadSFS.Instance.SFS.IsConnected == false) {
//			OverloadSFS.Instance.Connect();
//		}
//
//		sfs = OverloadSFS.Instance.SFS;
//
//		if (sfs != null) {
//			if (sfs.IsConnected) 
//				DoLoginAsGuest ();
//			else 
//				StartCoroutine(DoConnect (TypeLogin.GUESS));
//		} 
//		else 
//			Debug.LogError("WTF???");
//	}
//
//	public void OnClickedLoginUsingUsername()
//	{
//		if (inputUsername.text == "")
//			return;
//
//		if (OverloadSFS.Instance.SFS.IsConnected == false) {
//			OverloadSFS.Instance.Connect();
//		}
//
//		sfs = OverloadSFS.Instance.SFS;
//
//		if (sfs != null) {
//			if (sfs.IsConnected) 
//				DoLoginUsingUsername (inputUsername.text);
//			else 
//				StartCoroutine(DoConnect (TypeLogin.USERNAME, inputUsername.text));
//		} 
//		else 
//			Debug.LogError("WTF???");
//	}
//
//	public void OnLoginFB()
//	{
//#if !UNITY_STANDALONE
//		if (FB.IsInitialized) {
//			UIManager.HideLoading();
//			if (FB.IsLoggedIn == false) {
//				FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, result => {
//					if (!string.IsNullOrEmpty(result.Error)){
//						Debug.LogError("Error - Check log for details");
//						Debug.LogError(result.Error);
//					}
//					else if (result.Cancelled){
//						Debug.LogWarning("Cancelled - Check log for details");
//					}
//					else if (!string.IsNullOrEmpty(result.RawResult)){
//						Debug.Log("Success");
////						Debug.Log(AccessToken.CurrentAccessToken.UserId);
//						fbid = AccessToken.CurrentAccessToken.UserId;
//						SGLocalDataManager.SaveData<string>(LocalDataType.fbid, fbid);
//						
//						if (!OverloadSFS.Instance.SFS.IsConnected){
//							OverloadSFS.Instance.Connect();
//						}
//						
//						sfs = OverloadSFS.Instance.SFS;
//						
//						if (sfs != null) {
//							if (sfs.IsConnected) 
//								DoLoginUsingFB ();
//							else //connect sfs and login using fb
//								StartCoroutine(DoConnect (TypeLogin.FACEBOOK));
//						} 
//						else 
//							Debug.LogError("WTF???");
//					}
//				});
//			}
//			else{
//				fbid = AccessToken.CurrentAccessToken.UserId;
//				SGLocalDataManager.SaveData<string>(LocalDataType.fbid, fbid);
//
//				if (!OverloadSFS.Instance.SFS.IsConnected){
//					OverloadSFS.Instance.Connect ();
//
//				}
//				
//				sfs = OverloadSFS.Instance.SFS;
//				
//				if (sfs != null) {
//					if (sfs.IsConnected) 
//						DoLoginUsingFB ();
//					else 
//						StartCoroutine(DoConnect (TypeLogin.FACEBOOK));
//				} 
//				else 
//					Debug.LogError("WTF???");
//			}
//		}
//#endif
//	}
//
//	public void OnClickedSubmitRegister()
//	{
//		if (userName.text == "") {
//			UIManager.ShowMessage ("Please input your nickname");
//			return;
//		}
//
//		for (int i = 0; i < SGConfigManager.configBadNickname.Records.Count; i++) {
//			string badNickname = SGConfigManager.configBadNickname.Records [i].word;
//			badNickname = badNickname.Replace (" ", "").ToLower();
//			if (userName.text.ToLower().Equals (badNickname)) {
//				UIManager.ShowMessage ("Bad nickname");
//				return;
//			}
//		}
//
//		UIManager.ShowLoading ();
//		OverloadSFS.Instance.Request<RegisterNewUserResponse> (new RegisterNewUserRequest (userName.text, fbid, Application.platform.ToString(), Application.systemLanguage.ToString()), (res, state, unit) => {
//			if(state == SUGA.SFS2X.Network.SGSFRequestUnit.State.Completed){
//				if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.OK){
//					SGPlayersManager.Instance.PlayerMe.Nickname = res.nickname;
//					if (Facebook.Unity.FB.IsInitialized) {
//						Facebook.Unity.FB.LogAppEvent (Facebook.Unity.AppEventName.CompletedRegistration);
//					}
//					if(SGPlayersManager.Instance.PlayerMe.SetUserDataFromLogin(res.userdata, this))
//						LoadToGarage();
//				}
//				else{
//					UIManager.HideLoading();
//					if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.USERNAME_EXISTS)
//						UIManager.ShowMessage("This username had existed");
//					else if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.BAD_NICK_NAME)
//						UIManager.ShowMessage("Bad username");
//					else
//						UIManager.ShowMessage(string.Format("Something went wrong (Error Code = {0})", (int)res.ErrorCode));
//				}
//
//			}
//		}, null, 15);
//	}
//	
//	public void OnClickedBtnFanpage()
//	{
//		StartCoroutine(OpenFacebookPage());
//	}
//	
//	IEnumerator OpenFacebookPage()
//	{
//		Application.OpenURL("fb://profile/273707352963177");
//		yield return new WaitForSeconds(1);
//		if(leftApp)
//			leftApp = false;
//		else
//			Application.OpenURL("https://www.facebook.com/273707352963177");
//
//	}
//
//	public void Relogin(string uid)
//	{
//		StartCoroutine (Relogin_Coroutine (uid));
//	}
//
//	IEnumerator Relogin_Coroutine(string uid)
//	{
//		OverloadSFS.isResponseDisconnected = false;
//		Debug.Log ("Disconnect ne");
//		OverloadSFS.Instance.Disconnect ();
//		while (OverloadSFS.isResponseDisconnected == false)
//			yield return null;
//
//		Debug.Log ("Connect ne");
//		OverloadSFS.Instance.Connect();
//		while (OverloadSFS.Instance.SFS.IsConnected == false)
//			yield return null;
//
//		Debug.Log ("Connect successful");
//
//		ISFSObject inData = new SFSObject ();
//		inData.PutBool ("relogin", true);
//		inData.PutUtfString ("version", OverloadSFS.Instance.version);
//
//		Debug.Log ("relogin ne: " + uid);
//		sfs.Send(new LoginRequest(uid, "", OverloadSFS.Instance.zone, inData));
//	}
//
//	public void OnClickedMultiplayer()
//	{
//		if (OverloadSFS.Instance.serverType != SUGA.SFS2X.Network.SGSFSServerType.LOCAL) {
//			//check network connection
//			string htmlText = Utils.GetHtmlFromUri("http://google.com");
//			if(htmlText == "" || !htmlText.Contains("schema.org/WebPage")){//No connection
//				UIManager.ShowMessage ("No Internet Connection\nPlease check your WIFI", "", MessageBox.Buttons.RetryOffline, call => {
//					if(call == MessageBox.DialogResult.Retry)//retry connect
//						OnClickedMultiplayer();
//					else if(call == MessageBox.DialogResult.Cancel){//play offline
//						SGConfigManager.Instance.LoadAllConfigLocal();
//						OnClickedOffline();
//					}
//					return true;
//				});
//				return;
//			}
//		}
//
////		mode.SetActive (false);
//#if UNITY_EDITOR
//		testLogin.SetActive(true);
//#endif
//
//#if !UNITY_STANDALONE
//		if (!FB.IsInitialized) {
//			UIManager.ShowLoading ();
//			// Initialize the Facebook SDK
////			Debug.Log ("Init ne....");
//			FB.Init (InitCallback, OnHideUnity);
//		} else {
//			if(FB.IsLoggedIn){
//				Debug.Log("Logged in FB");
//				OnLoginFB();
//			}
//			else
//				loginObj.SetActive(true);
//		}
//#else
//		loginObj.SetActive(true);
//#endif
//	}
//
//	public void OnClickedOffline()
//	{
//		SGSceneManager.LoadLevel(SceneName.Garage);
//	}
//
//	public void OnClickedBack()
//	{
//		loginObj.SetActive (true);
//		registerUI.SetActive (false);
//		//OverloadSFS.Instance.Disconnect ();
//		//testLogin.SetActive (false);
//		//mode.SetActive (true);
//	}
//	
//	bool leftApp = false;
//	void OnApplicationPause()
//	{
//		leftApp = true;
//	}
//
//	private void InitCallback ()
//	{
//		if (FB.IsInitialized) {
//			// Signal an app activation App Event
//			FB.ActivateApp();
//			// Continue with Facebook SDK
//			// ...
//
//			Debug.Log("Init FB success, Logged in =" + FB.IsLoggedIn);
//
//			if(FB.IsLoggedIn){
//				Debug.Log("Logged in FB");
//				OnLoginFB();
//			}
//			else{
//#if !UNITY_EDITOR
//				//check if exists fbid in PlayerPrefs -> auto login using fb
//				string fbid = SGLocalDataManager.LoadData<string>(LocalDataType.fbid);
//				Debug.Log("fbid = " + fbid);
//				if(fbid != "")
//					OnLoginFB();
//				else{
//					loginObj.SetActive (true);
//					UIManager.HideLoading();
//				}
//#else
//				loginObj.SetActive (true);
//				UIManager.HideLoading();
//#endif
//			}
//		} else {
//			Debug.Log("Failed to Initialize the Facebook SDK");
//			loginObj.SetActive (true);
//			UIManager.HideLoading();
//		}
//	}
//	
//	private void OnHideUnity (bool isGameShown)
//	{
//		if (!isGameShown) {
//			// Pause the game - we will need to hide
//			Time.timeScale = 0;
//		} else {
//			// Resume the game - we're getting focus again
//			Time.timeScale = 1;
//		}
//	}
//
//	private void LoadToGarage(bool isRelogin = false)
//	{
//		if(!isRelogin)
//			StartCoroutine (LoadGarage_Coroutine ());//just load to garage
//		else
//			GetUserData_Coroutine ();//get user data and load to garage
//		loginObj.SetActive (false);
//	}
//
//	IEnumerator LoadGarage_Coroutine()
//	{
////		if (gotConfig == false) {
////			//send request get config data
////			sfs.Send (new ExtensionRequest (LobbyConstants.CMD_GET_CONFIG, new SFSObject ()));
////		}
////		while (gotConfig == false)
////			yield return null;
//		UIManager.ShowLoading ();
//#if UNITY_EDITOR
//		if (StartingTutorialStep >= 0) {
//			StartCoroutine(SaveStepTutorial (StartingTutorialStep));
//			SGPlayersManager.Instance.PlayerMe.Property.StepTutorial = StartingTutorialStep;
//		}
//#endif
//		if(SGPlayersManager.Instance.PlayerMe.Property.StepTutorial < TutorialStep.Movement)
//			SGSceneManager.LoadLevel (SceneName.Tutorial_City);
//		else
//			SGSceneManager.LoadLevel (SceneName.Garage);
//
//		yield return null;
//	}	
//
//	void GetUserData_Coroutine()
//	{
//		UIManager.ShowLoading ();
//		OverloadSFS.Instance.Request<GetUserDataResponse> (new GetUserDataRequest (), (res, state, unit) => {
//			if(state == SUGA.SFS2X.Network.SGSFRequestUnit.State.Completed){
//				if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.OK)
//					LoadToGarage();
//				else
//					UIManager.ShowMessage(string.Format("Something went wrong (Error Code = {0})", (int)res.ErrorCode));
//			}
//		}, null, 15);
//	}	
//
//	private void SendRequestLoginByUsername(string _username)
//	{
//		OverloadSFS.Instance.Request<LoginViaUsernameResponse> (new LoginViaUsernameRequest (_username), (res, state, unit) => {
//			if(state == SUGA.SFS2X.Network.SGSFRequestUnit.State.Completed){
//				if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.OK){
//					string currentUID = SGLocalDataManager.LoadData<string>(LocalDataType.uid);
//					string _uid = res.uid;
//					if(currentUID != _uid){//relogin with new UID
//						currentUID = _uid;
//						SGLocalDataManager.SaveData<string>(LocalDataType.uid, _uid);
//						StartCoroutine(Relogin_Coroutine(_uid));
//					}
//				}
//				else{
//					UIManager.HideLoading();
//					if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.REQUIRE_REGISTER)
//						registerUI.SetActive(true);
//					else if(res.ErrorCode == SUGA.SFS2X.Network.SGSFErrorCode.NOT_EXISTS_USER)
//						UIManager.ShowMessage("Not Exists User\t");
//					else
//						UIManager.ShowMessage(string.Format("Something went wrong (ErrorCode = {0})", (int)res.ErrorCode));	
//				}
//
//			}
//		}, null, 15);
//	}
//
//	public void RandomName(){
//		
//		int fristRan = Random.Range (1, SGConfigManager.configName.Records.Count+1);
//		int lastRan = Random.Range (1, SGConfigManager.configName.Records.Count+1);
//		ConfigNameRecord configFristName = SGConfigManager.configName.GetConfigByID (fristRan);
//		ConfigNameRecord configLastName = SGConfigManager.configName.GetConfigByID (lastRan);
//
//		string fristName = configFristName.fristName;
//		fristName = fristName.Replace(fristName.Substring (1),fristName.Substring(1).ToLower());
//		string lastName = configLastName.lastName;
//		if(lastName != "")
//			lastName = lastName.Replace (lastName.Substring (1), lastName.Substring (1).ToLower ());
//		userName.text = fristName + lastName;
//	}
//}
