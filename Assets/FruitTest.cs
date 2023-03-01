using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTest : MonoBehaviour {
    public GameObject fruit;
    public Rigidbody rb;

    void Start() {
        // Create a fruit and attach it to the tree
        fruit = gameObject;
        rb = fruit.GetComponent<Rigidbody>();
        // Set a timer for 2 seconds
        float timer = 5f;
        rb.isKinematic = true;
        rb.GetComponent<SphereCollider>().isTrigger = true;
        StartCoroutine(DropFruit(fruit, timer));
    }
    

    IEnumerator DropFruit(GameObject fruit, float timer) {
        // Detach the fruit from the tree and apply physics
        yield return new WaitForSeconds(timer);
        // fruit.transform.parent = null;
        // Rigidbody rb = fruit.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

}
