using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MScript : MonoBehaviour
{
    public string T;
    bool mouse;
    double n1, n2;
    public string level;
    public GameObject ActF;
    public GameObject ActL;
    public GameObject L1;
    public GameObject L2;
    public GameObject Ft;
    public GameObject Ff;

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Scene02" && T != "5")
        {
            StreamReader n1data = new StreamReader(Application.persistentDataPath + "/n1.gd");
            n1 = double.Parse(n1data.ReadLine());
            n1data.Close();
            StreamReader n2data = new StreamReader(Application.persistentDataPath + "/n2.gd");
            n2 = double.Parse(n2data.ReadLine());
            n2data.Close();
            if (n2 == 1)
                ActL.transform.position = new Vector3(ActL.transform.position.x, L1.transform.position.y, ActL.transform.position.z);
            else if (n2 == 2)
                ActL.transform.position = new Vector3(ActL.transform.position.x, L2.transform.position.y, ActL.transform.position.z);
            if (n1 == 1)
                ActF.transform.position = new Vector3(ActF.transform.position.x, Ft.transform.position.y, ActF.transform.position.z);
            else if (n1 == 2)
                ActF.transform.position = new Vector3(ActF.transform.position.x, Ff.transform.position.y, ActF.transform.position.z);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (mouse && T == "1")
            {
                StreamWriter n2data = new StreamWriter(Application.persistentDataPath + "/n2.gd");
                n2data.WriteLine('1');
                n2data.Close();
                if (ActL.transform.position.y != transform.position.y)
                    ActL.transform.position = new Vector3(ActL.transform.position.x, transform.position.y, ActL.transform.position.z);
            }
            else if (mouse && T == "2")
            {
                StreamWriter n2data = new StreamWriter(Application.persistentDataPath + "/n2.gd");
                n2data.WriteLine('2');
                n2data.Close();
                if (ActL.transform.position.y != transform.position.y)
                    ActL.transform.position = new Vector3(ActL.transform.position.x, transform.position.y, ActL.transform.position.z);
            }
            else if (mouse && T == "3")
            {
                StreamWriter n1data = new StreamWriter(Application.persistentDataPath + "/n1.gd");
                n1data.WriteLine('1');
                n1data.Close();
                if (ActF.transform.position.y != transform.position.y)
                    ActF.transform.position = new Vector3(ActF.transform.position.x, transform.position.y, ActF.transform.position.z);
            }
            else if (mouse && T == "4")
            {
                StreamWriter n1data = new StreamWriter(Application.persistentDataPath + "/n1.gd");
                n1data.WriteLine('2');
                n1data.Close();
                if (ActF.transform.position.y != transform.position.y)
                    ActF.transform.position = new Vector3(ActF.transform.position.x, transform.position.y, ActF.transform.position.z);
            }          
            else if (mouse)
                SceneManager.LoadSceneAsync($"Scene0{level}", LoadSceneMode.Single);

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
