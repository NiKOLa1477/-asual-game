using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Locations : MonoBehaviour
{
    double n1, n2;
    bool mouse;
    
    void Start()
    {
        
    }

    void Update()
    {
        StreamReader n1data = new StreamReader(Application.persistentDataPath + "/n1.gd");
        n1 = double.Parse(n1data.ReadLine());
        n1data.Close();
        StreamReader n2data = new StreamReader(Application.persistentDataPath + "/n2.gd");
        n2 = double.Parse(n2data.ReadLine());
        n2data.Close();

        if (Input.GetMouseButtonDown(0) && mouse)
        {
            SceneManager.LoadScene($"Scene{n1}{n2}", LoadSceneMode.Single);
        }
    }

    void OnMouseEnter()
    {
        mouse = true;
    }
    void OnMouseExit()
    {
        mouse = false;
    }
}
