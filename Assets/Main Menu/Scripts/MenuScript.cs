using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private bool creditsTurnedOn = false;
    public GameObject credits;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GlobalData.gameMode = GlobalData.GameMode.Play;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void PlayTutorial()
    {
        GlobalData.gameMode = GlobalData.GameMode.Tutorial;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ShowCredits()
    {
        if (creditsTurnedOn)
        {
            credits.SetActive(false);
            creditsTurnedOn = false;
        } else
        {
            credits.SetActive(true);
            creditsTurnedOn = true;
        }
         
    }
}
