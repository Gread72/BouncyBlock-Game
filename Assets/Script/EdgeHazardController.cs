using UnityEngine;
using System.Collections;

public class EdgeHazardController : MonoBehaviour
{
    /*
    * Summary - EdgeHazardController - Controller for edge components
    * This class contains the logic for peril of wall spikes
    * - The timing and animation based on the current Game level
    * - Randomize spike wall behavior
    * - Game State for the peril in the game
    * - using iTween library
   */

    #region public variables
    public enum GameState{
		UNLIMITED = 0,
		EASY = 1,
		MEDIUM = 2,
		HARD = 3
	}

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
    public GameState gameState = 0;
    
    #endregion

    #region private variables
    
    private int currentRandNum = -1;
    private float currentElapseTime = 0;

    #endregion

    // Use this for initialization
	void Start() {
		Reset(0); //reset the series of edge blocks
	}

	public void Reset(float currentTime){
		currentElapseTime = currentTime;
		
        setPosition (edge1, offPosX);
        setPosition (edge2, offPosX);
        setPosition (edge3, offPosX);
        setPosition (edge4, offPosX);
        setPosition (edge5, offPosX);
        setPosition(edge6, offPosX);
        setPosition(edge7, offPosX);
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

    private void setPosition(GameObject gameObj, float xPos)
    {
        Vector3 currentPosition = gameObj.transform.position;
        currentPosition.x = xPos;
        gameObj.transform.position = currentPosition;
    }

    private void animate(GameObject gameObj, bool isOn, float time)
    {
        Vector3 currentPosition = gameObj.transform.position;
        if (isOn)
        {
            currentPosition.x = onPosX;
        }
        else
        {
            currentPosition.x = offPosX;
        }
        iTween.MoveTo(gameObj, iTween.Hash("time", time, "position", currentPosition));
    }

	private int getSpikeValue(float currentTime){
		int randNum;

		switch(gameState){
			case GameState.EASY:
			currentElapseTime = 1.9f;
			break;

			case GameState.MEDIUM:
			currentElapseTime = 2.9f;
			break;

			case GameState.HARD:
			currentElapseTime = 3.9f;
			break;

			case GameState.UNLIMITED:
			default:
			currentElapseTime = Mathf.Floor(currentTime / 60);
			break;
		}

		//Debug.Log("currentElapseTime " + currentElapseTime);
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
