using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomUtility {

	public static GameObject CustomInstantiate(GameObject prefabObj)
	{
		GameObject target = GameObject.Instantiate (prefabObj);
		target.transform.SetParent (prefabObj.transform.parent);
		target.transform.localScale = prefabObj.transform.localScale;
		target.transform.position = prefabObj.transform.position;

		return target;
	}
}
