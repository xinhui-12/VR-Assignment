using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public GameObject[] furniturePrefabs;
    private GameObject currentFurniture;
    public Transform gameUI;
    public float distanceFromCamera = 1.0f;

    // Method to instantiate furniture
    public void PlaceFurniture(int index)
    {
        Vector3 newPosition = gameUI.position + gameUI.forward * distanceFromCamera;
        newPosition.x -= distanceFromCamera;
        currentFurniture = Instantiate(furniturePrefabs[index], newPosition, Quaternion.identity);
    }

    // Method to change rotation
    public void ChangeRotation(GameObject furniture)
    {
        if (furniture != null)
        {
            furniture.transform.rotation = Quaternion.Euler(0f, furniture.transform.eulerAngles.y + 90, 0f);
        }
    }
}
