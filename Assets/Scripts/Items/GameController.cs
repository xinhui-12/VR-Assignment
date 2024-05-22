using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ItemManager itemManager;
    public SaveLoadManager saveLoadManager;
    public List<Item> allItems; // Assign this in the Inspector with all your items

    void Start()
    {
        // Populate the scroll view with all items on start
        itemManager.PopulateScrollView(allItems);

        // Optionally, load existing instances on start
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