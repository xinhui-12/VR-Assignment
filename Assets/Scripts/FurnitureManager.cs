using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public GameObject[] furniturePrefabs; // Array to hold furniture prefabs
    private GameObject currentFurniture;  // Reference to the currently placed furniture
    public Transform vrCamera;
    public float distanceFromCamera = 2.0f;

    // Method to instantiate furniture
    public void PlaceFurniture(int index)
    {
        Vector3 newPosition = vrCamera.position + vrCamera.forward * distanceFromCamera;
        transform.position = newPosition;
        currentFurniture = Instantiate(furniturePrefabs[index], newPosition, Quaternion.identity);
    }

    // Method to change position
    public void ChangePosition(Vector3 newPosition)
    {
        if (currentFurniture != null)
        {
            currentFurniture.transform.position = newPosition;
        }
    }

    // Method to change rotation
    public void ChangeRotation(Quaternion newRotation)
    {
        if (currentFurniture != null)
        {
            currentFurniture.transform.rotation = newRotation;
        }
    }

    // Method to change scale
    public void ChangeScale(Vector3 newScale)
    {
        if (currentFurniture != null)
        {
            currentFurniture.transform.localScale = newScale;
        }
    }
}