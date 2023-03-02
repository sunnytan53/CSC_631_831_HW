using UnityEngine;
using System.Collections;

public class FruitController : MonoBehaviour {
    private GameObject fruit;
    private Rigidbody rb;
    private SceneController sc;

    void Start() {
        sc = GameObject.Find("SceneController").GetComponent<SceneController>();
        // Create a fruit and attach it to the tree
        fruit = gameObject;
        rb = fruit.GetComponent<Rigidbody>();
        // Set a timer for 2 seconds
        float timer = 2f;
        rb.useGravity = false;
        // rb.isKinematic = true;
        // fruit.GetComponent<SphereCollider>().isTrigger = false;
        StartCoroutine(DropFruit(fruit, timer));
    }
    
    IEnumerator DropFruit(GameObject fruit, float timer) {
        // Detach the fruit from the tree and apply physics
        yield return new WaitForSeconds(timer);
        // fruit.transform.parent = null;
        // Rigidbody rb = fruit.GetComponent<Rigidbody>();
        // rb.isKinematic = false;
        rb.useGravity = true;
    }

    IEnumerator Wait(float timer) {
        // Detach the fruit from the tree and apply physics
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
    
    void OnCollisionEnter(Collision other)
    {
        float timer = 10f;
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Floor"))
        {
            // StartCoroutine(Wait(timer));
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
                Rect myRect = new Rect(mouseX, mouseY, 150, 50);
                sc.updateScore(1);
                Destroy(clickedObject);
                //GUI.Button(myRect, "+ 10 pts");
            }
        }       
    }
}
