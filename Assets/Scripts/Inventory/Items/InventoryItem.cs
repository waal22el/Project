using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemSO itemSO;
    [SerializeField] Image icon;
    int currentStack = 0;
    Item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentStack > 0)
        {
            icon.sprite = itemSO.icon;
        }
    }

    public bool Add(ItemSO addedItemSO)
    {
        if (currentStack == 0)
        {
            itemSO = addedItemSO;
            currentStack = 1;
            return true;
        }
        else if (addedItemSO == itemSO)
        {
            if (currentStack < itemSO.maxStacks)
            {
                currentStack += 1;
                return true;
            }
        }
        return false;
    }

    public void Use()
    {
        
        if (currentStack >= 1)
        {
            if (itemSO.permanent)
            {
                if (item == null)
                {
                    GameObject gameObject = Instantiate(itemSO.prefab);
                    item = gameObject.GetComponent<Item>();
                }
            }
            else
            {
                itemSO.Use();
                currentStack -= 1;
            }
        }
            
    }
}
