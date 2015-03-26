using UnityEngine;
using System.Collections;

public class BouncyPlayer : MonoBehaviour
{
    /*
     * Summary - BouncyPlayer - player/GameObject square class
     * This class contains the logic for the player element - bouncy square
     * - Physics of Gameobject
     * - Current points and high score
     * - Sound setting
    */

    #region public variables

    [SerializeField]
	public float speed = 1f;
    
    [HideInInspector]
    public int points = 0;

    [HideInInspector]
    public int highPoints = 0;

    [HideInInspector]
	public bool enable = false;

    [HideInInspector]
	public bool moveLeft = true;

    [HideInInspector]
	public bool playerHit = false;

    [HideInInspector]
	public bool clearHighScore = false;

	public AudioClip correctSound;
	public AudioClip errorSound;

    #endregion

    #region private variables
    
    private bool soundEnabled = true;
    private static string COLLISION_OBJECT_NAME = "EdgeCubeElement";
    #endregion

    // Use this for initialization
	void Start () {
		enable = false;
		if(clearHighScore) PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.HasKey (Utility.PREF_KEY_HIGH_SCORE)) {
            highPoints = PlayerPrefs.GetInt(Utility.PREF_KEY_HIGH_SCORE);
		}

		gameObject.rigidbody.useGravity = false;
		gameObject.renderer.material.color = Color.clear;

		getSoundSetting ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = new Vector3 (transform.position.x,
		                                   transform.position.y,
		                                   transform.position.z);
		if (enable == true) {
			gameObject.rigidbody.useGravity = true;
			if (moveLeft == true) {
					newPosition.x = transform.position.x - ((speed) * Time.deltaTime); 
			} else {
					newPosition.x = transform.position.x + ((speed) * Time.deltaTime);
			}
		} 
		transform.position = newPosition;
	}

	public void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.name == COLLISION_OBJECT_NAME)
        {
			if(playerHit == false){
				if(soundEnabled){
					audio.clip = errorSound;
					audio.Play ();
				}
			}
			playerHit = true;
			gameObject.renderer.material.color = Color.red;
			if(points > highPoints){
				highPoints = points;
				PlayerPrefs.SetInt (Utility.PREF_KEY_HIGH_SCORE,highPoints);
			}
			return;
		} else {
			if(playerHit == false){
				if(soundEnabled){
					audio.clip = correctSound;
					audio.Play ();
				}
			}
		}
		moveLeft = !moveLeft;
		points = points + 1;

	}

	public void resetPosition(){
		Vector3 newPosition = new Vector3 (0,0,0);
		transform.position = newPosition;
		gameObject.renderer.material.color = Color.clear;
		getSoundSetting ();
	}

	private void getSoundSetting(){
		int soundEnabledValue;
        if (PlayerPrefs.HasKey(Utility.PREF_KEY_SOUND_ON))
        {
            soundEnabledValue = PlayerPrefs.GetInt(Utility.PREF_KEY_SOUND_ON);
			if(soundEnabledValue > 0)
			{
				soundEnabled = true;
			}else
			{
				soundEnabled = false;
			}
		}
	}

}
