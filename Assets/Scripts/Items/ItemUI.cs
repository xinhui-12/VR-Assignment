using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemName;
    public Button button;

    private Item item;
    private ItemManager itemManager;

    public void Setup(Item newItem, ItemManager manager)
    {
        item = newItem;
        itemManager = manager;

        icon.sprite = item.itemIcon;
        itemName.text = item.itemName;

        // Set the auto-size options for the TextMeshPro text component
        itemName.enableAutoSizing = true;
        itemName.fontSizeMin = 10; // Minimum font size
        itemName.fontSizeMax = 100; // Maximum font size

        button.onClick.AddListener(OnItemClick);
    }

    private void OnItemClick()
    {

        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 defaultPosition = cameraPosition + cameraForward * 1.0f;
        Vector3 defaultScale = Vector3.one;
        itemManager.InstantiateItem(item, defaultPosition, defaultScale);
    }
}
