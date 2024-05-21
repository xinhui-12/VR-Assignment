using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void InstantiateItem(Item item, Vector3 position, Vector3 scale, Color color, Material material)
    {
        GameObject newItem = Instantiate(item.itemPrefab, position, Quaternion.identity);
        ItemController itemController = newItem.AddComponent<ItemController>();
        itemController.item = item;
        itemController.customScale = scale;
        itemController.customColor = color;
        itemController.customMaterial = material;
        itemController.ApplyCustomizations();
    }
}
