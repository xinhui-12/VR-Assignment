using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemName;

    private Item item;
    private ItemManager itemManager;

    public void Setup(Item newItem, ItemManager manager)
    {
        item = newItem;
        itemManager = manager;

        Debug.Log("Setting up item: " + item.itemName); // Add debug log

        if (icon == null || itemName == null)
        {
            Debug.LogError("Icon or itemName component not assigned in ItemUI!"); // Add error log
            return;
        }

        icon.sprite = item.itemIcon;
        itemName.text = item.itemName;

        GetComponent<Button>().onClick.AddListener(OnItemClick);
    }

    private void OnItemClick()
    {
        Debug.Log("Item clicked: " + item.itemName); // Add debug log

        Vector3 defaultPosition = Vector3.zero;
        Vector3 defaultScale = Vector3.one;
        Color defaultColor = Color.white;
        Material defaultMaterial = null;
        itemManager.InstantiateItem(item, defaultPosition, defaultScale, defaultColor, defaultMaterial);
    }
}
