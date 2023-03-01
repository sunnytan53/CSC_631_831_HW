using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour {
    public GameObject fruitPrefab;
    private GameObject fruit;

    
    void Start() {
        // Create a fruit and attach it to the tree
        fruit = Instantiate(fruitPrefab, transform);
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        // Set a timer for 2 seconds
        float timer = 2f;
        rb.isKinematic = true;
        rb.GetComponent<SphereCollider>().isTrigger = true;
        StartCoroutine(DropFruit(fruit, timer));
    }
    

    IEnumerator DropFruit(GameObject fruit, float timer) {
        // Detach the fruit from the tree and apply physics
        yield return new WaitForSeconds(timer);
        fruit.transform.parent = null;
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

/***
    IEnumerator Wait(float timer) {
        // Detach the fruit from the tree and apply physics
        yield return new WaitForSeconds(10);
        Destroy(fruit);
    }

    
    void OnCollisionEnter(Collision other)
    {
        // float timer = 10f;
        if (other.gameObject.CompareTag("Floor"))
        {
            Rigidbody rb = fruit.GetComponent<Rigidbody>();
            // StartCoroutine(Wait(timer));
            
            rb.drag = 1.0f;
            
            // Increase the Rigidbody's mass to make it more difficult to move
            rb.mass = 2.0f;
            
            // Reduce the Rigidbody's angular drag to reduce spinning
            rb.angularDrag = 0.5f;
        }
    }
    

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
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 0.5f);


            if (clickedObject.CompareTag("Fruit"))
            {
                // Play collect effect
                // Instantiate(collectEffect, transform.position, Quaternion.identity);

                // Add points to score
                // ScoreManager.Instance.AddPoints(points);

                // Destroy fruit
                float mouseX = mousePosition.x - 5;
                float mouseY = mousePosition.y + 5;
                float mouseZ = mousePosition.z;
                Rect myRect = new Rect(mouseX, mouseY, 10, 10);
                Destroy(fruit);
                //GUI.Button(myRect, "+ 10 pts");
            }
            else if (clickedObject.CompareTag("Tree"))
            {
                // Spawn new fruit prefab
                /****
                GameObject newFruit = Instantiate(gameObject.transform.GetChild(0).gameObject, transform.position, Quaternion.identity);
                newFruit.GetComponent<Rigidbody>().isKinematic = true;
                newFruit.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                newFruit.GetComponent<BoxCollider>().isTrigger = true;
                ***/
                /***
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
                rb.GetComponent<SphereCollider>().isTrigger = true;
                // rb.Tag = 'Fruit';
                StartCoroutine(DropFruit(fruit, timer));
            }
        }       
    }
***/

}
