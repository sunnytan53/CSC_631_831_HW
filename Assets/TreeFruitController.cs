using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFruitController : MonoBehaviour {
    public GameObject fruitPrefab;
    private GameObject fruit;
    private Rigidbody rb;

    void OnMouseDown()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Get the game object that was hit by the ray
            GameObject clickedObject = hit.collider.gameObject;

            // Perform some action in response to the click
            Debug.Log("Clicked on game object name: " + clickedObject.name);

            if (clickedObject.CompareTag("Tree"))
            {
                // Spawn new fruit prefab
                /****
                GameObject newFruit = Instantiate(gameObject.transform.GetChild(0).gameObject, transform.position, Quaternion.identity);
                newFruit.GetComponent<Rigidbody>().isKinematic = true;
                newFruit.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                newFruit.GetComponent<BoxCollider>().isTrigger = true;
                ***/
                
                System.Random rand = new System.Random();
                int randomX = rand.Next(-5,6);
                int randomY = rand.Next(8,15);
                int randomZ = rand.Next(-5,6);
                Vector3 proPosition = new Vector3(randomX, randomY, randomZ);
                // Instantiate the prefab at the mouse click position
                fruit = Instantiate(fruitPrefab, proPosition, Quaternion.identity);
                Rigidbody rb = fruit.GetComponent<Rigidbody>();
                // Set a timer for 2 seconds
                float timer = 2f;
                rb.isKinematic = true;
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                // rb.GetComponent<SphereCollider>().isTrigger = true;
                // StartCoroutine(DropFruit(fruit, timer));
            }
        }       
    }

}
