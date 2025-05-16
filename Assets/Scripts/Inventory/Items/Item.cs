using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Item : MonoBehaviour
{
    public ItemSO itemSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Use()
    {
        Debug.LogError("Undefined item use");
    }

    public void PickUp()
    {
        InventoryController inventoryController = GameObject.FindFirstObjectByType<InventoryController>();
        if(inventoryController.AddItem(itemSO))
        {
            Destroy(gameObject);
        }
    }
}
