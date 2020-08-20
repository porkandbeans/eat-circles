using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    Vector2 direction;
    Vector2 constDirection;

    public GameObject pellet;

    private Quaternion billy;

    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        constDirection = RandomDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DropPellet();
        Movement();
    }

    void Movement()
    {
        timer++;
        if (timer >= 300)
        {
            constDirection = RandomDirection();
            timer = 0;
        }
        else
        {
            transform.Translate(constDirection);
        }
    }

    void DropPellet()
    {
        if(UnityEngine.Random.Range(0,100) >= 99){
            Instantiate(pellet, transform.position, billy);
        }
    }

    Vector2 RandomDirection()
    {
        direction = new Vector2(UnityEngine.Random.Range(-0.06f, 0.06f), UnityEngine.Random.Range(-0.06f, 0.06f));
        return direction;
    }
}
