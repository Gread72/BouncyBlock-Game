using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

    /*
     * Summary - Utility Class
     * This class contains static functions for the game
     * - convertRGBNumToDecimal - convert RGB value to Decimal value
    */

    public static string PREF_KEY_HIGH_TIME = "HighTime";
    public static string PREF_KEY_HIGH_SCORE = "HighScore";
    public static string PREF_KEY_HIGH_SCORE_2 = "HighTime2";
    public static string PREF_KEY_HIGH_SCORE_3 = "HighTime3";
    public static string PREF_KEY_SOUND_ON = "SoundOn";

    public static Color convertRGBNumToDecimal(float r, float g, float b, float a)
    {
        Color color = new Color(r / 255.0F, g / 255.0F, b / 255.0F, a / 255.0F);
        return color;
    }

    public static string setStars(int highPoints, int points)
    {
        // display stars earned so far
        string starsText = "";
        if (points < highPoints)
        {
            points = highPoints;
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
