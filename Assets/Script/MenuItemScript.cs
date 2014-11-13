using UnityEngine;
using System.Collections;

public class MenuItemScript : MonoBehaviour {

	public string goToScene = "";

	public bool enabled = true;
	public bool isExternalLink = false;
	public bool isAction = false;

	public GameObject target;
	public Vector3 originPosition;
	public Vector3 newPosition;

	void OnMouseDown() {
		//Debug.Log ("Mouse Click");
		if(enabled == true) {
			if(isExternalLink == false) {
				if(isAction == true){
					//iTween.MoveTo(target, iTween.Hash("x", newPosition.x, "y", newPosition.y));
				}else{
					Application.LoadLevel(goToScene);
				}
			}else if(isExternalLink == true){
				Application.OpenURL(goToScene);
			}

		}
	}
}
