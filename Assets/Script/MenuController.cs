using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GUIText starsControl;
	public GUIText medhighScoreTxt;
	public GUIText hardhighScoreTxt;

	public GameObject medButton;
	public GameObject hardButton;
	
	void Update () {
		// Handle Back Button
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("HighScore")) {
			int highPoints = PlayerPrefs.GetInt ("HighScore");
			starsControl.text = setStars(highPoints);
			starsControl.enabled = true;
		}else{
			starsControl.enabled = false;
		}

		// by default
		medButton.GetComponentInChildren<GUIText>().color = Color.gray;
		hardButton.GetComponentInChildren<GUIText>().color = Color.gray;
		medhighScoreTxt.enabled = false;
		hardhighScoreTxt.enabled = false;

		// by stars - display/enable timed levels
        if (starsControl.text == "* *" || starsControl.text == "* * *")
        {
			medButton.GetComponent<MenuItemScript>().enabled = true;
			medButton.GetComponentInChildren<GUIText>().color = Color.white;
		}

		if(starsControl.text == "* * *"){
			hardButton.GetComponent<MenuItemScript>().enabled = true;
			hardButton.GetComponentInChildren<GUIText>().color = Color.white;
		}

		// show top times
		if(medButton.GetComponent<MenuItemScript>().enabled == true ||
		   hardButton.GetComponent<MenuItemScript>().enabled == true){
			setHighTimes();
		}

	}

	private void setHighTimes(){
		// Medium
		if (PlayerPrefs.HasKey ("HighTime2")) {
			medhighScoreTxt.text = "Top Time: " + formatLapsedTime(PlayerPrefs.GetFloat("HighTime2")).ToString();
			medhighScoreTxt.enabled = true;
		}else{
			medhighScoreTxt.enabled = false;
		}
		
		// Hard
		if (PlayerPrefs.HasKey ("HighTime3")) {
			hardhighScoreTxt.text = "Top Time: " + formatLapsedTime(PlayerPrefs.GetFloat("HighTime3")).ToString();
			hardhighScoreTxt.enabled = true;
		}else{
			hardhighScoreTxt.enabled = false;
		}
	}
	
	private string formatLapsedTime(float time){
		time = Mathf.Round(time);
		//Debug.Log("Time:" + time);
		
		string min = Mathf.Floor(time / 60).ToString("00");
		string secs = (time % 60).ToString("00");
		return  min + ":" + secs;
	}

	string setStars(int points){
		string starsText = "";
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
