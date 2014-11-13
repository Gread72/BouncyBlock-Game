using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Camera mainCamera;
	public GameObject player;

	public GUIText menuBackTxt;
	public GUIText soundEnableTxt;
	public GUIText pointsTxt;
	public GUIText instructTxt;
	public GUIText highScoreTxt;
    public GUIText starsControl;
	public GUIText timeTxt;
	public GUIText highTimeText;

	public GUISkin skin;

	public GameObject leftEdge;
	public GameObject rightEdge;

	public int forceToApply = 150; 
	private bool gamePlaying = false;

	private bool hasDirectionChanged = true;

	private BouncyPlayer playerScript;
	private EdgeHazardController leftEdgeScript;
	private EdgeHazardController rightEdgeScript;
	private MenuItemScript menuItemScript;
	private SoundEnableScript soundEnableScript;

	private bool isMouseLock = true;

	private float startTime = 0;
	private float currentElapseTime = 0;

	public bool isTimedGame = false;

	// Use this for initialization
	void Start () {

		#if UNITY_IPHONE 
			Debug.Log("Iphone");
			forceToApply = 40;
		#else
			Debug.Log("Android or Windows");
			forceToApply = 25;
		#endif

		mainCamera.backgroundColor = convertRGBNumToDecimal(66,121,49,5);

		playerScript = player.GetComponent<BouncyPlayer>();

		leftEdgeScript = leftEdge.GetComponent<EdgeHazardController>();

		rightEdgeScript = rightEdge.GetComponent<EdgeHazardController>();

        menuItemScript = menuBackTxt.GetComponentInChildren<MenuItemScript>();
		soundEnableScript = soundEnableTxt.GetComponentInChildren<SoundEnableScript>();

		if(isTimedGame == true){
			instructTxt.text = "Play/Start:\nTouch Screen\nEarn top time";
		}else{
			instructTxt.text = "Play/Start:\nTouch Screen\nEarn up to five stars";
		}

		timeTxt.enabled = false;
		StartCoroutine("ResetLock");
	}
	
	// Update is called once per frame
	void Update () {

		if (soundEnableScript.isMouseLock == false) {
			timeTxt.text = "Time: " + formatLapsedTime (currentElapseTime);
			starsControl.text = setStars (playerScript.points);
			highTimeText.text = getHighestTime (currentElapseTime);
		}

		// Handle Back Button
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		// mouse/touch control
        if (Input.GetMouseButton(0) && isMouseLock == false){
			if(soundEnableScript.isMouseLock == true){
				Debug.Log("MouseLock on SoundEnableText");
				return;
			}
            if (gamePlaying == false){ // click to play
				startTime = Time.time;
				currentElapseTime = Time.time - startTime; //display time lapse
                startGamePlay();
            }else{
				// in game mechanic - touch to move up
                player.rigidbody.AddForce(Vector3.up * forceToApply);
            }
        }

		if (gamePlaying == false) { // initial display at start  - Note: maybe redundant 
			highScoreTxt.enabled = true;
			highScoreTxt.text = "High Score : " + playerScript.highPoints.ToString();
            //starsControl.enabled = true;
			starsControl.text = setStars(playerScript.points);
			return; /// will ignore all other script below
		}else{
			timeTxt.enabled = true;
			currentElapseTime = Time.time - startTime; //display time lapse
		}

		if (playerScript.playerHit == true) {
			// when hit in game display results and instruction
            isMouseLock = true;
            StartCoroutine("ResetLock");
			playerScript.enable = false;
			gamePlaying = false;
			mainCamera.backgroundColor = Color.red;
			menuBackTxt.enabled = true;
			soundEnableTxt.enabled = true;
            menuItemScript.enabled = true;
            instructTxt.text = "Touch to Replay";
            instructTxt.enabled = true;
			highScoreTxt.enabled = true;
			highScoreTxt.text = "High Score : " + playerScript.highPoints.ToString();

			starsControl.text = setStars(playerScript.points);
		} else {
			// reset color and player
			playerScript.enable = true;
			mainCamera.backgroundColor = convertRGBNumToDecimal(66,121,49,5);
		}

		// display points
		pointsTxt.enabled = true;
		pointsTxt.text = (string) playerScript.points.ToString();

		// mechanic for change in spike wall
		if (hasDirectionChanged != playerScript.moveLeft) {
			hasDirectionChanged = playerScript.moveLeft;
			if (playerScript.moveLeft) {
				leftEdgeScript.Change(currentElapseTime);
			} else {
				rightEdgeScript.Change(currentElapseTime);
			}
		}
	
	}

	IEnumerator ResetLock(){
		//Debug.Log ("ResetLock");
		yield return new WaitForSeconds(1);
		isMouseLock = false;
	}

	static Color convertRGBNumToDecimal(float r, float g, float b,float a){
		Color color = new Color(r/255.0F,g/255.0F,b/255.0F,a/255.0F);

		return color;
	}

	private string formatLapsedTime(float time){
		time = Mathf.Round(time);
		//Debug.Log("Time:" + time);

		string min = Mathf.Floor(time / 60).ToString("00");
		string secs = (time % 60).ToString("00");
		return  min + ":" + secs;
	}

	private string getHighestTime(float currentElapseTime){
		float highTime = 0f;
		float resultTime = 0f;
		if (PlayerPrefs.HasKey ("HighTime" + leftEdgeScript.gameState)) {
			highTime = PlayerPrefs.GetFloat ("HighTime" + leftEdgeScript.gameState);
			if(currentElapseTime > highTime){
				highTime = currentElapseTime;
				PlayerPrefs.SetFloat ("HighTime" + leftEdgeScript.gameState, highTime);
			}
			resultTime = highTime; 
		}else{
			PlayerPrefs.SetFloat ("HighTime" + leftEdgeScript.gameState, currentElapseTime);
			resultTime = currentElapseTime;
		}

		return "Top Time: " + formatLapsedTime(resultTime);

	}

    void startGamePlay(){
        gamePlaying = true;
        playerScript.playerHit = false;
        playerScript.resetPosition();
        menuBackTxt.enabled = false;
		soundEnableTxt.enabled = false;
        menuItemScript.enabled = false;
        pointsTxt.enabled = true;
        instructTxt.enabled = false;
        playerScript.points = 0;
		leftEdgeScript.Reset(currentElapseTime);
		rightEdgeScript.Reset(currentElapseTime);
        isMouseLock = false;
        highScoreTxt.enabled = false;
        //starsControl.enabled = false;
    }

    string setStars(int points){
		//Debug.Log("setStars " + points);
        string starsText = "";
		if(points < playerScript.highPoints){
			points = playerScript.highPoints;
		}
		if (points <= 40)
        {
            starsText = "";
        }
		else if (points <= 80)
        {
            starsText = "*";
        }
		else if (points <= 125)
        {
            starsText = "* *";
        }
		else if (points <= 145)
        {
            starsText = "* * *";
        }
		else if (points <= 205)
        {
            starsText = "* * * *";
        }
		else if (points > 255)
        {
            starsText = "* * * * *";
        }

        return starsText;
    }
   
}
