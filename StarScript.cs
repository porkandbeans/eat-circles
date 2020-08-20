using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarScript : MonoBehaviour
{
    public io.newgrounds.core ng_core;

    public Vector3 minVal = new Vector3(-7.36f, 3.35f);
    public Vector3 maxVal = new Vector3(10.22f, -6.57f);

    public GameObject star;
    public int spawnTimer;
    public float mass;

    public GameObject badGuy, deadUIStuff, aliveUIStuff;
    public AudioSource music;
    public Image musicNoteButton;
    public Sprite noteON, noteOFF;


    public Text scoreText, massText, gameOverScore;
    private int score, timer;
    private bool badguyspawncheck;

    Quaternion billy = new Quaternion(0, 0, 0, 0);
    //billy the Quaternion doesn't do anything. he's an empty var. He's just happy to be here.

    Vector3 randomPosition()
    {
        return new Vector3(Random.Range(minVal.x, maxVal.x), Random.Range(minVal.y, maxVal.y));
    }
    
    void Start()
    {
        deadUIStuff.SetActive(false);
        badguyspawncheck = true;
    }

    void FixedUpdate()
    {
        scoreText.text = score.ToString();
        massText.text = mass.ToString();
        timer++;

        if ((score % 10 == 0) && badguyspawncheck) {
            Instantiate(badGuy, randomPosition(), billy);
            badguyspawncheck = false;
            Debug.Log("Bad guy has been borned");
        }

        if (Random.Range(0,200) >= 199)
        {
            Instantiate(star, randomPosition(), billy);
        }
    }

    public void incScore()
    {
        score++;
        badguyspawncheck = true;
    }
    
    public void gameOverScreen()
    {
        ng_core.checkLogin(onLoginCheck);
        aliveUIStuff.SetActive(false);
        deadUIStuff.SetActive(true);
        gameOverScore.text = score.ToString();
    }

    void onLoginCheck(bool logged_in)
    {
        if (logged_in)
        {
            io.newgrounds.components.ScoreBoard.postScore submit_score
                = new io.newgrounds.components.ScoreBoard.postScore(); //fuck me that's a mouthful
            submit_score.id = 9355;
            submit_score.value = score;
            submit_score.callWith(ng_core);
            Debug.Log("score sent apparently...");
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void muteMusic()
    {
        if (music.isPlaying)
        {
            music.Stop();
            musicNoteButton.sprite = noteOFF;
        }
        else
        {
            music.Play();
            musicNoteButton.sprite = noteON;
        }
    }
}
