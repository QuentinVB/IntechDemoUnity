using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBehaviour : MonoBehaviour {
    private float speed;
    private int aliveTick;
    private int liveSpan;
	// Use this for initialization
	void Start ()
    {
        speed = 0.4f;
        liveSpan = 200;
        aliveTick = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //a chaque update on translate la position du laser
        transform.Translate(0, speed, 0);
        //on itère sa durée de vie
        aliveTick++;
        // si on atteint la durée de vie, on met fin a l'objet :(
        if(aliveTick >=liveSpan)
        {
            Destroy(gameObject);
        }
	}
}
