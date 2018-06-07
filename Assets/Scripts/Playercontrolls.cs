using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Playercontrolls : NetworkBehaviour{

    Playermoves playermoves;
    byte jumpcount;
    string onWallAtached;
    float usualGravity;
    float maxSpeed;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        playermoves = new Playermoves();
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = 100f;
        onWallAtached = "";
        usualGravity = rb.gravityScale;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "LocalPlayer";
    }

    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
            return;

        if (string.IsNullOrEmpty(onWallAtached))
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                playermoves.Run(1,maxSpeed,rb);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                playermoves.Run(-1, maxSpeed, rb);
            }
            if (Input.GetButtonDown("Jump") && jumpcount == 0)
            {
                playermoves.NormalJump(rb);
                jumpcount++;
            }
        }
        else
        {
            
            if (Input.GetButtonDown("Jump"))
            {
                rb.gravityScale = usualGravity;
                if (onWallAtached== "WallL")
                {
                    playermoves.WallJump(1, rb);
                }
                else if (onWallAtached == "WallR")
                {
                    playermoves.WallJump(-1, rb);
                }
                jumpcount++;
                onWallAtached = "";
            }
            if (onWallAtached == "WallL" && Input.GetAxisRaw("Horizontal") > 0 || 
                onWallAtached == "WallR" && Input.GetAxisRaw("Horizontal") < 0)
            {
                rb.gravityScale = usualGravity;
                onWallAtached = "";
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isLocalPlayer)
            return;

        jumpcount = 0;
        if (collision.collider.tag == "WallL")
        {
            onWallAtached = "WallL";
            rb.gravityScale = 3f;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else if (collision.collider.tag == "WallR")
        {
            onWallAtached = "WallR";
            rb.gravityScale = 3f;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}

public class Playermoves { 

    public void Run(int dir, float maxSpeed, Rigidbody2D rb)
    {
        float addingforce = 10f * ((dir*maxSpeed - rb.velocity.x) / 2);
        rb.AddForce(new Vector2(addingforce, 0f));
    }

    public void NormalJump(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x, 100f);
        
    }

    public void WallJump(float dir, Rigidbody2D rb)
    {
        rb.velocity = new Vector2((dir*50), 75f);
    }
}
