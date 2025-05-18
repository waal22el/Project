using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Item : MonoBehaviour
{
    public ItemSO itemSO;

    [Header("Settings")]
    public float pickupDelay = 0.5f;
    private bool canPickup = false;

    void Start()
    {
        /*if (TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), 3f), ForceMode2D.Impulse);
        } They can stay put*/

        //Invoke(nameof(EnablePickup), pickupDelay);  Doesn't work with delay
    }

    void EnablePickup()
    {
        canPickup = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))// && canPickup) Doesn't work with delay
        {
            PickUp();
            Debug.Log("Item collected!");
        }
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
