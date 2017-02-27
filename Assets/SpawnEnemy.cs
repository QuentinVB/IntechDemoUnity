using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// cette classe gère le comportement du spawner
/// </summary>
public class SpawnEnemy : MonoBehaviour {
    private float limiter = 0;
    private Transform basePosition;
    private Object enemyPrefab;
	// Use this for initialization
	void Start () {
        basePosition = transform;
        limiter = 8;
        enemyPrefab = Resources.Load("Enemy");
    }

    // Update is called once per frame
    void Update ()
    {
        if (Random.Range(0, 100) == 1)
        {         
            Instantiate(enemyPrefab, computeSpawnPosition(), Quaternion.Euler(0, 0, 0));
        }
    }
    private Vector3 computeSpawnPosition()
    {
        float Xpos = Mathf.Clamp((float)System.Math.Floor(Random.Range(-limiter, limiter)),-limiter, limiter);
        return new Vector3(Xpos, basePosition.position.y, basePosition.position.z);
    }
}
