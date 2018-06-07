using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Guncontroll : NetworkBehaviour {

    Transform aim;
    public GameObject bullet;
    public Transform gunExit;
    bool canShoot;

    private void Start()
    {
        aim = GameObject.Find("AimTemp").GetComponent<Transform>();
        canShoot = true;    
    }

    void Update()
    {
        if (!this.GetComponentInParent<Playercontrolls>().isLocalPlayer)
            return;

        transform.LookAt(aim);

        if (Input.GetButton("Fire1") && canShoot)
        {
            CmdShoot(this.GetComponentInParent<Rigidbody2D>(), aim, this.GetComponentInParent<Transform>(), gunExit, bullet);
            canShoot = false;
            StartCoroutine(waitForNextShot());
        }
    }

    
    //[Command]
    public void CmdShoot(Rigidbody2D playerrb, Transform aim, Transform player, Transform gunExit, GameObject bullet)
    {
        var spawning = GameObject.Instantiate(bullet, gunExit.position, new Quaternion());
        Rigidbody2D rb = spawning.GetComponent<Rigidbody2D>();
        rb.velocity = (aim.position - player.position) * 0.7f;
        rb.velocity += (playerrb.velocity * 0.7f);
        NetworkServer.Spawn(spawning);
    }

    IEnumerator waitForNextShot()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
