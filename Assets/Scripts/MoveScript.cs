using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public HeroScript hs;
    float b = 100;
    public Vector2 speed = new Vector2(10, 0);
    public Vector2 direction = new Vector2(1, 0);
    private Vector2 movement;
    Rigidbody2D rig;
    float posX, posY;
    float S = 30;
    float time = 0;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (hs.S == 0)
            S = 0;
        else
        {
            time++;
            if (time == b)
            {
                S++;
                b += 100;
            }
        }
        movement = new Vector2(
            S * direction.x * hs.PowerUpSpeed,
            speed.y * direction.y);
    }
    private void FixedUpdate()
    {
        rig.velocity = movement;
    }
}
