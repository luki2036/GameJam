using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Aimcontroll : NetworkBehaviour{

    private void Update()
    {
        var pos = Input.mousePosition;
        pos.z = 68;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;
    }
}
