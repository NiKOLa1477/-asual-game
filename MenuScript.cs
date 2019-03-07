using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GUIStyle mystyle;
    string score, stars;
    string dif;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width * 0.70f, Screen.height * 0.1f, Screen.width * 0.7f, Screen.height * 0.1f), "Max Score:" + score, mystyle); //создаем небольшое окошко для показа пройденного расстояния
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.20f, Screen.width * 0.7f, Screen.height * 0.1f), "Obstacles&Fuel", mystyle)) //создаем кнопку для запуска игровой сцены
        {
            SceneManager.LoadScene("Scene1", LoadSceneMode.Single);//Загрузка игровой сцены
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.10f, Screen.width * 0.7f, Screen.height * 0.1f), "Only obstacles", mystyle)) //создаем кнопку для запуска игровой сцены
        {
            SceneManager.LoadScene("Scene2", LoadSceneMode.Single);//Загрузка игровой сцены
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.40f, Screen.width * 0.7f, Screen.height * 0.1f), "Exit", mystyle)) //создаем кнопку для выхода из игры
        {
            Application.Quit();//Выход из игры
        }
       
        GUI.Box(new Rect(Screen.width * 0.70f, Screen.height * 0.2f, Screen.width * 0.7f, Screen.height * 0.1f), "Stars:" + stars, mystyle);
    }
}
