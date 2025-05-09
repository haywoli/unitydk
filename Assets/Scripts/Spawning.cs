using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject Prefab;
    public float minTime = 2f;
    public float maxTime = 4f;

    private void Start()
    {
       Spawn();
    }

    private void Spawn()
    {
        Instantiate(Prefab, transform.position, Quaternion.identity);
        Invoke(nameof(Spawn), Random.Range(minTime, maxTime));
    }

}
