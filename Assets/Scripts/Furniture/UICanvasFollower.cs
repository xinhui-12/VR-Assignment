using UnityEngine;

public class UICanvasFollower : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceFromCamera = 1.0f;
    public GameObject uiCanvas;

    private void OnEnable()
    {
        SetInitialPositionAndRotation();
    }

    private void Update()
    {
        // Check if the right mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            ToggleUICanvas();
        }
    }

    private void SetInitialPositionAndRotation()
    {
        Vector3 newPosition = vrCamera.position + vrCamera.forward * distanceFromCamera;
        transform.position = newPosition;

        Vector3 lookDirection = transform.position - vrCamera.position;
        lookDirection.y = 0;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    private void ToggleUICanvas()
    {
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(!uiCanvas.activeSelf);
            if (uiCanvas.activeSelf)
            {
                SetInitialPositionAndRotation();
            }
        }
    }
}
