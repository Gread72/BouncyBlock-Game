using UnityEngine;
using System.Collections;

public class UseWinPlugin : MonoBehaviour {
    /*
   * Summary - UseWinPlugin - Win Plugin Class
   * Testing how to build a windoes based plugin
  */

    private Rect m_ScreenRectangle;
    private string m_DeviceName;
    private GUIStyle m_GUIStyle;

	// Use this for initialization
	void Start () {
        m_ScreenRectangle = new Rect(0, 0, Screen.width, Screen.height);
        m_DeviceName = UnityPluginForWindowsPhone.Class1.GetDeviceName;
        m_GUIStyle = new GUIStyle { fontSize = 32, alignment = TextAnchor.MiddleCenter };
	}
	
	
	void OnGUI () {
        GUI.Label(m_ScreenRectangle, m_DeviceName, m_GUIStyle); 
	}
}
