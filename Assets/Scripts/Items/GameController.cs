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
        saveLoadManager.Load(itemManager); // Load saved items

        // Start a coroutine to wait until the ItemManager component is enabled
        StartCoroutine(PopulateScrollViewCoroutine());
    }

    IEnumerator PopulateScrollViewCoroutine()
    {
        // Wait until the ItemManager component is enabled
        while (!itemManager.enabled)
        {
            yield return null;
        }

        // Once enabled, populate the scroll view
        itemManager.PopulateScrollView(allItems);
    }

    public void SaveGame()
    {
        List<ItemController> itemInstances = new List<ItemController>(FindObjectsOfType<ItemController>());
        saveLoadManager.Save(itemInstances);
    }

    public void LoadGame()
    {
        saveLoadManager.Load(itemManager);
    }
}
