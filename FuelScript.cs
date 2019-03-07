using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;

public class FuelScript : MonoBehaviour
{

    public GameObject fuelall;
    float mytimer = 100f;
    float data;
    float score = 0;
    void Start()
    {
        StreamReader scoredata = new StreamReader(Application.persistentDataPath + "/score.gd");
        data = float.Parse(scoredata.ReadLine());
        scoredata.Close();
    }

    void Update()
    {
        score = score + 1;
        mytimer = 100f;
        mytimer -= Time.deltaTime;//изменения числа с течением времени
        if (mytimer / mytimer == 1f) //проверка на период времени в 1 секунду
        {
            fuelall.transform.position = new Vector3(fuelall.transform.position.x - 0.0055f, fuelall.transform.position.y, fuelall.transform.position.z);
            fuelall.transform.localScale = new Vector3(fuelall.transform.localScale.x - 0.001f, 1, 1);
            //выше идет сдвижение влево и уменьшение по ширине зеленой полосы для имитации шкалы
        }
        if (fuelall.transform.localScale.x < 0) //если шкала исчезла то загрузка идет загрузка главного меню 
        {
            if (score > data)
            {
                StreamWriter scoredata = new StreamWriter(Application.persistentDataPath + "/score.gd");
                scoredata.WriteLine(score);
                scoredata.Close();
            }
            SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        }
    }
}