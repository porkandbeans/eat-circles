using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public io.newgrounds.core ng_core;
    string username;

    public Text userName_text;
    public GameObject titleText, instructionText, howToPlayButton, backButton;
    private AudioSource buttonClick;
    // Start is called before the first frame update
    void Start()
    {
        ng_core.checkLogin(onLoginCheck);
        instructionText.SetActive(false);
        backButton.SetActive(false);
        buttonClick = GetComponent<AudioSource>();
    }

    void onLoginCheck(bool logged_in)
    {
        if (logged_in)
        {
            io.newgrounds.objects.user player = ng_core.current_user;
            userName_text.text = player.name;
        }
        else
        {
            userName_text.text = "Guest";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Instructions()
    {
        buttonClick.Play();
        titleText.SetActive(false);
        instructionText.SetActive(true);
        howToPlayButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void Back()
    {
        buttonClick.Play();
        instructionText.SetActive(false);
        titleText.SetActive(true);
        howToPlayButton.SetActive(true);
        backButton.SetActive(false);
    }

    public void PlayGame()
    {
        buttonClick.Play();
        SceneManager.LoadScene("GameScene");
    }

    public void B()
    {
        buttonClick.Play();
        SceneManager.LoadScene("B");
    }
}
