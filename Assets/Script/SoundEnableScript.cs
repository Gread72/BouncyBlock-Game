using UnityEngine;
using System.Collections;

public class SoundEnableScript : MonoBehaviour {
    /*
    * Summary - SoundEnableScript - Sound Enable script
    * Repurposed script for Sound Enable button component
   */

    #region public variables
    
    [SerializeField]
    public bool soundEnabled = true;

    [SerializeField]
	public bool isMouseLock = false;
    
    public GUIText textUI;
    
    #endregion

    #region private variables
    
    private int soundEnabledValue = 1;

    #endregion

    void Start () 
	{
		if (PlayerPrefs.HasKey (Utility.PREF_KEY_SOUND_ON)) 
		{
            soundEnabledValue = PlayerPrefs.GetInt(Utility.PREF_KEY_SOUND_ON);
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
            if (setValue) PlayerPrefs.SetInt(Utility.PREF_KEY_SOUND_ON, 1);
			textUI.text = "Sound On";
		} else {
            if (setValue) PlayerPrefs.SetInt(Utility.PREF_KEY_SOUND_ON, 0);
			textUI.text = "Sound Off";
		}

		StartCoroutine("ResetLock");
	}
	
	IEnumerator ResetLock(){
		yield return new WaitForSeconds(1);
		isMouseLock = false;
	}
}
