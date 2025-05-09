using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject[] hotbarSlots = new GameObject[5];
    private int currentHotbarSlot = 0;
    private GameObject currentSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSlot = hotbarSlots[0];
        currentHotbarSlot = 0;
        HotbarItemChange();
    }

    // Update is called once per frame
    void Update()
    {
        HotbarInput();

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PickUpTest();
        }
    }

    void PickUpTest()
    {
        GameObject.FindFirstObjectByType<Item>().PickUp();
    }

    public bool AddItem(ItemSO itemSO)
    {
        return currentSlot.GetComponent<InventoryItem>().Add(itemSO);
    }

    private void UseItem()
    {
        currentSlot.GetComponent<InventoryItem>().Use();
    }

    private void HotbarInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentHotbarSlot = 0;
            HotbarItemChange();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentHotbarSlot = 1;
            HotbarItemChange();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentHotbarSlot = 2;
            HotbarItemChange();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentHotbarSlot = 3;
            HotbarItemChange();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentHotbarSlot = 4;
            HotbarItemChange();
        }
    }

    private void HotbarItemChange()
    {

        foreach (GameObject slot in hotbarSlots)
        {
            Vector3 scale;

            if (slot == hotbarSlots[currentHotbarSlot])
            {
                scale = new Vector3(1f, 1f, 1f);
                currentSlot = slot;
            }
            else
            {
                scale = new Vector3(0.9f, 0.9f, 1f);
            }

            slot.transform.localScale = scale;
        }


    }
}
