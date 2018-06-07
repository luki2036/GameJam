using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bulletcontroll : NetworkBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.name== "LocalPlayer")
            return;

        if (collision.tag == "Player")
        {
            //TODO: Collision with a Player
        }
        Destroy(this.gameObject);
    }
}
