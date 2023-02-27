using UnityEngine;

public class FruitHold : MonoBehaviour
{
    public Rigidbody fruit; // Reference to the fruit Rigidbody component
    public Transform tree; // Reference to the tree Transform component

    void Start()
    {
        // Set the initial position of the fruit to be on the tree
        fruit.transform.position = tree.position;
    }

    void Update()
    {
        // Check if the fruit has fallen off the tree
        if (fruit.transform.position.y < tree.position.y)
        {
            // Apply gravity to the fruit
            fruit.useGravity = true;
        }
    }

    IEnumerator KeepFruitOnTree()
    {
        // Disable gravity for the fruit
        fruit.useGravity = false;

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Enable gravity for the fruit
        fruit.useGravity = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the fruit has collided with the ground
        if (collision.gameObject.tag == "Ground")
        {
            // Destroy the fruit
            Destroy(fruit.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the fruit has entered the trigger zone of the tree
        if (other.gameObject.tag == "Tree")
        {
            // Start the coroutine to keep the fruit on the tree
            StartCoroutine(KeepFruitOnTree());
        }
    }
}
