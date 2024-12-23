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
        Vector3 newPosition = vrCamera.position + vrCamera.forward * distanceFromCamera;
        uiCanvas.transform.position = newPosition;

        Vector3 lookDirection = uiCanvas.transform.position - vrCamera.position;
        lookDirection.y = 0;
        uiCanvas.transform.rotation = Quaternion.LookRotation(lookDirection);
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
