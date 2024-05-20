using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public FurnitureManager furnitureManager;
    public Slider posXSlider, posYSlider, posZSlider;
    public Slider rotXSlider, rotYSlider, rotZSlider;
    public Slider scaleXSlider, scaleYSlider, scaleZSlider;

    private void Update()
    {
        // Update position
        Vector3 newPosition = new Vector3(posXSlider.value, posYSlider.value, posZSlider.value);
        furnitureManager.ChangePosition(newPosition);

        // Update rotation
        Quaternion newRotation = Quaternion.Euler(rotXSlider.value, rotYSlider.value, rotZSlider.value);
        furnitureManager.ChangeRotation(newRotation);

        // Update scale
        Vector3 newScale = new Vector3(scaleXSlider.value, scaleYSlider.value, scaleZSlider.value);
        furnitureManager.ChangeScale(newScale);
    }
}