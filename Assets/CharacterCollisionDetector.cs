using UnityEngine;

public class CharacterCollisionDetector : MonoBehaviour
{
    public Transform treeTransform;

    private float characterRadius;
    private float treeRadius;

    void Start()
    {
        characterRadius = GetComponent<CapsuleCollider>().radius;
        treeRadius = treeTransform.GetComponent<SphereCollider>().radius;
    }

    void FixedUpdate()
    {
        Vector3 characterPosition = transform.position;
        Vector3 treePosition = treeTransform.position;
        float distance = Vector3.Distance(characterPosition, treePosition);

        if (distance < characterRadius + treeRadius)
        {
            Vector3 pushDirection = (characterPosition - treePosition).normalized;
            float pushDistance = characterRadius + treeRadius - distance;
            transform.position += pushDirection * pushDistance;
        }
    }
}
