using UnityEngine;
using System.Collections;

public class EdgeHazardController : MonoBehaviour {
	
	enum GameState{
		UNLIMITED = 0,
		EASY = 1,
		MEDIUM = 2,
		HARD = 3
	}

	/*
	static string GAME_STATE_UNLIMTED = "UNLIMITED";
	static string GAME_STATE_EASY = "EASY";
	static string GAME_STATE_MEDIUM = "MEDIUM";
	static string GAME_STATE_HARD = "HARD";
	*/
	public GameObject edge1;
	public GameObject edge2;
	public GameObject edge3;
	public GameObject edge4;
	public GameObject edge5;
    public GameObject edge6;
    public GameObject edge7;

	public float onPosX = 3.29f;
	public float offPosX = 4f;

	public float timeAnim = .9f;

	private int currentRandNum = -1;

    private float currentElapseTime = 0;
	
	public int gameState = 0;

	//private int[] edgeToDisplay = new int[4]; 

	// Use this for initialization
	void Start() {
		//gameState = (int)GameState.UNLIMITED;
		Reset(0); //reset the series of edge blocks
	}

	public void Reset(float currentTime){
		currentElapseTime = currentTime;
		//edge1.SetActive(false);
		setPosition (edge1, offPosX);

		//edge2.SetActive(false);
		setPosition (edge2, offPosX);

		//edge3.SetActive(false);
		setPosition (edge3, offPosX);

		//edge4.SetActive(false);
		setPosition (edge4, offPosX);

		//edge5.SetActive(false);
		setPosition (edge5, offPosX);

        setPosition(edge6, offPosX);

        setPosition(edge7, offPosX);
	}

	private void setPosition(GameObject gameObj, float xPos){
		Vector3 currentPosition = gameObj.transform.position;
		currentPosition.x = xPos;

		gameObj.transform.position = currentPosition;
	}

	private void animate(GameObject gameObj, bool isOn, float time){
		Vector3 currentPosition = gameObj.transform.position;
		if (isOn) {
			currentPosition.x = onPosX;
		} else {
			currentPosition.x = offPosX;
		}
		iTween.MoveTo(gameObj, iTween.Hash("time",time, "position",currentPosition) );
	}

