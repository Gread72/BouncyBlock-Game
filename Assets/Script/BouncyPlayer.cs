using UnityEngine;
using System.Collections;

public class BouncyPlayer : MonoBehaviour {

	public float speed = 1f;
	public bool enable = false;
	public bool moveLeft = true;
	public bool playerHit = false;
	public bool clearHighScore = false;

	public int points = 0;
	public int highPoints = 0;

	public AudioClip correctSound;
	public AudioClip errorSound;


	private bool soundEnabled = true;

	// Use this for initialization
	void Start () {
		enable = false;
		if(clearHighScore) PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.HasKey ("HighScore")) {
			highPoints = PlayerPrefs.GetInt ("HighScore");
		}

		gameObject.rigidbody.useGravity = false;
		gameObject.renderer.material.color = Color.clear; //convertRGBNumToDecimal (255, 255, 255, 255);

		getSoundSetting ();

	}

	static Color convertRGBNumToDecimal(float r, float g, float b,float a){
		Color color = new Color(r/255.0F,g/255.0F,b/255.0F,a/255.0F);
		
		return color;
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
		} else {
			//gameObject.rigidbody.useGravity = false;
			//newPosition.y = 0;
		}
		transform.position = newPosition;
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log (collision.gameObject.name);
		if (collision.gameObject.name == "EdgeCubeElement") {
			if(playerHit == false){
				if(soundEnabled){
					audio.clip = errorSound;
					audio.Play ();
				}
			}
			playerHit = true;
			gameObject.renderer.material.color = Color.red;
			//Debug.Log("highPoints " + highPoints);
			if(points > highPoints){
				highPoints = points;
				PlayerPrefs.SetInt ("HighScore",highPoints);
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
		if (PlayerPrefs.HasKey ("SoundOn")) {
			soundEnabledValue = PlayerPrefs.GetInt ("SoundOn");
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
