using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public string T;
    bool mouse;
    public Sprite ActS;
    public Sprite NoActS;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (mouse && T == "Y")
            {
                Application.Quit();
            }
            else if (mouse && T == "N")
            {
                SceneManager.LoadScene($"Scene00", LoadSceneMode.Single);
            }
        }
    }

    void OnMouseEnter()
    {
        mouse = true;
        GetComponent<SpriteRenderer>().sprite = NoActS;
    }
    void OnMouseExit()
    {
        mouse = false;
        GetComponent<SpriteRenderer>().sprite = ActS;
    }
}
