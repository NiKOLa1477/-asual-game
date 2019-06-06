using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bg : MonoBehaviour
{
    public GUIStyle mystyle;

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width * 0.125f, Screen.height * 0.15f, Screen.width * 0.7f, Screen.height * 0.1f), "Location:", mystyle);
        GUI.Box(new Rect(Screen.width * 0.50f, Screen.height * 0.15f, Screen.width * 0.7f, Screen.height * 0.1f), "Fuel:", mystyle);
    }
}
