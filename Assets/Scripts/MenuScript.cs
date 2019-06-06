using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GUIStyle mystyle;
    public string stars, score;
    public GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        StreamReader scoredata = new StreamReader(Application.persistentDataPath + "/score.gd");
        score = scoredata.ReadLine();
        scoredata.Close();
        StreamReader starsdata = new StreamReader(Application.persistentDataPath + "/stars.gd");
        stars = starsdata.ReadLine();
        starsdata.Close();
    }
    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            GameObject block = Instantiate(exit);
            block.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width * 0.69f, Screen.height * 0.85f, Screen.width * 0.7f, Screen.height * 0.1f), score.ToString(), mystyle); //создаем небольшое окошко для показа пройденного расстояния
        

        GUI.Box(new Rect(Screen.width * 0.88f, Screen.height * 0.85f, Screen.width * 0.7f, Screen.height * 0.1f), stars.ToString(), mystyle);
    }
}
