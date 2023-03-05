using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    public Transform player;
    public GameObject objectToSpawn;
    public float distance;

    private float distanceInSquare;

    void Start()
    {
        distanceInSquare = Mathf.Pow(distance, 2);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1))
            && (transform.position - player.position).sqrMagnitude < distanceInSquare)
        {
            Vector3 pos = transform.position;
            pos.y += 10;
            pos.x += Random.Range(-distance, distance);
            pos.z += Random.Range(-distance, distance);
            GameObject.Instantiate(objectToSpawn, pos, transform.rotation);
        }
    }
}
