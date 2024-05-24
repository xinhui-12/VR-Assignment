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
    }

    public void PopulateScrollView(List<Item> items)
    {

        foreach (Item item in items)
        {
 
            GameObject newItem = Instantiate(itemUIPrefab, contentPanel);
            newItem.GetComponent<ItemUI>().Setup(item, this);
        }
    }

    public void InstantiateItem(Item item, Vector3 position, Vector3 scale)
    {
        GameObject newItem = Instantiate(item.itemPrefab, position, Quaternion.identity);
        newItem.transform.localScale = scale;
    }
}
