using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject itemUIPrefab;

    void Start()
    {
        if (contentPanel != null)
        {
            PopulateScrollView(new List<Item>());
        }
        else
        {
            Debug.LogError("Content panel not assigned to ItemManager!");
        }
    }

    public void PopulateScrollView(List<Item> items)
    {
        if (contentPanel == null)
        {
            Debug.LogError("Content panel not assigned to ItemManager!");
            return;
        }

        Debug.Log("Populating items...");
        foreach (Item item in items)



        {
            Debug.Log("Populating item: " + item.itemName);
            GameObject newItem = Instantiate(itemUIPrefab, contentPanel);
            newItem.GetComponent<ItemUI>().Setup(item, this);
        }
    }

    public void InstantiateItem(Item item, Vector3 position, Vector3 scale)
    {
        Debug.Log("Instantiating item: " + item.itemName);
        GameObject newItem = Instantiate(item.itemPrefab, position, Quaternion.identity);
        newItem.transform.localScale = scale;
    }
}
