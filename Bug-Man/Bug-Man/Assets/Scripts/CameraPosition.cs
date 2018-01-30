using UnityEngine;

// Place this script on Main Camera

public class CameraPosition : MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensitivity = 2f;

    public Transform target;
    public float distanceFromTarget = 4f;
    public Vector2 rotationYMinMax = new Vector2(-40, 85);
    public float smoothRotationTime = 0.10f;
    Vector3 smoothRotationVelocity;
    Vector3 currentRotation;

    float rotationX;
    float rotationY;

    private void Start()
    {
        // if lockCursor is true
        if (lockCursor)
        {
            // Lock cursor to be at middle of game window, and make it invisible
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // cursor can be visible if pressed esc and move cursor out of game window
        }
    }

    void LateUpdate()
    {
        // rotationX adds up from the x position of mouse * mouse sensitivity
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;

        // rotationY subtracts from the y position of mouse * mouse sensitivity
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // rotationY can't go higher or lower than rotationYMinMax variable
        rotationY = Mathf.Clamp(rotationY, rotationYMinMax.x, rotationYMinMax.y);

        // your rotation = Vector3 that changes the goal over time smoothly (your rotation, Vector3 for target, velocity of rotation, 
        // smooth time for rotation)
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(rotationY, rotationX), ref smoothRotationVelocity, smoothRotationTime);

        // eulerangles = your rotation, calculated above
        transform.eulerAngles = currentRotation;

        // camera position = player position - forward momentum * your distance from player
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}

