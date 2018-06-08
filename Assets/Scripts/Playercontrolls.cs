using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Playercontrolls : NetworkBehaviour{

    Playermoves playermoves;

    //Player data
    float maxSpeed;
    Rigidbody2D rb;

    //Data für Walljumps
    float usualGravity;
    string onWallAtached;

    //Data für Sprünge generell
    byte jumpcount;


    //Data für das Schießen
    public GameObject bullet;


    // Use this for initialization
    void Start () {
        playermoves = new Playermoves();
        maxSpeed = 100f;
        rb = GetComponent<Rigidbody2D>();
        usualGravity = rb.gravityScale;
        onWallAtached = "";
        jumpcount = 0;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "LocalPlayer";
    }

    

    // Update is called once per frame
    void Update () {
        // Ist localer Spieler?
        if (!isLocalPlayer)
            return;

        //WallJump Checkup
        if (string.IsNullOrEmpty(onWallAtached))
        {
            //Wenn kein Walljump:
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
            // Wenn WallJump:
            if (Input.GetButtonDown("Jump"))
            {
                rb.gravityScale = usualGravity;
                if (onWallAtached== "WallL")
                    playermoves.WallJump(1, rb);
                else if (onWallAtached == "WallR")
                    playermoves.WallJump(-1, rb);
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


    [Command]
    public void CmdDoFire(float aimX, float aimY,float gunExitX, float gunExitY)
    {
        RpcDoFire(aimX,aimY,gunExitX,gunExitY);
    }
    [ClientRpc]
    public void RpcDoFire(float aimX, float aimY, float gunExitX, float gunExitY)
    {
        var spawn = (GameObject)Instantiate(bullet, new Vector3(gunExitX,gunExitY), new Quaternion());
        Rigidbody2D spawnrb = spawn.GetComponent<Rigidbody2D>();
        spawnrb.velocity = (new Vector3(aimX,aimY) - new Vector3(gunExitX, gunExitY)) * 0.7f;
        spawnrb.velocity += (rb.velocity * 0.7f);
        NetworkServer.Spawn(spawn);
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
        rb.velocity = new Vector2(rb.velocity.x, 30f);
        
    }

    public void WallJump(float dir, Rigidbody2D rb)
    {
        rb.velocity = new Vector2((dir*50), 75f);
    }

}
