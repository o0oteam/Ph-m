using UnityEngine;
using DG.Tweening;

[RequireComponent (typeof(CanvasGroup))]
public class UIComponent : MonoBehaviour
{
	#region Fields
	public float TweenTime = 0.5f;
	public UIName NameUI;
	public CanvasGroup canvasGroup;

	public bool useTweenScale = true;

	#endregion Fields

	#region Init

	void Awake ()
	{
		canvasGroup = GetComponent<CanvasGroup> ();
	}

	void Start ()
	{
		RemoveListener ();
		AddListeners ();
	}

	void OnDestroy ()
	{
		RemoveListener ();
	}

	#endregion Init

	#region Event Methods
	public virtual void AddListeners ()
	{
		//TODO Add all UI's listener
		CustomEventManager.OnButtonClicked += HandleButtonClicked;
		CustomEventManager.OnButtonWithIDClicked += HandleButtonWithIDClicked;
	}

	public virtual void RemoveListener ()
	{
		//TODO remove all lUI's listener
		CustomEventManager.OnButtonClicked -= HandleButtonClicked;
		CustomEventManager.OnButtonWithIDClicked -= HandleButtonWithIDClicked;
	}

	public void OnButtonClicked (string button_name)
	{
		CustomEventManager.ClickButton (button_name);
	}
	#endregion Event Methods

	#region Helper Methods


	public virtual void HandleButtonClicked (string button_name)
	{
	}

	public virtual void HandleButtonWithIDClicked (string button_name, int id)
	{
	}



	#endregion Helper Methods

	#region Tween Methods

	public void ShowUI ()
	{
		// Tween 1
		FadeTween (true);
		// Tween 2
		ScaleTween (true);
	}

	public void HideUI ()
	{
		// Tween 1
		FadeTween (false);
		// Tween 2
		ScaleTween (false);
	}

	public void FadeTween (bool isActive)
	{
		this.gameObject.SetActive (true);
		int fade_value = isActive ? 0 : 1;
		this.canvasGroup.alpha = fade_value;
		this.canvasGroup.interactable = false;
		this.canvasGroup.DOFade (1 - fade_value, TweenTime).OnComplete (() => {
			this.canvasGroup.interactable = true;
			this.gameObject.SetActive (isActive);
		});
	}

	public void ScaleTween (bool isActive)
	{
		if (useTweenScale) {
			this.transform.localScale = isActive ? Vector3.one * 1.2f : Vector3.one;
			this.transform.DOScale (isActive ? Vector3.one : Vector3.one * 1.2f, TweenTime);
		}
	}

	#endregion Tween Methods
}
