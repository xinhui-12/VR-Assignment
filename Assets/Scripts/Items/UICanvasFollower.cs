using UnityEngine;
using UnityEngine.InputSystem;

public class UICanvasFollower : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceFromCamera = 1.0f;
    public GameObject uiCanvas;

    private void OnEnable()
    {
        SetInitialPositionAndRotation();
    }

    public void OnToggleUI(InputAction.CallbackContext context)
    {
        if (context.performed)
            ToggleUICanvas();
    }

    private void SetInitialPositionAndRotation()
    {
        //Vector3 newPosition = vrCamera.position + vrCamera.forward * distanceFromCamera;
        //transform.position = newPosition;

        //Vector3 lookDirection = transform.position - vrCamera.position;
        //lookDirection.y = 0;
        //transform.rotation = Quaternion.LookRotation(lookDirection);

        // Position the pause menu in front of the user
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraForward = Camera.main.transform.forward;
        uiCanvas.transform.position = cameraPosition + cameraForward * 1.0f; // Adjust the distance as needed
        uiCanvas.transform.rotation = Quaternion.LookRotation(cameraForward);
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
