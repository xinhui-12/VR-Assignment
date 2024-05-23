using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    private Transform contentPanel;
    public GameObject itemUIPrefab;

    public void Awake()
    {
        contentPanel = GameObject.Find("InventoryContent").transform;
        if (contentPanel == null)
        {
            Debug.LogError("Content panel not found!");
        }
    }
    public void PopulateScrollView(List<Item> items)
    {
        Debug.Log("Populating items...");
        foreach (Item item in items)
        {
            Debug.Log("Populating item: " + item.itemName);
            GameObject newItem = Instantiate(itemUIPrefab, contentPanel);
            newItem.GetComponent<ItemUI>().Setup(item, this);
        }
    }

    public void InstantiateItem(Item item, Vector3 position, Vector3 scale, Color color, Material material)
    {
        Debug.Log("Instantiating item: " + item.itemName);
        GameObject newItem = Instantiate(item.itemPrefab, position, Quaternion.identity);
        ItemController itemController = newItem.AddComponent<ItemController>();
        itemController.item = item;
        itemController.customScale = scale;
        itemController.customColor = color;
        itemController.customMaterial = material;
        itemController.ApplyCustomizations();
    }
}
