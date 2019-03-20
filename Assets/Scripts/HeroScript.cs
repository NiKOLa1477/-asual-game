using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public GUIStyle mystyle;
    float S=30;
    float b=100;
    public Vector2 speed = new Vector2(10, 50);
    public Vector2 direction = new Vector2(1, 0);
    private Vector2 movement;
    Rigidbody2D rig;
    float posX, posY, data;
    public float stars;
    float score = 0;
    public GameObject fuel;

    void Start()
    {
        StreamReader scoredata = new StreamReader(Application.persistentDataPath + "/score.gd");
        data = float.Parse(scoredata.ReadLine());
        scoredata.Close();
        StreamReader starsdata = new StreamReader(Application.persistentDataPath + "/stars.gd");
        stars = float.Parse(starsdata.ReadLine());
        starsdata.Close();
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        score = score + 1;
        if (score==b)
        {
            S++;
            b += 100;
        }
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(
            S * direction.x,
            speed.y * inputY);

        

        // 6 – Убедиться, что игрок не выходит за рамки кадра
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            if(score > data)
            {
                StreamWriter scoredata = new StreamWriter(Application.persistentDataPath + "/score.gd");
                scoredata.WriteLine(score);
                scoredata.Close();
            }
            SceneManager.LoadScene("Scene0", LoadSceneMode.Single);

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fuel")
        {
            Destroy(col.gameObject);
            fuel.transform.position = new Vector3(rig.position.x - 2, fuel.transform.position.y, fuel.transform.position.z);
            fuel.transform.localScale = new Vector3(1, 1, 1);
        }
        if (col.gameObject.tag == "star")
        {
            Destroy(col.gameObject); 
            stars += 1;
            StreamWriter starsdata = new StreamWriter(Application.persistentDataPath + "/stars.gd");
            starsdata.WriteLine(stars);
            starsdata.Close();
        }
        if (col.gameObject.tag == "star2")
        {
            Destroy(col.gameObject);
            stars += 2;
            StreamWriter starsdata = new StreamWriter(Application.persistentDataPath + "/stars.gd");
            starsdata.WriteLine(stars);
            starsdata.Close();
        }
        if (col.gameObject.tag == "star3")
        {
            Destroy(col.gameObject);
            stars += 3;
            StreamWriter starsdata = new StreamWriter(Application.persistentDataPath + "/stars.gd");
            starsdata.WriteLine(stars);
            starsdata.Close();
        }
    }
    private void FixedUpdate()
    {
        rig.velocity = movement;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(14, 0, Screen.width, Screen.height * 0.05f), "Score: " + score, mystyle);
    }
}
