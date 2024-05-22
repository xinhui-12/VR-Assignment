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
        itemRenderer.material.color = customColor;
        if (customMaterial == null)
        {
            customMaterial = itemRenderer.material;
        }
        else
        {
            itemRenderer.material = customMaterial;
        }
    }
}
