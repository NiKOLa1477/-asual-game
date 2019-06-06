using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public GameObject[] PupsPrefs;
    public GameObject FuelObj;
    public GameObject DeathScr;
    public GameObject BG;

    public PowerUpCont PuC;
    bool isImmortal;
    public GUIStyle mystyle;
    public GUIStyle mystyle2;
    public float S=30;
    float b=100;
    int p = 1;
    int f = 1;
    double n1;
    
    public float PowerUpMultiplier, PowerUpSpeed;
    public Vector2 speed = new Vector2(10, 50);
    public Vector2 direction = new Vector2(1, 0);
    private Vector2 movement;
    Rigidbody2D rig;
    public Rigidbody2D fs;
    float posX, posY, data;
    public float stars;
    float score = 0;
    float time = 0;
    public GameObject fuel;

    void Start()
    {
        StreamReader n1data = new StreamReader(Application.persistentDataPath + "/n1.gd");
        n1 = double.Parse(n1data.ReadLine());
        n1data.Close();
        PowerUpMultiplier = 1;
        PowerUpSpeed = 1;
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
        if (S != 0)
        {
            time++;
            score += PowerUpSpeed;
            if (time == b)
            {
                S++;
                b += 100;
            }
        }
        if(time == f * 400 && n1 == 1)
        {
            SpawnFuel();
            f++;
        }

        if (time == p * 1000)
        {
            SpawnPups();
            p++;
        }
            
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(
               S * direction.x * PowerUpSpeed,
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

    void SpawnFuel()
    {
        GameObject block = Instantiate(FuelObj);
        if(time != p * 1000)
            block.transform.position = new Vector2(rig.position.x + 62.5f, 0);
        else
            block.transform.position = new Vector2(rig.position.x + 70.5f, 0);
    }

    void SpawnPups()
    {
        GameObject block = Instantiate(PupsPrefs[Random.Range(0, PupsPrefs.Length)]);
        block.transform.position = new Vector2(rig.position.x + 62.5f, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isImmortal)
        {
            col.collider.isTrigger = true;
            transform.position = new Vector3(rig.position.x + 1, rig.position.y, transform.position.z);
            return;
        }
        else
        {
            if (col.gameObject.tag == "enemy")
            {
                if (score * PowerUpSpeed > data)
                {
                    StreamWriter scoredata = new StreamWriter(Application.persistentDataPath + "/score.gd");
                    scoredata.WriteLine(score * PowerUpSpeed);
                    scoredata.Close();
                    PuC.ResetAllPowerUps();
                    DeathScreen();
                }
                else
                {
                    PuC.ResetAllPowerUps();
                    DeathScreen();
                }

            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fuel")
        {
            Destroy(col.gameObject);
            fuel.transform.position = new Vector3(fs.position.x, fuel.transform.position.y, fuel.transform.position.z);
            fuel.transform.localScale = new Vector3(1, 1, 1);
        }
        if (col.gameObject.tag == "star")
        {
            Destroy(col.gameObject); 
            stars += 1 * PowerUpMultiplier; 
        }
        if (col.gameObject.tag == "star2")
        {
            Destroy(col.gameObject);
            stars += 2 * PowerUpMultiplier;   
        }
        if (col.gameObject.tag == "star3")
        {
            Destroy(col.gameObject);
            stars += 3 * PowerUpMultiplier;
        }
        
        StreamWriter starsdata = new StreamWriter(Application.persistentDataPath + "/stars.gd");
        starsdata.WriteLine(stars);
        starsdata.Close();
    }

    public void DeathScreen()
    {
        S = 0;
        speed.y = 0;
        GameObject block = Instantiate(DeathScr);
        block.transform.position = new Vector2(BG.transform.position.x, 0);
    }

    public void ImmortalityOn()
    {
        isImmortal = true;
    }

    public void ImmortalityOff()
    {
        isImmortal = false;
    }

    private void FixedUpdate()
    {
        rig.velocity = movement;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(14, 0, Screen.width, Screen.height * 0.05f), "Score: " + score, mystyle);
        if (S == 0)
        {
            GUI.Box(new Rect(Screen.width * 0.45f, Screen.height * 0.26f, Screen.width * 0.7f, Screen.height * 0.1f), "Score: \n" + score, mystyle2);
        }
    }
}
