using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddleMovement : PaddleMovement
{
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = GameObject.FindGameObjectWithTag("Ball").transform.position.y;
        SetNewPosition(pos.y);
        transform.position = pos;
    }
}
