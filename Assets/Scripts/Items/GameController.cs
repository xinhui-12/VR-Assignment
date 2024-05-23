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
        List<ItemController> itemInstances = new List<ItemController>(FindObjectsOfType<ItemController>());
        saveLoadManager.Save(itemInstances);
    }

    public void LoadGame()
    {
        saveLoadManager.Load(itemManager);
    }
}
