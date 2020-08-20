using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NGHelper : MonoBehaviour
{
    public io.newgrounds.core ng_core;
    public GameObject loggingInText, notLoggedInText;
    // Start is called before the first frame update
    void Start()
    {
        notLoggedInText.SetActive(false);
        
        ng_core.onReady(() =>
        {

            //check login status
            ng_core.checkLogin((bool logged_in) =>
            {
                if (logged_in)
                {
                    StartGame();
                }
                else
                {
                    notLoggedInText.SetActive(true);
                    loggingInText.SetActive(false);
                    requestLogin();
                }
            });
        });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("menu");
    }

    public void requestLogin()
    {
        notLoggedInText.SetActive(false);
        loggingInText.SetActive(true);
        ng_core.requestLogin(StartGame, onLoginFailed, onLoginCancelled);
    }

    void onLoginFailed()
    {
        notLoggedInText.SetActive(true);
        loggingInText.SetActive(false);
        Debug.Log("Failed to log in");
    }

    void onLoginCancelled()
    {
        Debug.Log("Login cancelled");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
