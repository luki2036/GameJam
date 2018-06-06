using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimcontroll : MonoBehaviour {

    private void Update()
    {
        var pos = Input.mousePosition;
        pos.z = 68;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;
    }
}
