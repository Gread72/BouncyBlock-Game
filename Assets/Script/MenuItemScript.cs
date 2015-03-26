using UnityEngine;
using System.Collections;

public class MenuItemScript : MonoBehaviour {
    /*
     * Summary - MenuItemScript - Menu Item class
     * Repurposed script for menu item components
     * - Load level
     * - External link
    */

    #region public variables
    [SerializeField]
    public string goToScene = "";
    
    [SerializeField]
    public bool enabled = true;
    
    [SerializeField]
    public bool isExternalLink = false;

    [SerializeField]
    public bool isAction = false;

	//public GameObject target;
	//public Vector3 originPosition;
    //public Vector3 newPosition;
    #endregion

    void OnMouseDown() {
		if(enabled == true) {
			if(isExternalLink == false) {
				if(isAction == false){
					Application.LoadLevel(goToScene);
				}
			}else if(isExternalLink == true){
				Application.OpenURL(goToScene);
			}

		}
	}
}
