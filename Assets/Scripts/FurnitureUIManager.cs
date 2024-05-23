using UnityEngine;

public class FurnitureUIManager : MonoBehaviour
{
    public static FurnitureUIManager instance;
    public Canvas overlayCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowOverlay(bool show)
    {
        overlayCanvas.gameObject.SetActive(show);
    }
}
