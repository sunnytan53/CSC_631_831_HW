using UnityEngine;

public class FruitController : MonoBehaviour
{
    public float fallSpeed = 1f;
    public float decayTime = 5f;

    private bool isFalling = false;
    private float timeSinceFall = 0f;

    void Update()
    {
        if (!isFalling && Input.GetKeyDown(KeyCode.F))
        {
            isFalling = true;
            GetComponent<Rigidbody>().useGravity = true;
        }

        if (isFalling)
        {
            timeSinceFall += Time.deltaTime;
            if (timeSinceFall >= decayTime)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isFalling && collision.gameObject.tag == "Ground")
        {
            isFalling = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
