using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilescontroll : MonoBehaviour {
    int color = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ckColor();
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name + "");
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    /**
    void checkColor()
    {
        if (color == 1)
        {
            collision.GetComponent<Renderer>().material.color = Color.red;
        }
        if (color == 0)
        {
            transform.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    */
}
