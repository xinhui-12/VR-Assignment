
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectablePrefab : MonoBehaviour
{
    public GameObject canvasToShow;
    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
    }
    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        ShowCanvas.Instance.EnableCanvas(canvasToShow);
    }
}
