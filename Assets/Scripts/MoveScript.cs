using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    float b = 100;
    public Vector2 speed = new Vector2(10, 0);
    public Vector2 direction = new Vector2(1, 0);
    private Vector2 movement;
    Rigidbody2D rig;
    float posX, posY;
    float S = 30;
    float score = 0;

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
        if (score == b)
        {
            S++;
            b += 100;
        }
        movement = new Vector2(
            S * direction.x,
            speed.y * direction.y);
    }
    private void FixedUpdate()
    {
        rig.velocity = movement;
    }
}
