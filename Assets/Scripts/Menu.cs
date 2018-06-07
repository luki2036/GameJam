using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject ModeMenu;
    public GameObject PlayerMenu;
    public GameObject obj4 ;
    public GameObject obj5 ;
    public GameObject obj6 ;
    public GameObject obj7 ;
    public GameObject obj8 ;
    public GameObject obj9 ;
    public GameObject obj10;
    public GameObject obj11;
    public GameObject obj12;
    public GameObject obj13;

	public void PlayButton()
    {
        StartMenu.SetActive(false);
        ModeMenu.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

}
