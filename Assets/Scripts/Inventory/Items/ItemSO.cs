using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Sprite icon;
    public GameObject prefab;
    public int maxStacks;
    public bool permanent = false;

    public virtual void Use()
    {

    }
}
