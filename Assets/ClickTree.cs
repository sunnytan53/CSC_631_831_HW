using UnityEngine;
using System;

public class ClickTree : MonoBehaviour
{
    public GameObject prefabToCreate;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the position of the mouse click in the game world
            // Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // clickPosition.z = 0f;

            System.Random rand = new System.Random();
            int randomX = rand.Next(-5,6);
            int randomY = rand.Next(8,15);
            int randomZ = rand.Next(-5,6);
            Vector3 proPosition = new Vector3(randomX, randomY, randomZ);
            // Instantiate the prefab at the mouse click position
            Instantiate(prefabToCreate, proPosition, Quaternion.identity);
        }
    }
}
