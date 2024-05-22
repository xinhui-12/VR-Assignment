using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ItemInstanceData
{
    public int itemId;
    public Vector3 position;
    public Vector3 scale;
    public Color color;
    public string materialName;
}

public class SaveLoadManager : MonoBehaviour
{
    public List<Item> allItems; // Reference to all item data Scriptable Objects
    public string saveFilePath = "itemInstances.json";

    public void Save(List<ItemController> itemInstances)
    {
        List<ItemInstanceData> instanceDataList = new List<ItemInstanceData>();
        foreach (var instance in itemInstances)
        {
            var renderer = instance.GetComponent<Renderer>();
            string materialName = renderer != null ? renderer.material.name : "";

            ItemInstanceData data = new ItemInstanceData
            {
                itemId = instance.item.itemID,
                position = instance.transform.position,
                scale = instance.customScale,
                color = instance.customColor,
                materialName = materialName
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
                Material material = Resources.Load<Material>(data.materialName); // Assuming materials are in Resources folder
                itemManager.InstantiateItem(itemData, data.position, data.scale, data.color, material);
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
