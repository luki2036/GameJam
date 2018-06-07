using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    // Use this for initialization
    void Start () {
        if (GlobalData.Player1)
        {
            player1.SetActive(true);
        }
        else
        {
            player1.SetActive(false);
        }

        if (GlobalData.Player2)
        {
            player2.SetActive(true);
        }
        else
        {
            player2.SetActive(false);
        }

        if (GlobalData.Player3)
        {
            player3.SetActive(true);
        }
        else
        {
            player3.SetActive(false);
        }

        if (GlobalData.Player4)
        {
            player4.SetActive(true);
        }
        else
        {
            player4.SetActive(false);
        }
    }
	
}
