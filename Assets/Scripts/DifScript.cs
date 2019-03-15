using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DifScript : MonoBehaviour
{
    public GUIStyle mystyle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width * 0.15f, Screen.height * 0.30f, Screen.width * 0.7f, Screen.height * 0.1f), "Select difficult", mystyle);
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.40f, Screen.width * 0.7f, Screen.height * 0.1f), "Easy", mystyle))
        {
            StreamWriter difdata = new StreamWriter(Application.persistentDataPath + "/dif.gd");
            difdata.WriteLine("Easy");
            difdata.Close();
            SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.50f, Screen.width * 0.7f, Screen.height * 0.1f), "Normal", mystyle))
        {
            StreamWriter difdata = new StreamWriter(Application.persistentDataPath + "/dif.gd");
            difdata.WriteLine("Normal");
            difdata.Close();
            SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.60f, Screen.width * 0.7f, Screen.height * 0.1f), "Hard", mystyle))
        {
            StreamWriter difdata = new StreamWriter(Application.persistentDataPath + "/dif.gd");
            difdata.WriteLine("Hard");
            difdata.Close();
            SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        }
    }
}
