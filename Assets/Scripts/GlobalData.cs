using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {

    public static bool Player1 = false;
    public static bool Player2 = false;
    public static bool Player3 = false;
    public static bool Player4 = false;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	
}
