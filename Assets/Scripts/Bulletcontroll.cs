using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bulletcontroll : NetworkBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Bullet" || collision.otherCollider.name == "LocalPlayer")
            return;

        if (collision.otherCollider.tag == "Player")
        {
            //TODO: Collision with a Player
        }
        if (collision.otherCollider.tag == "Tile")
        {
            foreach (ContactPoint2D con in collision.contacts)
            {

            }
        }
        Destroy(this.gameObject);
    }
}
