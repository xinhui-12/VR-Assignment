using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public static ShowCanvas Instance;
    private GameObject currentActiveCanvas;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnableCanvas(GameObject newCanvas)
    {
        if (currentActiveCanvas != null)
        {
            currentActiveCanvas.SetActive(false);
        }
        currentActiveCanvas = newCanvas;
        currentActiveCanvas.SetActive(true);
    }
}
