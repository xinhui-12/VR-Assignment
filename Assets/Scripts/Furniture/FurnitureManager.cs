
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public GameObject[] furniturePrefabs; // Array to hold furniture prefabs
    private GameObject currentFurniture;  // Reference to the currently placed furniture
    public Transform gameUI;
    public float distanceFromCamera = 2.0f;

    // Method to instantiate furniture
    public void PlaceFurniture(int index)
    {
        Vector3 newPosition = gameUI.position - gameUI.forward * distanceFromCamera;
        newPosition.x -= distanceFromCamera;
        transform.position = newPosition;
        currentFurniture = Instantiate(furniturePrefabs[index], newPosition, Quaternion.identity);
    }

    // Method to change rotation
    public void ChangeRotation(GameObject furniture)
    {
        furniture.transform.rotation = Quaternion.Euler(0f, furniture.transform.eulerAngles.y + 90, 0f);
    }
}