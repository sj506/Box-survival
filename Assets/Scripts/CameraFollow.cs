using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothingFactor = 5f;
    public float distance = 5f;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position - transform.forward * distance;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingFactor * Time.deltaTime);
        }
    }
}
