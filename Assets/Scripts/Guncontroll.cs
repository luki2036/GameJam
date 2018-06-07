using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Guncontroll : NetworkBehaviour{

    Transform aim;
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
            Playercontrolls servercontrolls = this.GetComponentInParent<Playercontrolls>();
            servercontrolls.CmdDoFire(aim.position.x, aim.position.y, gunExit.position.x, gunExit.position.y);
            canShoot = false;
            StartCoroutine(waitForNextShot());
        }
            
        
    }

    IEnumerator waitForNextShot()
    {
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }
}
