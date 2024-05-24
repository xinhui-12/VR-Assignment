using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemName;
    public Button button; // Reference to the button component

    private Item item;
    private ItemManager itemManager;

    public void Setup(Item newItem, ItemManager manager)
    {
        item = newItem;
        itemManager = manager;

        Debug.Log("Setting up item: " + item.itemName);

        if (icon == null || itemName == null || button == null)
        {
            Debug.LogError("Icon, itemName, or button component not assigned in ItemUI!");
            return;
        }

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
        Debug.Log("Item clicked: " + item.itemName);

        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 defaultPosition = cameraPosition + cameraForward * 1.0f;
        Vector3 defaultScale = Vector3.one;
        itemManager.InstantiateItem(item, defaultPosition, defaultScale);
    }
}
