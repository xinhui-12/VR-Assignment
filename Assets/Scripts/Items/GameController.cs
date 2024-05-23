using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ItemManager itemManager;
    public SaveLoadManager saveLoadManager;
    public List<Item> allItems;

    void Start()
    {
        saveLoadManager.Load(itemManager);
        StartCoroutine(PopulateScrollViewCoroutine());
    }

    IEnumerator PopulateScrollViewCoroutine()
    {
        while (!itemManager.enabled)
        {
            yield return null;
        }

        itemManager.PopulateScrollView(allItems);
    }

    public void SaveGame()
    {
        List<GameObject> itemInstances = new List<GameObject>();
        foreach (var item in allItems)
        {
            itemInstances.AddRange(GameObject.FindGameObjectsWithTag(item.itemName));
        }
        saveLoadManager.Save(itemInstances);
    }

    public void LoadGame()
    {
        saveLoadManager.Load(itemManager);
    }
}