	public void Change(float currentTime) {
        
		int round = getSpikeValue(currentTime);

		switch (round) {
		// easy rounds
		case 0:
            animate(edge1, false, timeAnim);
            animate(edge2, true, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, false, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, true, timeAnim);
            animate(edge7, false, timeAnim);
            break;

        case 1:
            animate(edge1, true, timeAnim);
            animate(edge2, false, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, true, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, false, timeAnim);
            break;

        case 2:
            animate(edge1, false, timeAnim);
            animate(edge2, false, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, false, timeAnim);
            animate(edge5, true, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, true, timeAnim);
            break;

        case 3:
            animate(edge1, false, timeAnim);
            animate(edge2, false, timeAnim);
            animate(edge3, true, timeAnim);
            animate(edge4, false, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, true, timeAnim);
            break;

        case 4:
            animate(edge1, false, timeAnim);
            animate(edge2, true, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, false, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, true, timeAnim);
            animate(edge7, false, timeAnim);
            break;
		
		// Hard rounds
        case 5:
            animate(edge1, true, timeAnim);
            animate(edge2, false, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, true, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, true, timeAnim);
            break;

        case 6:
            animate(edge1, false, timeAnim);
            animate(edge2, true, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, false, timeAnim);
            animate(edge5, true, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, true, timeAnim);
            break;

        case 7:
            animate(edge1, true, timeAnim);
            animate(edge2, false, timeAnim);
            animate(edge3, true, timeAnim);
            animate(edge4, false, timeAnim);
            animate(edge5, true, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, false, timeAnim);
            break;

        case 8:
            animate(edge1, false, timeAnim);
            animate(edge2, true, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, true, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, true, timeAnim);
            animate(edge7, false, timeAnim);
            break;

        case 9:
            animate(edge1, false, timeAnim);
            animate(edge2, true, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, true, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, true, timeAnim);
            animate(edge7, false, timeAnim);
            break;

        case 10:
            animate(edge1, true, timeAnim);
            animate(edge2, false, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, true, timeAnim);
            animate(edge5, true, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, true, timeAnim);
            break;

		case 11:
			animate(edge1, false, timeAnim);
			animate(edge2, true, timeAnim);
			animate(edge3, false, timeAnim);
			animate(edge4, true, timeAnim);
			animate(edge5, false, timeAnim);
			animate(edge6, true, timeAnim);
			animate(edge7, false, timeAnim);
			break;

		case 12:
			animate(edge1, true, timeAnim);
			animate(edge2, false, timeAnim);
			animate(edge3, true, timeAnim);
			animate(edge4, false, timeAnim);
			animate(edge5, true, timeAnim);
			animate(edge6, false, timeAnim);
			animate(edge7, true, timeAnim);
			break;

		// Difficult rounds
        case 13:
            animate(edge1, true, timeAnim);
            animate(edge2, true, timeAnim);
            animate(edge3, false, timeAnim);
            animate(edge4, false, timeAnim);
            animate(edge5, true, timeAnim);
            animate(edge6, true, timeAnim);
            animate(edge7, false, timeAnim);
            break;

        case 14:
            animate(edge1, false, timeAnim);
            animate(edge2, false, timeAnim);
            animate(edge3, true, timeAnim);
            animate(edge4, true, timeAnim);
            animate(edge5, false, timeAnim);
            animate(edge6, false, timeAnim);
            animate(edge7, true, timeAnim);
            break;

		case 15:
			animate(edge1, true, timeAnim);
			animate(edge2, false, timeAnim);
			animate(edge3, true, timeAnim);
			animate(edge4, true, timeAnim);
			animate(edge5, false, timeAnim);
			animate(edge6, false, timeAnim);
			animate(edge7, true, timeAnim);
			break;

		case 16:
			animate(edge1, false, timeAnim);
			animate(edge2, false, timeAnim);
			animate(edge3, false, timeAnim);
			animate(edge4, true, timeAnim);
			animate(edge5, true, timeAnim);
			animate(edge6, true, timeAnim);
			animate(edge7, false, timeAnim);
			break;

		case 17:
			animate(edge1, true, timeAnim);
			animate(edge2, true, timeAnim);
			animate(edge3, true, timeAnim);
			animate(edge4, false, timeAnim);
			animate(edge5, true, timeAnim);
			animate(edge6, false, timeAnim);
			animate(edge7, true, timeAnim);
			break;

		case 18:
			animate(edge1, false, timeAnim);
			animate(edge2, true, timeAnim);
			animate(edge3, true, timeAnim);
			animate(edge4, true, timeAnim);
			animate(edge5, false, timeAnim);
			animate(edge6, false, timeAnim);
			animate(edge7, true, timeAnim);
			break;

		case 19:
			animate(edge1, true, timeAnim);
			animate(edge2, false, timeAnim);
			animate(edge3, false, timeAnim);
			animate(edge4, true, timeAnim);
			animate(edge5, true, timeAnim);
			animate(edge6, true, timeAnim);
			animate(edge7, true, timeAnim);
			break;

		case 20:
			animate(edge1, true, timeAnim);
			animate(edge2, false, timeAnim);
			animate(edge3, false, timeAnim);
			animate(edge4, true, timeAnim);
			animate(edge5, true, timeAnim);
			animate(edge6, true, timeAnim);
			animate(edge7, true, timeAnim);
			break;

		}

	}

	private int getSpikeValue(float currentTime){
		int randNum;

		switch(gameState){
			case (int)GameState.EASY:
			currentElapseTime = 1.9f;
			break;

			case (int)GameState.MEDIUM:
			currentElapseTime = 2.9f;
			break;

			case (int)GameState.HARD:
			currentElapseTime = 3.9f;
			break;

			case (int)GameState.UNLIMITED:
			default:
			currentElapseTime = Mathf.Floor(currentTime / 60); //currentElapseTime + (Time.deltaTime) * 10;
			break;
		}

		Debug.Log("currentElapseTime " + currentElapseTime);

		//currentElapseTime = //0.9f - start //1.9f - easy //2.9f - medium //5f - easy to hard; //3.9f - hard;

		if (currentElapseTime < 1)
		{
			randNum = Random.Range(0, 4);
			
			while(currentRandNum == randNum)
			{
				randNum = Random.Range(0, 4);
			}
		}
		else if (currentElapseTime < 2)
		{
			randNum = Random.Range(5,12);
			while(currentRandNum == randNum)
			{
				randNum = Random.Range(5, 12);
			}
		}
		else if (currentElapseTime < 3){
			randNum = Random.Range(13, 17);
			while(currentRandNum == randNum)
			{
				randNum = Random.Range(13, 17);
			}
		}else if (currentElapseTime < 4) {
			
			randNum = Random.Range(18, 20);
			while(currentRandNum == randNum)
			{
				randNum = Random.Range(18, 20);
			}
		}else{
			randNum = Random.Range(0, 20);
			while(currentRandNum == randNum)
			{
				randNum = Random.Range(0, 20);
			}
		}

		currentRandNum = randNum;

		return randNum;
	}
	
}
