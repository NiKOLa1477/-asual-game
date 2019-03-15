using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    float d =300;
    float S = 1;
    float score = 0;
    public Vector2 speed = new Vector2(10, 30);
    public Vector2 direction = new Vector2(-1, -1);
    private Vector2 movement;
    Rigidbody2D rig;
    float posX, posY;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        score = score + 1;
        if (score == d)
        {
            S+=0.1f;
            d += 300;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "omc")
        {
            movement = new Vector2(
            speed.x * direction.x * S,
            speed.y * direction.y * S);
        }
    }

    private void FixedUpdate()
    {
        rig.velocity = movement;
    }
}
