using UnityEngine;
using UnityEngine.InputSystem;

public class VROpenInventory : MonoBehaviour
{
    public GameObject inventoryUI;

    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}
