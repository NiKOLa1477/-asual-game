using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    
    public float S = 0.5f;
    float score = 0;
    float b = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = score + 1;
        if (SceneManager.GetActiveScene().name == "Scene0") S = 0.1f;
        else  if (score == b)
        {
            S += 0.01f;
            b += 100;
        }
        Vector2 offset = new Vector2(Time.time * S, 0);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
