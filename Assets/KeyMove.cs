using UnityEngine;
using System.Collections;

public class KeyMove : MonoBehaviour {
    public float speed = 6.0f;
    public float gravity = -9.8f;

    // moving CharacterController for collision detection instead of transform
    private CharacterController _charController;
    private ParticleSystem ps;

    void Start(){
        _charController = GetComponent<CharacterController>();
        ps = GameObject.Find("ParticleCollision").GetComponent<ParticleSystem>();

    }

    void Update(){
        // "Horizontal" and "Veritcal" are indirect names for keyboard mappings
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //transform.Translate(deltaX, 0, deltaZ);
        //Frame rate independent movement using deltaTime
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime)
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Character Collision with: " + hit.gameObject.name);
            ps.transform.position = hit.point;
            ps.Play();
        }
    }
}