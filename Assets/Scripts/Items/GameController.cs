using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ItemManager itemManager;
    public SaveLoadManager saveLoadManager;
    public List<Item> allItems;

    void Start()
    {
        Invoke("PopulateScrollViewDelayed", 0.1f);
        itemManager.PopulateScrollView(allItems);
        saveLoadManager.Load(itemManager);
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