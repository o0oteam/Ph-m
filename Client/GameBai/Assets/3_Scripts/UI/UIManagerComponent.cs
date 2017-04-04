using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerComponent : MonoBehaviour
{
	#region Fields

	public static UIManagerComponent InstanceMainUI;

	public float TweenTime = 0.5f;
	public bool isSyncTweenTime = false;
	public Dictionary<UIName, UIComponent> DictUI = new Dictionary<UIName, UIComponent> ();
	public UIName _CurrentUI = UIName.None;

	[Header ("UIComponents (Any order)")]
	public List<UIComponent> ListUI;
	#endregion Fields

	#region Init

	public virtual void Awake ()
	{
		InstanceMainUI = GetComponent<UIManagerComponent> ();
	}

	public virtual void Start ()
	{
		DictUI.Clear ();
		for (int i = 0; i < ListUI.Count; i++) {
			DictUI.Add (ListUI [i].NameUI, ListUI [i]);
			if(ListUI[i].NameUI != _CurrentUI)
				ListUI [i].HideUI ();
			if (isSyncTweenTime)
				ListUI [i].TweenTime = TweenTime;
		}

		DictUI [_CurrentUI].ShowUI ();
	}

	#endregion Init

	#region Helper Methods

	public T GetUIByName<T> (UIName ui_name)
	{
		return (T)Convert.ChangeType (DictUI [ui_name], typeof(T));
	}

	public void ChangUIByName (UIName ui_name)
	{
		if (DictUI.ContainsKey (ui_name)) {
			DictUI [_CurrentUI].HideUI ();
			DictUI [ui_name].ShowUI ();
			_CurrentUI = ui_name;
		} else {
			Debug.LogError (ui_name + " doesnt exist!?");
		}
	}

	#endregion Helper Methods
}
