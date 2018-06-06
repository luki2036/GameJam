using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guncontroll : MonoBehaviour {

    public Transform aim;
    public GameObject bullet;
    public Transform gunExit;
    bool canShoot;

    private void Start()
    {
        canShoot = true;    
    }

    void Update()
    {
        transform.LookAt(aim);

        if (Input.GetButton("Fire1") && canShoot)
        {
            GameObject.Instantiate(bullet, gunExit.position, new Quaternion());
            canShoot = false;
            StartCoroutine(waitForNextShot());
        }
    }

    IEnumerator waitForNextShot()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
