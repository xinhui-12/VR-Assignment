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

        Debug.Log("Setting up item: " + item.itemName);

        if (icon == null || itemName == null || button == null)
        {
            Debug.LogError("Icon, itemName, or button component not assigned in ItemUI!");
            return;
        }

        icon.sprite = item.itemIcon;
        itemName.text = item.itemName;

        itemName.enableAutoSizing = true;
        itemName.fontSizeMin = 10;
        itemName.fontSizeMax = 100;

        button.onClick.AddListener(OnItemClick);
    }

    private void OnItemClick()
    {
        Debug.Log("Item clicked: " + item.itemName);

        Vector3 defaultPosition = Vector3.zero;
        Vector3 defaultScale = Vector3.one;
        Color defaultColor = Color.white;
        Material defaultMaterial = null;
        itemManager.InstantiateItem(item, defaultPosition, defaultScale, defaultColor, defaultMaterial);
    }
}
