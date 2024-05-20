using UnityEngine;

public class UICanvasFollower : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceFromCamera = 2.0f;

    private void Update()
    {
        Vector3 newPosition = vrCamera.position + vrCamera.forward * distanceFromCamera;
        transform.position = newPosition;

        Vector3 lookDirection = transform.position - vrCamera.position;
        lookDirection.y = 0; // Keep the UI level
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
