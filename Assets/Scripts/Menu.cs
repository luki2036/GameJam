using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject ModeMenu;
    public GameObject PlayerMenu;
    public GameObject Player1Exit;
    public GameObject Player1Char;
    public GameObject Player2Exit;
    public GameObject Player2Char;
    public GameObject Player3Exit;
    public GameObject Player3Char;
    public GameObject Player4Exit;
    public GameObject Player4Char;

    private void Start()
    {
        StartMenu.SetActive(true);
        ModeMenu.SetActive(false);
        PlayerMenu.SetActive(false);
    }

    public void PlayButton()
    {
        StartMenu.SetActive(false);
        ModeMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void DeathBattle()
    {
        ModeMenu.SetActive(false);
        PlayerMenu.SetActive(true);
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void JoinButton(int player)
    {
        if (player == 1)
        {
            Player1Exit.SetActive(true);
            Player1Char.SetActive(true);
            GlobalData.Player1 = true;
        }
        else if(player == 2)
        {
            Player2Exit.SetActive(true);
            Player2Char.SetActive(true);
            GlobalData.Player2 = true;
        }
        else if(player == 3)
        {
            Player3Exit.SetActive(true);
            Player3Char.SetActive(true);
            GlobalData.Player3 = true;
        }
        else if(player == 4)
        {
            Player4Exit.SetActive(true);
            Player4Char.SetActive(true);
            GlobalData.Player4 = true;
        }
    }

    public void ExitButton(int player)
    {
        if (player == 1)
        {
            Player1Exit.SetActive(false);
            Player1Char.SetActive(false);
            GlobalData.Player1 = false;
        }
        else if (player == 2)
        {
            Player2Exit.SetActive(false);
            Player2Char.SetActive(false);
            GlobalData.Player2 = false;
        }
        else if (player == 3)
        {
            Player3Exit.SetActive(false);
            Player3Char.SetActive(false);
            GlobalData.Player3 = false;
        }
        else if (player == 4)
        {
            Player4Exit.SetActive(false);
            Player4Char.SetActive(false);
            GlobalData.Player4 = false;
        }
    }

    public void Back(int screen)
    {
        if(screen == 1)
        {
            StartMenu.SetActive(true);
            ModeMenu.SetActive(false);
        }
        else
        {
            PlayerMenu.SetActive(false);
            ModeMenu.SetActive(true);
        }
        
    }

}
