using UnityEngine;
using System.Collections;

public class SoundEnableScript : MonoBehaviour {

	public bool soundEnabled = true;
	public GUIText textUI;
	private int soundEnabledValue = 1;
	public bool isMouseLock = false;

	void Start () 
	{
		if (PlayerPrefs.HasKey ("SoundOn")) 
		{
			soundEnabledValue = PlayerPrefs.GetInt ("SoundOn");
			if(soundEnabledValue > 0)
			{
				soundEnabled = true;
			}else
			{
				soundEnabled = false;
			}

			setSoundSettings(false);
		}

	}

	void OnMouseDown() {
		if (isMouseLock == false) {
			soundEnabled = !soundEnabled;
			setSoundSettings ();
			isMouseLock = true;
		}
	}

	private void setSoundSettings(bool setValue = true){
		if (soundEnabled) {
			if(setValue) PlayerPrefs.SetInt ("SoundOn",1);
			textUI.text = "Sound On";
		} else {
			if(setValue) PlayerPrefs.SetInt ("SoundOn",0);
			textUI.text = "Sound Off";
		}

		StartCoroutine("ResetLock");
	}

	
	IEnumerator ResetLock(){
		//Debug.Log ("ResetLock");
		yield return new WaitForSeconds(1);
		isMouseLock = false;
	}
}
