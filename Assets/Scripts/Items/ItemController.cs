using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    public Vector3 customScale;
    public Color customColor;
    public Material customMaterial;

    private Renderer itemRenderer;

    private void Awake()
    {
        itemRenderer = GetComponent<Renderer>();
        ApplyCustomizations();
    }

    public void ApplyCustomizations()
    {
        transform.localScale = customScale;
        if (itemRenderer != null)
        {
            itemRenderer.material.color = customColor;
            itemRenderer.material = customMaterial;
        }
    }
}
