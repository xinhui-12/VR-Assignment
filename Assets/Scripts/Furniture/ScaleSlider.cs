
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScaleSlider : MonoBehaviour
{
    public GameObject prefabToScale;
    public float minScale = 0.5f;  // Minimum scale factor
    public float maxScale = 2.0f;  // Maximum scale factor
    public TextMeshProUGUI scaleTextX;
    public TextMeshProUGUI scaleTextY;
    public TextMeshProUGUI scaleTextZ;

    public readonly int maxSliderValue = 15;

    private void Awake()
    {
        if(prefabToScale != null)
        {
            scaleTextX.text = $"{prefabToScale.transform.localScale.x:0.00}";
            scaleTextY.text = $"{prefabToScale.transform.localScale.y:0.00}";
            scaleTextZ.text = $"{prefabToScale.transform.localScale.z:0.00}";

        }
    }

    public void SetXScale(float value)
    {
        if (prefabToScale != null)
        {
            float scaleStep = (maxScale - minScale) / maxSliderValue;
            float xScale = minScale + value * scaleStep;
            Vector3 newScale = prefabToScale.transform.localScale;
            newScale.x = xScale;
            prefabToScale.transform.localScale = newScale;
            scaleTextX.text = $"{xScale:0.00}";
        }
    }

    public void SetYScale(float value)
    {
        if (prefabToScale != null)
        {
            float scaleStep = (maxScale - minScale) / maxSliderValue;
            float yScale = minScale + value * scaleStep;
            Vector3 newScale = prefabToScale.transform.localScale;
            newScale.y = yScale;
            prefabToScale.transform.localScale = newScale;
            scaleTextY.text = $"{yScale:0.00}";
        }
    }

    public void SetZScale(float value)
    {
        if (prefabToScale != null)
        {
            float scaleStep = (maxScale - minScale) / maxSliderValue;
            float zScale = minScale + value * scaleStep;
            Vector3 newScale = prefabToScale.transform.localScale;
            newScale.z = zScale;
            prefabToScale.transform.localScale = newScale;
            scaleTextZ.text = $"{zScale:0.00}";
        }
    }
}
