using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBehaviour : MonoBehaviour
{
    private float speed;
    private int aliveTick;
    private int liveSpan;
    // Use this for initialization
    void Start()
    {
        speed = 0.2f;
        liveSpan = 200;
        aliveTick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed, 0);
        aliveTick++;
        if (aliveTick >= liveSpan)
        {
            Destroy(gameObject);
        }
    }
}
