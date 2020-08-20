using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50f;
    public StarScript codeTower;
    public float mass = 10f;

    private Vector2 scaleChange = new Vector2(1, 1);
    private float leftright, updown;
    private AudioSource pelletGet;
    public AudioSource deathSound;

    void Start()
    {
        pelletGet = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MovementListener();
    }

    void FixedUpdate()
    {
        Move(leftright, updown);
        Shrink();
        transform.localScale = new Vector2(mass, mass);
        codeTower.mass = mass;
    }

    void MovementListener()
    {
        updown = Input.GetAxis("Vertical") * (speed/(mass/1000));
        leftright = Input.GetAxis("Horizontal") * (speed/(mass/1000));
    }

    void Move(float horz, float vert)
    {
        transform.Translate(horz, vert, 0);
    }

    void Shrink()
    {
        mass -= 0.0006f;
        if(transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        YummyPellet target = collision.GetComponent<YummyPellet>();
        if (target != null)
        {
            target.getNommed();
            codeTower.incScore();
            mass += .3f;
            pelletGet.Play();
        }

        BadGuy enemy = collision.GetComponent<BadGuy>();
        if(enemy != null)
        {
            codeTower.music.Stop();
            deathSound.Play();
            codeTower.gameOverScreen();
            Destroy(gameObject);
        }
    }
}
