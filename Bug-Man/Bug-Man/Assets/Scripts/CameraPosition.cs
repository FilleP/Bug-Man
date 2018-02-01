using UnityEngine;

        // place script on Main Camera
public class CameraPosition : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    

    void FixedUpdate()
    {
        Vector3 Position = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, Position, smoothSpeed);
        transform.position = smoothPosition;
    }
}
