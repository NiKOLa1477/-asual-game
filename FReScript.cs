using UnityEngine;
using System.Collections;

public class triger : MonoBehaviour
{

    public GameObject fuel;
                           
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") 
        {
            fuel.transform.position = new Vector3(0, fuel.transform.position.y, fuel.transform.position.z);
            fuel.transform.localScale = new Vector3(1, 1, 1);
        }
    }


}