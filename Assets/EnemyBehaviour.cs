using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float speed;
    private int aliveTick;
    private int liveSpan;
    private Object plasmaPrefab;
    private bool stillAlive;
    private int timeToCoolDown;
    private int cooldown;

    // Use this for initialization
    void Start()
    {
        speed = 0.05f;
        liveSpan = 800;
        aliveTick = 0;
        stillAlive = true;
        cooldown = 0;
        timeToCoolDown = 80;
        plasmaPrefab = Resources.Load("PlasmaBall");

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0 , -speed);
        aliveTick++;
        if (aliveTick >= liveSpan)
        {
            Destroy(gameObject);
        }
        fire();
        if(cooldown>0)cooldown--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }

    private void fire()
    {
       if(Random.Range(0,100)==1 && cooldown == 0)
        {
            Instantiate(plasmaPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            cooldown = timeToCoolDown;
        }
    }
}
