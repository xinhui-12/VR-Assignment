using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ItemInstanceData
{
    public int itemId;
    public Vector3 position;
    public Vector3 scale;
}

public class SaveLoadManager : MonoBehaviour
{
    public List<Item> allItems; 
    public string saveFilePath = "itemInstances.json";

    public void Save(List<GameObject> itemInstances)
    {
        List<ItemInstanceData> instanceDataList = new List<ItemInstanceData>();
        foreach (var instance in itemInstances)
        {
            var itemComponent = instance.GetComponent<ItemComponent>(); 

            ItemInstanceData data = new ItemInstanceData
            {
                itemId = itemComponent.item.itemID,
                position = instance.transform.position,
                scale = instance.transform.localScale,
            };
            instanceDataList.Add(data);
        }

        string json = JsonUtility.ToJson(new Serialization<ItemInstanceData>(instanceDataList), true);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, saveFilePath), json);
    }

    public void Load(ItemManager itemManager)
    {
        string filePath = Path.Combine(Application.persistentDataPath, saveFilePath);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            List<ItemInstanceData> instanceDataList = JsonUtility.FromJson<Serialization<ItemInstanceData>>(json).ToList();

            foreach (var data in instanceDataList)
            {
                Item itemData = allItems.Find(item => item.itemID == data.itemId);
                itemManager.InstantiateItem(itemData, data.position, data.scale);
            }
        }
    }
}

[System.Serializable]
public class Serialization<T>
{
    public List<T> target;
    public Serialization(List<T> target)
    {
        this.target = target;
    }
    public List<T> ToList()
    {
        return target;
    }
}

