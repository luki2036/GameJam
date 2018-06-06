using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcontroll : MonoBehaviour {
    Rigidbody2D rb;
    Rigidbody2D player;
    Transform aim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (GameObject.Find("AimTemp").GetComponent<Transform>().position - transform.position)*0.6f;
        rb.velocity += GameObject.Find("CharacterTemp").GetComponent<Rigidbody2D>().velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            return;

        if (collision.tag == "Player")
        {
            //TODO: Collision with a Player
        }
        Destroy(this.gameObject);
    }
}
