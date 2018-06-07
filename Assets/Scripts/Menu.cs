using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //public GameObject 
    //public GameObject 

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
        }
        else if(player == 2)
        {
            Player2Exit.SetActive(true);
            Player2Char.SetActive(true);
        }
        else if(player == 3)
        {
            Player3Exit.SetActive(true);
            Player3Char.SetActive(true);
        }
        else if(player == 4)
        {
            Player4Exit.SetActive(true);
            Player4Char.SetActive(true);
        }
    }

    public void ExitButton(int player)
    {
        if (player == 1)
        {
            Player1Exit.SetActive(false);
            Player1Char.SetActive(false);
        }
        else if (player == 2)
        {
            Player2Exit.SetActive(false);
            Player2Char.SetActive(false);
        }
        else if (player == 3)
        {
            Player3Exit.SetActive(false);
            Player3Char.SetActive(false);
        }
        else if (player == 4)
        {
            Player4Exit.SetActive(false);
            Player4Char.SetActive(false);
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
