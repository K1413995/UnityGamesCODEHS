using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The target the camera will follow
    public Transform target;

    // Offset of the camera relative to the target
    public Vector3 offset;

    // LateUpdate is called after all Update functions have run
    void LateUpdate()
    {
        // Set the camera’s position to the target’s position plus an offset
        transform.position = target.position + offset;
    }
}
